using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject BulletPrefab;
    public float bulletForce = 20f;
    private float timeWhenAllowedNextShoot = 0f;
    private float timeBetweenShooting = 0.4f;

    // Update is called once per frame
    void Update()
    {
        if (timeWhenAllowedNextShoot<=Time.time)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                SoundManager.PlaySound("throwKnife");
                timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;
            }
        }
    }
    void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D body = Bullet.GetComponent<Rigidbody2D>();
        body.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
