using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game object update portion of Rotating Object class
public partial class RotatingObject : MonoBehaviour
{
     private void Awake()
     {
          // Initialize rotation speed from config SO
          rotationSpeed = config.RotationSpeed;
     }
     // Update is called once per frame
     void Update()
    {
          if (isRotating)
          {
               // For playing with speeds from the scriptable object in the editor
               rotationSpeed = isReversed ? -config.RotationSpeed : config.RotationSpeed;
               transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
          }
    }
}
