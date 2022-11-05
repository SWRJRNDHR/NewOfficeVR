using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = .1f;
    [SerializeField] private float deadZone = 0.025f;

    public GameObject paper;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    AudioSource sound;

    public UnityEvent onPressed, onReleased;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (!_isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed() {

        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("pressed");
    }

    private void Released() {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }


    public void SpawnShpare()
    {
        /*GameObject sphare = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphare.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphare.transform.localPosition = new Vector3(19f, 1f, -2.443704f);
        sphare.AddComponent<Rigidbody>();
        */

        GameObject copy = GameObject.Instantiate(paper);
        copy.transform.position = new Vector3(19f, 1f, -2.443704f);

    }


}
