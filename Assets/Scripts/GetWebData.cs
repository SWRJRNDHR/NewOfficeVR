using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Facebook.WitAi.TTS.Samples;

public class GetWebData : MonoBehaviour
{
    
    public Slider VolumeSlider;
    public GameObject telephoneAudio;
    //public GameObject telephone;
    public GameObject CharacterScript;
    CommandController commandData = null;
    //public CustomTTS _TTS;
    //public GameObject demo;
    public GameObject flies;
    public InputField inputTextForCharacter;
    private bool TTSComplete;
    public GameObject teleHeadset;
    CollissionGameObject telephonecollider;

    //CustomeTTS

    public GameObject scriptCanvas;

    float time;
    float Delay;

    private void Start()
    {
        TTSComplete = false;
        telephonecollider = teleHeadset.GetComponent<CollissionGameObject>();
        time = 0f;
        Delay = 10f;
        //linkToScriptB = GameObject.Find("Standing Idle (1)").GetComponent(TT SfromWebsite);
    }

    void Update()
    {
        time = time + 1f * Time.deltaTime;

        if(time >= Delay)
        {
            time = 0f;
            StartCoroutine(GetData());
        }

    }

    IEnumerator GetData()
    {
        string url = "http://188.166.96.85/newControl.json"; 
        using (var request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
                Debug.LogError(request.error);
            else
            {
                string json = request.downloadHandler.text;
                print(json);
                commandData = JsonUtility.FromJson<CommandController>(json);
                print(commandData);
            }
        }

        CommandSelectEvent(0);
    }

    public void CommandSelectEvent(int index)
    {
        var stats = commandData;
        VolumeSlider.value = stats.Volume;

        
        if (stats.Message == 1)
        {
            CharacterScript.SetActive(true);
            Debug.Log("Executing message bolck");
        }
        else 
        {
            CharacterScript.SetActive(false);
            Debug.Log("Not Executing message bolck");
        }

        //TELEPHONE TASK
        if (stats.TelephoneFlag == 1)
        {
            Debug.Log("flag set to 1");
            Debug.Log(telephonecollider.alreadyPickedUp);
            if (telephonecollider.alreadyPickedUp == false)
            {
                Debug.Log("picked up is false");
                telephoneAudio.SetActive(true);
                scriptCanvas.SetActive(true);
            }
        }
        else if(stats.TelephoneFlag == 2) {
            CharacterScript.SetActive(true);
        }
        else
        {
            telephoneAudio.SetActive(false);
            scriptCanvas.SetActive(false);
        }
        //SWATTER TASK
        if (stats.SwatterFlag == 1)
        {
            flies.SetActive(true);

        }
        else
        {
            flies.SetActive(false);
        }
        
        if (stats.TelephoneFlag == 1)
        {
            //Character Script
            
            Debug.Log(stats.Message);
            inputTextForCharacter.text = "Hey this is Rebecca here. I am interested in selling my home. I would like to make an appointment with one of your real estate agent to do that. What appointment is available?";
            TTSComplete = true;
            
            
            /*if (newMessage == oldMessage)
            {
                inputTextForCharacter.text = null;
            }
            
            else
            {
                Debug.Log(newMessage);
                oldMessage = newMessage;
                inputTextForCharacter.text = newMessage;
            }

        }
        else
        {
            newMessage = "Code above is fucked up";
            Debug.Log(newMessage);
            inputTextForCharacter.text = newMessage;
            if (newMessage == oldMessage)
            {
                inputTextForCharacter.text = null;
            }
            else
            {
                Debug.Log(newMessage);
                oldMessage = newMessage;
                inputTextForCharacter.text = newMessage;
            }*/
        }
    }
}