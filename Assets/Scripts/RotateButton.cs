using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateButton : Abstract_Interactable
{
     // Materials for color swapping
     [SerializeField]
     private Material defaultMat;
     [SerializeField]
     private Material hoverMat;
     [SerializeField]
     private Material pressedMat;

     // Reference to renderer for material swapping
     private Renderer m_Renderer;
     
     // Behavior flags for determining which color to present
     private bool isHovering = false;
     private bool isPressed = false;

     
     private void Awake()
     {
          // Get button's sprite renderer and Rotating Object to control
          m_Renderer = GetComponentInChildren<Renderer>();
          m_RotatingObject = GameObject.Find("RotatingObject").GetComponent<IRotatable>();
     }

     // If the button has not been pressed, hovering will apply hovering material
     // If the button was pressed, exits and re-enters while holding the mouse, it will stay as pressed material
     private void OnMouseEnter()
     {
          if (isInteractable)
          {
               m_Renderer.material = isPressed ? pressedMat : hoverMat;
               isHovering = true;
          }
     }

     // If the button is pressed on mouse exiting collider, it will stay pressed until mouse button is released
     // If the button is not pressed, it will apply the default material
     private void OnMouseExit()
     {
          m_Renderer.material = isPressed ? pressedMat : defaultMat;
          isHovering = false;
     }

     // On pressing the button, the pressed material is applied
     private void OnMouseDown()
     {
          if (isInteractable)
          {
               m_Renderer.material = pressedMat;
               isPressed = true;
          }
     }

     // If the mouse is released while hovering, the hover material is applied, other wise the default material is applied
     private void OnMouseUp()
     {
          if (isInteractable)
          {
               m_Renderer.material = isHovering ? hoverMat : defaultMat;
               isPressed = false;
          }
     }
     // When mouse is pressed and released over the button, triggers the button interaction
     private void OnMouseUpAsButton()
     {
          if (isInteractable)
          {
               TriggerInteraction();
               if(!isInteractable)
               {
                    // Resets color state if interactable is turned off
                    m_Renderer.material = defaultMat;
                    isHovering = false;
                    isPressed = false;
               }
          }
     }
     // Interaction calls rotating object to toggle rotation and invokes interaction event
     protected override void TriggerInteraction()
     {
          m_RotatingObject.ToggleRotation();
          base.InvokeInteractionEvent();
     }

}
