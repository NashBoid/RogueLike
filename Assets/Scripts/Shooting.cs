using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform shotPoint;

    public float bulletSpeed;
    
    public float rateOfFire;
    private float rof_counter;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("ShootHorizontal");
        float vertical = Input.GetAxis("ShootVertical");

        if(((horizontal == 0  && vertical != 0) || (horizontal != 0  && vertical == 0)) && Time.time > rof_counter + rateOfFire)
        {
            Shoot(horizontal, vertical);
            rof_counter = Time.time;
        }
    }

    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, shotPoint.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
            (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed
        );
    }
}
