using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVr : MonoBehaviour
{
    public GameObject button;
    public GameObject paper;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    

    // Start is called before the first frame update
    void Start()
    {
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

    public void SpawnShpare()
    {
        GameObject copy = GameObject.Instantiate(paper);
        copy.transform.localPosition = new Vector3(11.756f, 0.889f, 1.999f);
        copy.AddComponent<Rigidbody>();
        
    }



}
