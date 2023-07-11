using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVariants : MonoBehaviour
{

    public GameObject[] topRooms;
    public GameObject[] downRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject exitOFF;
    public GameObject exitON;

    [HideInInspector] public List<GameObject> rooms;
    [HideInInspector] public List<GameObject> fakeDoors;
    
    void Start()
    {
        StartCoroutine(ExitSpawner());
    }

    IEnumerator ExitSpawner()
    {
        yield return new WaitForSeconds(3f);

        rooms[rooms.Count - 1].GetComponent<WhenPlayerHere>().is_last_room = true;
        rooms[rooms.Count - 1].GetComponent<WhenPlayerHere>().exitOFF = exitOFF;
        rooms[rooms.Count - 1].GetComponent<WhenPlayerHere>().exitON = exitON;
    }

}
