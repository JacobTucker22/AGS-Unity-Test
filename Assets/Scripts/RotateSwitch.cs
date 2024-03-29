using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSwitch : Abstract_Interactable
{
     [SerializeField]
     private GameConfig_SO config;

     // Angles for active and inactive positions
     private const int INACTIVE_POS_ANGLE = -135;
     private const int ACTIVE_POS_ANGLE = -45;
     // Actual rotation and origin transform to rotate. (acts as a pivot)
     private Vector3 m_Rotation;
     private Transform m_Origin;

     // Active state and timer
     private bool isActive = false;
     private float activeTimer = 0.0f;

     // Mouse positions for switch interaction behavior
     // Mouse sensitivity affects distance mouse must be drug while holding button
     private float mouseDownPos = 0.0f;
     private float mouseUpPos = 0.0f;
     [SerializeField]
     private const float MOUSE_SENSITIVITY = 5.0f;

     private void Awake()
     {
          // Cache the origin's transform and this transform's rotation angles
          m_Origin = this.transform.parent.transform;
          m_Rotation = transform.rotation.eulerAngles;
          m_RotatingObject = GameObject.Find("RotatingObject").GetComponent<IRotatable>();


          // Initialize timer time from config SO
          activeTimer = config.switchTimer;
     }

     private void Update()
     {
          UpdateTimer();
     }

     // Using mouse down and mouse up instead of OnMouseDrag to match behavior from example
     private void OnMouseDown()
     {
          if (!isActive)
          { 
               mouseDownPos = Input.mousePosition.y;
          }
     }

     // Checks the distance between mouse button clicked position and mouse button release position
     // If mouse moved enough in positive Y direction, switch is activated
     private void OnMouseUp()
     {
          if (!isActive)
          {
               mouseUpPos = Input.mousePosition.y;
               if (mouseUpPos - mouseDownPos > MOUSE_SENSITIVITY && isInteractable)
               {
                    TriggerInteraction();
               }
          }
     }

     // Ticks down timer if active and resets position when timer is done
     private void UpdateTimer()
     {
          if (isActive)
          {
               activeTimer -= Time.deltaTime;
               if (activeTimer < 0.0f)
               {
                    m_Rotation = new Vector3(m_Rotation.x, m_Rotation.y, INACTIVE_POS_ANGLE);
                    m_Origin.rotation = Quaternion.Euler(m_Rotation);
                    isActive = false;
               }
          }
     }

     // Switch's overridden Interaction logic
     // Sets switch to active position, sets active flag and timer
     // Triggers the rotating object's direction and Invokes the Interaction event
     protected override void TriggerInteraction()
     {
          m_Rotation = new Vector3(m_Rotation.x, m_Rotation.y, ACTIVE_POS_ANGLE);
          m_Origin.rotation = Quaternion.Euler(m_Rotation);
          isActive = true;
          activeTimer = config.switchTimer;

          m_RotatingObject.ReverseRotation();

          base.InvokeInteractionEvent();
     }
}
