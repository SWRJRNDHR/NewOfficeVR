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

    //public GameObject leftHand;
    //public GameObject rightHand;
    private InputDevice targetDevice;
    List<InputDevice> devices = new List<InputDevice>();

    void Start()
    {

        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;


        while (devices.Count == 0)
        {
            InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        }

        targetDevice = devices[0];

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
    }



    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;


    private void Resize()
    {
        float headHeight = paper.transform.localPosition.y;

        Vector3 temp = new Vector3(0.0f, 0.5f, 0.0f);
        //paper.transform.position += temp;

        float scale = defaultHeight / headHeight;
        transform.localScale = Vector3.one * scale;
        paper.transform.Rotate(90.0f, 0.0f, 0.0f);
        paper.transform.position += temp;
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

