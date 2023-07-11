using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevel : MonoBehaviour
{
    public GameObject RoomsComponent;

    private Camera cam;

    private GameObject spawned_rooms;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            int floor_cleared = 1;

            PlayerPrefs.SetInt("LevelsComplited", PlayerPrefs.GetInt("LevelsComplited") + floor_cleared);


            spawned_rooms = GameObject.FindGameObjectWithTag("Rooms");

            cam = Camera.main.GetComponent<Camera>();

            foreach(GameObject room in spawned_rooms.GetComponent<RoomVariants>().rooms)
            {
                room.GetComponent<DestroyObject>().Death();
            }

            foreach(GameObject door in spawned_rooms.GetComponent<RoomVariants>().fakeDoors)
            {
                door.GetComponent<DestroyObject>().Death();
            }

            spawned_rooms.GetComponent<DestroyObject>().Death();

            cam.transform.position = new Vector3(0, 0, -10);
            other.transform.position = new Vector3(0, 0, 0);

            Instantiate(RoomsComponent, new Vector3(0, 0, 0), RoomsComponent.transform.rotation);

            Destroy(gameObject);
        }
    }
}
