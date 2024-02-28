using System.Collections.Generic;
using UnityEngine;

// Singleton Game Manager
// References to a list of Interactable objects set in the editor and the Try Again UI game object
public class GameManager : MonoBehaviour
{
     // Singleton Instance
     public GameManager instance { get; private set; }

     // config values reference
     [SerializeField]
     private GameConfig_SO config;

     // Set the UI game object in the editor
     // This UI becomes enabled when the total number of interactions reaches the max
     [SerializeField]
     private GameObject tryAgainUI;
     // Reference to end game black screen game object
     [SerializeField]
     private GameObject endScreenUI;

     // Add interactable objects to this list in the editor to be counted in total count
     [SerializeField]
     private List<Abstract_Interactable> interactables;

     // Total number of interactions
     private int numTotalInteractions = 0;

     private void Awake()
     {
          // Initialize singelton instance
          instance = this;
          // Subscribe to interactable's events
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
          // Unsubscribe to interactable events
          if (interactables.Count > 0)
          {
               foreach (Abstract_Interactable interactable in interactables)
               {
                    interactable.InteractionEvent -= OnInteraction;
               }
          }
     }

     // Call back for interactable event
     // Increments the total number of interactions
     // Checks for max number of interactions to trigger reset and Try Again UI
     private void OnInteraction()
     {
          numTotalInteractions++;
          if(numTotalInteractions >= config.maxNumTries)
          {
               tryAgainUI.SetActive(true);
               SetAllInteractables(false);
          }
     }

     // Sets all interactables enabled flag
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
     // Reset total number of interactions, all interactables in list, and disables Try Again UI
     public void ResetGame()
     {
          numTotalInteractions = 0;
          foreach (Abstract_Interactable interactable in interactables)
          {
               interactable.ResetInteractions();
          }
          tryAgainUI.SetActive(false);
     }
     // Exits game in editor or runtime
     public void ExitGame()
     {
          // Turns screen black for nicer looking shutdown.
          endScreenUI.SetActive(true);
          #if UNITY_EDITOR
               UnityEditor.EditorApplication.isPlaying = false;
          #else
                  Application.Quit();
          #endif
     }
}
