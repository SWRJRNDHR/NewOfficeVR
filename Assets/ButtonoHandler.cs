using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonoHandler : MonoBehaviour

{
    private Button _button;
    void Awake()
    {
        _button = GetComponent<Button>();
    }

    void Update()
    {
        if (Input.GetButtonDown("x"))
        {
            _button.onClick.Invoke();
        }
    }
}