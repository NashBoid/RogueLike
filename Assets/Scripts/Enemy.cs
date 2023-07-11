using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public float speed;

    private Player player;

    private WhenPlayerHere room;
 
    void Start()
    {
        player = FindObjectOfType<Player>();
        room = GetComponentInParent<WhenPlayerHere>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            room.enemies.Remove(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void Damaged(int damage)
    {
        health -= damage;
    }
}
