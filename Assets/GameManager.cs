using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     private GameManager instance;

     // Add interactable objects to this list in the editor to be counted in total count
     [SerializeField]
     private List<Abstract_Interactable> interactables;

     [SerializeField]
     private int numTotalInteractions = 0;

     private void Awake()
     {
          instance = this;
          if(interactables.Count > 0)
          {
               foreach(Abstract_Interactable interactable in interactables)
               {
                    interactable.InteractionEvent += OnInteraction;
               }
          }
     }

     private void OnDestroy()
     {
          if (interactables.Count > 0)
          {
               foreach (Abstract_Interactable interactable in interactables)
               {
                    interactable.InteractionEvent -= OnInteraction;
               }
          }
     }

     public void OnInteraction()
     {
          numTotalInteractions++;
     }
}
