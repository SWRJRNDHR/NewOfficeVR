using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollission : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject self;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "ColumnA_hf")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            self.transform.Rotate(0.0f, 180f, 0.0f);

        }
        if (collision.gameObject.name == "Wall_6m")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            self.transform.Rotate(0.0f, 0f, 0.0f);

        }

    }


}
