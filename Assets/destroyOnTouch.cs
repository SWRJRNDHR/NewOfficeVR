using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnTouch : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject fly;

    public void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Swatter")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Colliding");
            Destroy(fly);
        }
    }
}