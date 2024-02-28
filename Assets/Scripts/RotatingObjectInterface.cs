using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Logic and IRotatable implementation portion of Rotating Object class
public partial class RotatingObject : IRotatable
{
     // Behavior state flags
     [SerializeField]
     private bool isRotating = false;
     [SerializeField]
     private bool isReversed = false;

     // Rotation Speeds
     // Note: Could move const to SO if 
     [SerializeField]
     private float rotationSpeed = -300.0f;
     private float initialRotationSpeed = -300f;

     // ============= IRotatable functions ====================
     // Toggle isRotating Flag
     public void ToggleRotation()
     {
          isRotating = !isRotating;
     }
     // Directly seta isRotating flag
     public void SetIsRotating(bool isRotating)
     {
          this.isRotating = isRotating;
     }
     // Directly sets transform's rotation
     public void SetRotation(Quaternion rotation)
     {
          transform.rotation = rotation;
     }
     // Toggles reversed flag and reverses rotation speed
     public void ReverseRotation()
     {
          rotationSpeed = -rotationSpeed;
          isReversed = !isReversed;
     }
     // Sets isReversed flag and rotation speed direction directly (negative or positive initial rotation speed)
     public void SetIsReversed(bool isReversed)
     {
          this.isReversed = isReversed;
          rotationSpeed = this.isReversed ? -initialRotationSpeed : initialRotationSpeed;
     }
     // Resets reverse and rotating flags to false
     // Resets transform's rotation to default
     public void Reset()
     {
          SetIsReversed(false);
          SetIsRotating(false);
          SetRotation(Quaternion.identity);
     }
}
