using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game object update portion of Rotating Object class
public partial class RotatingObject : MonoBehaviour
{
     // Update is called once per frame
     void Update()
    {
          if (isRotating)
          {
               transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
          }
    }
}
