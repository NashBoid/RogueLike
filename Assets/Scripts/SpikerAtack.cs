using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikerAtack : MonoBehaviour
{

    public float rateOfFire;
    private float rof_counter;

    public int damage;

    private Player player;
    
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(Time.time > rof_counter + rateOfFire)
            {
                player.health -= damage;
                rof_counter = Time.time;
            }
        }
    }
}
