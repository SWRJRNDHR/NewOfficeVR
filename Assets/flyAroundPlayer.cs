using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyAroundPlayer : MonoBehaviour
{

    public float speed;
    private GameObject mainCamera;
    float txPos, tyPos, tzPos,cxPos,cyPos, czPos;
    public Vector3 Target;
    public Vector3 currentPos;
    float i = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("CameraPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (i > 0.05f) {
            i = 0.02f;
        }

        cxPos = this.transform.position.x;
        cyPos = this.transform.position.y + i;
        czPos = this.transform.position.z + i;
        i += .001f;

        currentPos = new Vector3(cxPos, cyPos, czPos);


        txPos = mainCamera.transform.position.x;
        tyPos = mainCamera.transform.position.y;
        tzPos = mainCamera.transform.position.z+1;
        

        Target = new Vector3(txPos,tyPos,tzPos); 
        Chase();

    }

    void Chase()
    {
        transform.position = Vector3.MoveTowards(currentPos, Target, speed * Time.deltaTime);

    }

}
