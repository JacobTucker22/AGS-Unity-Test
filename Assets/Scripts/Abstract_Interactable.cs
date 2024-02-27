using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_Interactable : MonoBehaviour
{
     // reference to rotating object
     protected IRotatable m_RotatingObject;

     // Publisher event for flagging when an interaction occurs
     public event Action InteractionEvent;
     
     protected virtual void InvokeInteractionEvent()
     {
          InteractionEvent?.Invoke();
     }


     // Virtual interaction logic
     protected abstract void TriggerInteraction();
}
