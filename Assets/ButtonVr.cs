using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVr : MonoBehaviour
{
    public GameObject button;
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
            button.transform.localPosition = new Vector3(0, 1.0467f, 0);
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
            button.transform.localPosition = new Vector3(0, 1.0493f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void SpawnShpare()
    {
        GameObject sphare = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphare.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphare.transform.localPosition = new Vector3(11.496f, 0.789f, 1.999f);
        sphare.AddComponent<Rigidbody>();

    }



}
