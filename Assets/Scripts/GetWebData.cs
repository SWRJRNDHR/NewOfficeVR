using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetWebData : MonoBehaviour
{
    
    public Slider VolumeSlider;
    public GameObject telephoneAudio;
    //public AudioSource telephoneRing;
    CommandController commandData = null;

    float time;
    float Delay;

    private void Start()
    {
        time = 0f;
        Delay = 10f;
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

        if(stats.TelephoneFlag == 1) {
            //telephoneAudio.SetActive(true);
            //telephoneRing.Play();
        }
        

    }
}