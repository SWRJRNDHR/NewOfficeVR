using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionGameObject : MonoBehaviour
{


    //creates that script data type

    public GameObject telephoneRing;
    public bool alreadyPickedUp;

    public void Start()
    {
        alreadyPickedUp = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Right Hand" || other.gameObject.tag == "Left Hand")
        {
            telephoneRing.SetActive(false);
            alreadyPickedUp = true;
        }        
    }
}
