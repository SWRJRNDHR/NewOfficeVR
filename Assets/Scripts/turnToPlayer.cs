using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnToPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject character;
    public Transform head;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        character.transform.LookAt(new Vector3(head.position.x, character.transform.position.y, head.position.z));
        character.transform.forward *= 1;
    }
}
