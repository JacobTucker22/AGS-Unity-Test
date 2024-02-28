using System;
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

     // Sets interactable flag
     public void SetInteractableFlag(bool isActive)
     {
          isInteractable = isActive;
     }
     
     // Resets interactable flag to true, calls rotating object's reset function, and triggers reset event
     public void ResetInteractions()
     {
          isInteractable = true;
          // Reset this interactables rotating object
          m_RotatingObject.Reset();
          ResetEvent?.Invoke();
     }

     // Wrapper method to invoke Interaction event for derived classes
     protected virtual void InvokeInteractionEvent()
     {
          InteractionEvent?.Invoke();
     }


     // Virtual interaction function
     protected abstract void TriggerInteraction();


}
