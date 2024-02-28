using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface to abstract rotatable objects
public interface IRotatable
{
     public void ToggleRotation();
     public void SetIsRotating(bool isRotating);
     public void SetRotation(Quaternion rotation);
     public void ReverseRotation();
     public void SetIsReversed(bool isReversed);
     public void Reset();
}
