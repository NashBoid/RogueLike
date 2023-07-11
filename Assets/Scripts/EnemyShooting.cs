using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform shotPoint;
    
    public float rateOfFire;
    private float rof_counter;

    private Player player;

    public float offset;
    private float rotZ;
    private Vector3 difference;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        difference = player.transform.position - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        shotPoint.rotation = Quaternion.Euler(0f,0f,rotZ + offset);

        if (rof_counter <= 0)
        {
            Shoot();
        }
        else
        {
            rof_counter -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        rof_counter = rateOfFire;
    }
}
