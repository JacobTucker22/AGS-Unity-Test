using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour, IRotatable
{
     [SerializeField]
     private bool isRotating = false;
     [SerializeField]
     private bool isReversed = false;

     // TODO: possibly move this to a SO
     // OR make this configurable
     [SerializeField]
     private float rotationSpeed = -300.0f;
     private float initialRotationSpeed = -300f;

     // Turn rotations on/off
     public void ToggleRotation()
     {
          isRotating = !isRotating;
     }
     public void SetIsRotating(bool isRotating)
     {
          this.isRotating = isRotating;
     }
     public void SetRotation(Quaternion rotation)
     {
          transform.rotation = rotation;
     }
     public void ReverseRotation()
     {
          rotationSpeed = -rotationSpeed;
          isReversed = !isReversed;
     }
     public void SetIsReversed(bool isReversed)
     {
          this.isReversed = isReversed;
          rotationSpeed = initialRotationSpeed;
     }

     public void Reset()
     {
          SetIsReversed(false);
          SetIsRotating(false);
          SetRotation(Quaternion.identity);
     }

     // Update is called once per frame
     void Update()
    {
          if (isRotating)
          {
               transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
          }
    }
}
