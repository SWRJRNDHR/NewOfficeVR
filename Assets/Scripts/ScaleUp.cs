using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using CommonUsages = UnityEngine.XR.CommonUsages;
using InputDevice = UnityEngine.XR.InputDevice;

public class ScaleUp : MonoBehaviour
{
    [SerializeField]
    private float defaultHeight = 1.8f;
    [SerializeField]
    public GameObject paper;



    void Start()
    {

        /*
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;


        while (devices.Count == 0)
        {
            InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        }

        targetDevice = devices[0];

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }*/

        Resize();
    }


/*
    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;
*/

    private void Resize()
    {
        float headHeight = paper.transform.localPosition.y;

        //Vector3 temp = new Vector3(-0.5f, 2.5f, 0.0f);
        //paper.transform.position += temp;

        //float scale = defaultHeight / headHeight;
        paper.transform.localScale = new Vector3(14f, 1f, 5f); //Vector3.one * scale;
        paper.transform.Rotate(90f, 180f, 0.0f);
        paper.transform.position = new Vector3(12.5f, 1.1f, -2.5f); ;
    }
    /*private void OnTriggerEnter(collider other)
    {
        if (other.tag == "Hand")
        {
            Copper.SetActive(false);
        }
    }
    
    void Update()
    {
        Debug.Log(devices.Count);
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        Debug.Log(triggerValue);
        if (triggerValue > 0.1f)
        {
            Debug.Log("Trigger pressed " + triggerValue);
            ButtonIsPressed.triggerIsDown = true;
        }
    }

    /* void OnEnable()
     {
         Resize();
     }*/
}

