using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionGameObject : MonoBehaviour
{


    //creates that script data type

    public ScaleUp scaleUp;

    public void Start()
    {
        scaleUp.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Book_02 (1)")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Colliding");
            scaleUp.enabled = true;
        }

    }
}
