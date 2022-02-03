using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    public Rigidbody2D aimer;
    public GameObject Flag;
    public Collider2D HouseCollider;
    private int counter = 0;
    Animator animator;
    private float moveForce = 10f;
    Vector2 Movement;
    Vector2 mousePos;
    public Camera cam;



    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        aimer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        body.freezeRotation = true;
        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", Movement.x);
        animator.SetFloat("Vertical", Movement.y);
        animator.SetFloat("Speed", Movement.sqrMagnitude);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        body.MovePosition(body.position + Movement * moveForce * Time.fixedDeltaTime);
        body.MovePosition(body.position + Movement * moveForce * Time.fixedDeltaTime);
        Vector2 aiming = mousePos - body.position;
        float angle = Mathf.Atan2(aiming.y, aiming.x) * Mathf.Rad2Deg + 90f;
        body.rotation = angle;
    }
    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("IsDead", true);
            await WaitForHeroToDieAsync();
            SceneManager.LoadScene("LoseScene");
        }
    }
    private async Task WaitForHeroToDieAsync()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(300));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spawner"))
        {
            Instantiate(Flag, collision.transform.position , Quaternion.identity);
            collision.isTrigger = false;
            counter++;
            if (counter == 3)
            {
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}
