using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float runSpeed = 40f;
    private PlayerController controller;
    private Animator animator;
    // Start is called before the first frame update

    void Awake()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(runSpeed));
    }

    // UpdateFixed is called once each fixed time (used for physics)
    void FixedUpdate(){
        controller.Move(runSpeed * Time.fixedDeltaTime, false, false);
    }
}
