using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComplete : MonoBehaviour
{

    private Animator animator;
    private Rigidbody rigidbody;
    private BoxCollider bxc;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void OnAnimationComplete()
    {
        animator.enabled = false;
        rigidbody.useGravity = true;
        bxc.enabled = true;
    }
}
