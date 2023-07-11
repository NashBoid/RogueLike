using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginTheGame : MonoBehaviour
{
    public GameObject startRoom;

    private bool spawned = false;
    
    void Start()
    {
        if(!spawned)
        {
            Instantiate(startRoom, transform.position, startRoom.transform.rotation);
            spawned = true;
        }
        
    }

}
