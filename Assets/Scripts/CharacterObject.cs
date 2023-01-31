using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject : MonoBehaviour
{

    public CharacterController myController; 
    private PlayerControls controls; 
    public float moveSpeed;
    private Vector2 leftStick; 
    private Vector2 rightStick;
    private Vector3 movement; // Used to hold the actual changes in movement
    private Camera main_cam;
    public float dodgePower;
    public Vector3 friction = new Vector3(.90f, .99f, .90f);

    void OnEnable(){ controls.Enable(); }

    void OnDisable(){ controls.Disable(); }

    void Awake(){
        controls = new PlayerControls(); 
        controls.PlayerIMap.Dodge.performed += ctx => { OnDodge(); };
        controls.PlayerIMap.Move.performed += ctx => { leftStick = ctx.ReadValue<Vector2>(); };
        controls.PlayerIMap.Move.canceled += ctx => { leftStick = new Vector2(0,0); }; 
        controls.PlayerIMap.ShootLook.performed += ctx => { rightStick = ctx.ReadValue<Vector2>(); }; 
        controls.PlayerIMap.ShootLook.canceled += ctx => { rightStick = new Vector2(0,0); };

        controls.PlayerIMap.Shoot.performed += ctx => { Shoot(); }; 
        main_cam = Camera.main;
    }

  private void Shoot()
  {
    
  }

  private void OnDodge()
  {
    movement = transform.forward * dodgePower;
  }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Camera Relative Stick Movement
        if (leftStick.magnitude > 0.01f) {
            float angle = MathF.Atan2(leftStick.x, leftStick.y) * Mathf.Rad2Deg + main_cam.transform.eulerAngles.y;
            Vector3 velocityDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            movement = velocityDirection * moveSpeed;
        }

        if(rightStick.magnitude > 0.01f){
            float angle = MathF.Atan2(rightStick.x, rightStick.y) * Mathf.Rad2Deg + main_cam.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        myController.Move(movement);
        movement.Scale(friction);
    }
}
