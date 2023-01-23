using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveRandomly : MonoBehaviour
{
    /*private NavMeshAgent nav = null;
    private GameObject[] RandomPoint;
    private int CurrentRandom;*/

    public float timer;
    public int newTarget;
    public float speed;
    public NavMeshAgent nav;
    public Vector3 Target;


    // Start is called before the first frame update
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
                
        /*
        nav = this.GetComponent<NavMeshAgent>();
        RandomPoint = GameObject.FindGameObjectsWithTag("RandomPoint");
        Debug.Log("Random Point = " +RandomPoint.Length.ToString());
        */
    
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= newTarget) ;
        {
            newTargetFunction();
            timer = 0;

        }


        /*if(nav.hasPath == false)
        {
            CurrentRandom = Random.Range(0, RandomPoint.Length + 1);
            nav.SetDestination(RandomPoint[CurrentRandom].transform.position);
            Debug.Log("Moving to Random point" + CurrentRandom.ToString());
        }*/
        
    }

    void newTargetFunction()
    {
        float myX = gameObject.transform.position.x;
        float myZ = gameObject.transform.position.y;

        float xPos = myX + Random.Range(myX - 100, myX + 100);
        float zPos = myZ + Random.Range(myZ - 100, myZ + 100);

        Target = new Vector3(xPos, gameObject.transform.position.y, zPos);


        nav.SetDestination(Target);

    }

}

