using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangeObjects : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Loc1;
    public GameObject Loc2;
    public GameObject Loc3;
    public GameObject Loc4;
    public GameObject Loc5;

    private GameObject[] allObjects;

    Rigidbody rig;

    bool result = false;

    float objectPosX, objectPosY, objectPosZ;


    void Start()
    {
        allObjects = GameObject.FindGameObjectsWithTag("Untagged");
        rig = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "TestingAutoPos")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            if (IsAvailable(Loc1))
            {
                objectPosX = Loc1.transform.position.x;
                objectPosZ = Loc1.transform.position.z;
                objectPosY = Loc1.transform.position.y;
                transform.position = new Vector3(objectPosX, objectPosY, objectPosZ);
            
            }
            else if (IsAvailable(Loc2))
            {
                objectPosX = Loc2.transform.position.x;
                objectPosZ = Loc2.transform.position.z;
                objectPosY = Loc2.transform.position.y + 0.2f;
                transform.position = new Vector3(objectPosX, objectPosY, objectPosZ);
            }
            else if (IsAvailable(Loc3))
            {
                transform.position = Loc3.transform.position;
            }
            else if (IsAvailable(Loc4))
            {
                transform.position = Loc4.transform.position;
            }
            else if (IsAvailable(Loc5))
            {
                transform.position = Loc5.transform.position;
            }
            else { 
            
            }

        }
    }

    bool IsAvailable(GameObject Loc)
    {
        foreach (GameObject obj in allObjects)
        {
            //Debug.Log(obj.ToString());
            if (obj.transform.position == Loc.transform.position)
                return false;
        }
        return true;
    }
}
