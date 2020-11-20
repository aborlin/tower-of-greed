// ThirdPersonMovement.cs
//
// Ismael Cortez
// 11-15-2020
// Split 3 Prototype
//
// Adapted from Brackeys:
// https://www.youtube.com/watch?v=4HpC--2iowE
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
   public CharacterController controller;
   public Transform cam;
   public float speed = 20.0f;
   public float turnSmoothTime = 0.1f;
   float turnSmoothVelocity;
   public float dashframes = 7.0f;
   public static bool regenstam = true;
   public float dashCost = 20.0f;

   // Update is called once per frame
   void Update()
   {
      float horizontal = Input.GetAxisRaw("Horizontal");
      float vertical = Input.GetAxisRaw("Vertical");

      Vector3 Direction = new Vector3(horizontal, 0.0f, vertical).normalized;

      if(Direction.magnitude >= 0.1f)
      {
         float targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
         float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

         transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
         Vector3 moveDir = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
         controller.Move(moveDir.normalized * speed * Time.deltaTime);
      }

      //allows the player to dash
      if(Input.GetKeyDown(KeyCode.LeftShift) && stamUI.stam > dashCost)
      {
         speed = 100.0f;
         regenstam = false;
         stamUI.stam -= dashCost;
      }
      if(dashframes>0)
      {
         dashframes--;
      }
      if(dashframes==0)
      {
         speed = 6.0f;
         dashframes = 7.0f;
         regenstam = true;
      }
   }
}

