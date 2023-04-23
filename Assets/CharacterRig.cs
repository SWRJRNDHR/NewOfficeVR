using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Reference: https://learn.unity.com/tutorial/working-with-animation-rigging# */

[System.Serializable]
public class PlayerMap {

    public Transform ikTarget;
    public Transform playerTarget;
    
    public Vector3 trackingPositionOfOffset;
    public Vector3 trackingRotationOffset;


    public void Map() {

        ikTarget.position = playerTarget.TransformPoint(trackingPositionOfOffset);
        ikTarget.rotation = playerTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }

}


public class CharacterRig : MonoBehaviour
{

    public PlayerMap head;
    public PlayerMap leftHand;
    public PlayerMap rightHand;


    public Transform headIK;
    public Vector3 headBodyOffset;
    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - headIK.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = headIK.position + headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(headIK.forward, Vector3.up).normalized;

        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
