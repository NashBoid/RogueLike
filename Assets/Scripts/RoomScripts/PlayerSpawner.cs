using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

   public GameObject player;

   private bool spawned = false;

   void Start()
   {

    if(!spawned)
    {
        Instantiate(player, transform.position, player.transform.rotation);
        spawned = true;

    }

   }
}
