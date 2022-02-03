using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    private Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;
    private float movespeed = 8f;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg +90f;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        EnemyMovement(movement);
    }
    void EnemyMovement(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }
    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            animator.SetBool("IsDead", true);
            await WaitForEnemyToDieAsync();
            SoundManager.PlaySound("Death");
            Destroy(gameObject);
        }
        
    }
  private async Task WaitForEnemyToDieAsync()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(300));
    }

}
