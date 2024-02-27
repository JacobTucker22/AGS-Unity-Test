using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionCounter : MonoBehaviour
{
     // Set interactable object in Editor\
     [SerializeField]
     private Abstract_Interactable sub_Interactable;
     // For counting and displaying number of interactions
     private int numInteractions = 0;
     private TMP_Text m_NumInteractionText;

     // Setup caallback for subscribed interaction event
     private void Awake()
     {
          if(sub_Interactable != null)
               sub_Interactable.InteractionEvent += OnInteraction;
          m_NumInteractionText = GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();
     }

     private void OnDestroy()
     {
          if (sub_Interactable != null)
               sub_Interactable.InteractionEvent -= OnInteraction;
     }
     // Callback for subscribed interaciton event
     private void OnInteraction()
     {
          numInteractions++;
          m_NumInteractionText.text = numInteractions.ToString();
     }
}
