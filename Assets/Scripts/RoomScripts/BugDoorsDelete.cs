using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugDoorsDelete : MonoBehaviour
{
    private RoomVariants variants;
    // Start is called before the first frame update
    void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        variants.fakeDoors.Add(gameObject);
    }

}
