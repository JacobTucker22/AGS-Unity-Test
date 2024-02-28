using UnityEngine;
using TMPro;

// Class that keeps track of number of interactions and UI display of number of interactions
public class InteractionCounter : MonoBehaviour
{
     // Set interactable object in Editor
     [SerializeField]
     private Abstract_Interactable sub_Interactable;
     // Number of interactions
     private int numInteractions = 0;
     // UI Text reference that displays number of interactions
     private TMP_Text m_NumInteractionText;

     // Setup caallback for subscribed interaction event
     private void Awake()
     {
          if(sub_Interactable != null)
          {
               sub_Interactable.InteractionEvent += OnInteraction;
               sub_Interactable.ResetEvent += OnReset;
          }
          m_NumInteractionText = GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();
     }

     // Unsubscribe callbacks
     private void OnDestroy()
     {
          if (sub_Interactable != null)
          {
               sub_Interactable.InteractionEvent -= OnInteraction;
               sub_Interactable.ResetEvent -= OnReset;
          }
     }
     // Callback for subscribed interaciton event
     // Increments internal number of interactions and updates UI text
     private void OnInteraction()
     {
          numInteractions++;
          m_NumInteractionText.text = numInteractions.ToString();
     }
     // Resets number of interactions and UI Text
     public void OnReset()
     {
          numInteractions = 0;
          m_NumInteractionText.text = numInteractions.ToString();
     }
}
