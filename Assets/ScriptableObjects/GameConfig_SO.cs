using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Config_SO", order = 1)]
public class GameConfig_SO : ScriptableObject
{
     // Rotation speed
     public float RotationSpeed = -300.0f;

     // Switch timer
     public float switchTimer = 2.0f;

     // Max Number of tries for game
     public int maxNumTries = 10;
}