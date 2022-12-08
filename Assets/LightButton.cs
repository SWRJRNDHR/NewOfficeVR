using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightButton : MonoBehaviour
{
    public GameObject button;
    public GameObject light1;
    public GameObject light2;
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
        if (!isPressed)
        {
            //button.transform.localPosition = new Vector3(0, 1.0467f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            //button.transform.localPosition = new Vector3(0, 1.0493f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void LightOnOff()
    {
        if (light1.activeSelf)
        {
            light1.SetActive(false);
        }
        else
        {
            light1.SetActive(true);
        }

        if (light2.activeSelf)
        {
            light2.SetActive(false);
        }
        else
        {
            light2.SetActive(true);
        }


    }



}
