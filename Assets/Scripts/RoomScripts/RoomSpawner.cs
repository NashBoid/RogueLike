using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public Direction direction;

    public enum Direction
    {
        Top,
        Down,
        Left,
        Right,
        None
    }

    private RoomVariants variants;
    private int rand;
    private float randTime;
    private bool spawned = false;
    private float waitTime = 3f;

    void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        Invoke("Spawn", Random.Range(0.1f, 0.2f));
    }

    public void Spawn()
    {
        if(!spawned)
        {
            if(direction == Direction.Top)
            {
                rand = Random.Range(0, variants.topRooms.Length);
                Instantiate(variants.topRooms[rand], transform.position, variants.topRooms[rand].transform.rotation);
            }

            else if(direction == Direction.Down)
            {
                rand = Random.Range(0, variants.downRooms.Length);
                Instantiate(variants.downRooms[rand], transform.position, variants.downRooms[rand].transform.rotation);
            }

            else if(direction == Direction.Left)
            {
                rand = Random.Range(0, variants.leftRooms.Length);
                Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
            }

            else if(direction == Direction.Right)
            {
                rand = Random.Range(0, variants.rightRooms.Length);
                Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);
            }
            else if(direction == Direction.None)
            {
                spawned = true;
            }
            spawned = true;
        }

        if (direction != Direction.None)
        {
            Destroy(gameObject, waitTime);

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("RoomPoint") && other.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(gameObject);
        }
    }

}
