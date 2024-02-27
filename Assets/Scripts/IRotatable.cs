using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface to abstract rotatable objects
public interface IRotatable
{
     public void ToggleRotation();
     public void ReverseRotation();
}
