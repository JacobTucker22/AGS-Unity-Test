using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     private GameManager instance;

     // Set the UI game object in the editor
     [SerializeField]
     private GameObject tryAgainUI;

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

     private void OnInteraction()
     {
          numTotalInteractions++;
          if(numTotalInteractions >= 10)
          {
               tryAgainUI.SetActive(true);
               SetAllInteractables(false);
          }
     }

     private void SetAllInteractables(bool isEnabled)
     {
          if(interactables.Count > 0)
          {
               foreach(Abstract_Interactable interactable in interactables)
               {
                    interactable.SetInteractableFlag(isEnabled);
               }
          }
     }

     public void ResetGame()
     {
          numTotalInteractions = 0;
          foreach (Abstract_Interactable interactable in interactables)
          {
               interactable.ResetInteractions();
          }
          tryAgainUI.SetActive(false);
     }

     public void ExitGame()
     {
          #if UNITY_EDITOR
               UnityEditor.EditorApplication.isPlaying = false;
          #else
                  Application.Quit();
          #endif
     }
}
