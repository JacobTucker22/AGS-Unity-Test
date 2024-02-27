using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateButton : MonoBehaviour
{
     // reference to rotating object
     private IRotatable m_RotatingObject;

     // Materials for color swapping
     [SerializeField]
     private Material defaultMat;
     [SerializeField]
     private Material hoverMat;
     [SerializeField]
     private Material pressedMat;

     private Renderer m_Renderer;

     private bool isHovering = false, isPressed = false;

     
     private void Awake()
     {
          // Get button's sprite renderer
          m_Renderer = GetComponentInChildren<Renderer>();
          m_RotatingObject = GameObject.Find("RotatingObject").GetComponent<IRotatable>();
     }

     // If the button has not been pressed, hovering will apply hovering material
     // If the button was pressed, exits and re-enters while holding the mouse, it will stay as pressed material
     private void OnMouseEnter()
     {
          m_Renderer.material = isPressed ? pressedMat : hoverMat;
          isHovering = true;
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
          m_Renderer.material = pressedMat;
          isPressed = true;
     }

     // If the mouse is released while hovering, the hover material is applied, other wise the default material is applied
     private void OnMouseUp()
     {
          m_Renderer.material = isHovering ? hoverMat : defaultMat;
          isPressed = false;
     }

     private void OnMouseUpAsButton()
     {
          m_RotatingObject.ToggleRotation();
     }

}
