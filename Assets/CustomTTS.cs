using UnityEngine;
using UnityEngine.UI;
using Facebook.WitAi.TTS.Utilities;
using TMPro;
using System;

namespace Facebook.WitAi.TTS.Samples
{
    public class CustomTTS : MonoBehaviour
    {

        //[SerializeField] private TMP_Text _title;
        //[SerializeField] private TMP_InputField _input;
        [SerializeField] private Text _title;
        [SerializeField] private InputField _input;
        //[SerializeField] private Text _input1;
        [SerializeField] private TTSSpeaker _speaker;
        //public string textToSpeak;
        public GameObject trigger;

        private void Start ()
        {
            if (trigger.activeSelf)
            {
                SayPhrase();
            }

        }

        // Preset text fields
        private void Update()
        {
            if (!string.Equals(_title.text, _speaker.presetVoiceID))
            {
                _title.text = _speaker.presetVoiceID;
                _input.placeholder.GetComponent<Text>().text = $"Write something to say in {_speaker.presetVoiceID}'s voice";
                //_input.text += textToSpeak;
                
            }
        }

        // Either say the current phrase or stop talking/loading
        public void SayPhrase()
        {
            if (_speaker.IsLoading || _speaker.IsSpeaking)
            {
                _speaker.Stop();
            }
            else
            {
                _speaker.Speak(_input.text);
            }
        }
    }
}

