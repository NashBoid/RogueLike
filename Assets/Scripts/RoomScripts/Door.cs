using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{

    public GameObject block;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Block")
        {
            Debug.Log("Moved");
            Instantiate(block, transform.GetChild(0).position, transform.rotation);
            Instantiate(block, transform.GetChild(1).position, transform.rotation);
            Destroy(gameObject);
        }
    }

}

