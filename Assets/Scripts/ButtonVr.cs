using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVr : MonoBehaviour
{
    public GameObject button;
    public GameObject InPaper;
    public GameObject OutPaper;
    private Animator animator1;
    private Animator animator2;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    

    // Start is called before the first frame update
    void Start()
    {
        animator1 = InPaper.GetComponent<Animator>();
        animator2 = OutPaper.GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed) {
            //button.transform.localPosition = new Vector3(0, 1.0467f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser)
        {
            //button.transform.localPosition = new Vector3(0, 1.0493f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void CreateCopy()
    {
        /* GameObject copy = GameObject.Instantiate(paper);
         copy.transform.localPosition = new Vector3(11.756f, 0.889f, 1.87f);
         copy.AddComponent<Rigidbody>();
         */

        animator1.enabled = true;
        animator1.Play("PaperINMachine");

        animator2.enabled = true;
        animator2.Play("PaperOUTMachine");

    }



}
