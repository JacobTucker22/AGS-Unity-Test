using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface to abstract rotatable objects
public interface IRotatable
{
     // Toggle isRotating flag
     public void ToggleRotation();
     // Set isRotating flag directly
     public void SetIsRotating(bool isRotating);
     // Set transform's rotation directly
     public void SetRotation(Quaternion rotation);
     // Toggle rotation direction
     public void ReverseRotation();
     // Set reverse flag and direction directly
     public void SetIsReversed(bool isReversed);
     // Reset to a default state
     public void Reset();
}
