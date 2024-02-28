using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Abstract_Interactable : MonoBehaviour
{
     // reference to rotating object
     protected IRotatable m_RotatingObject;
     // Flag for enabling/disabling whether the interactable objects can be interacted with
     public bool isInteractable { get; protected set; } = true;

     // Publisher event for flagging when an interaction occurs
     public event Action InteractionEvent;
     public event Action ResetEvent;

     public void SetInteractableFlag(bool isActive)
     {
          isInteractable = isActive;
     }

     public void ResetInteractions()
     {
          isInteractable = true;
          // Reset this interactables rotating object
          m_RotatingObject.Reset();
          ResetEvent?.Invoke();
     }

     protected virtual void InvokeInteractionEvent()
     {
          InteractionEvent?.Invoke();
     }


     // Virtual interaction logic
     protected abstract void TriggerInteraction();


}
