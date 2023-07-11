using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenPlayerHere : MonoBehaviour
{
    public GameObject[] doors;

    [Header("Enemies")]
    public GameObject[] enemyTypes;
    public Transform[] enemySpawners;

    [HideInInspector] public List<GameObject> enemies;

    private RoomVariants variants;
    private bool spawned;

    [Header("Exits")]
    [HideInInspector] public GameObject exitOFF;
    [HideInInspector] public GameObject exitON;
    [HideInInspector] public bool is_last_room = false;

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        variants.rooms.Add(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if(other.CompareTag("Player") && !spawned)
        {
            spawned = true;

            if(is_last_room)
            {
                Instantiate(exitOFF,transform.position, Quaternion.identity);
            }

            foreach(Transform spawner in enemySpawners)
            {
                int rand = Random.Range(0, 10);
                if(rand <= 5)
                {
                    GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
                    GameObject enemy = Instantiate(enemyType, spawner.position, Quaternion.identity) as GameObject;
                    enemy.transform.parent = transform;
                    enemies.Add(enemy);
                }
            }

            StartCoroutine(CheckEnemies());
        }
    }

    IEnumerator CheckEnemies()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => enemies.Count == 0);
        DestroyDoors();
    }

    public void DestroyDoors()
    {
        foreach(GameObject door in doors)
        {
           Destroy(door);
        }
        if(is_last_room)
        {
            Instantiate(exitON,transform.position, Quaternion.identity);
            GameObject the_exit = GameObject.FindGameObjectWithTag("Exit");
            the_exit.GetComponent<DestroyObject>().Death();
        }
    }
}
