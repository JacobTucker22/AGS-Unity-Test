# AGS-Unity-Test
 Unity Test for AGS

## Task
Create scene with two interactable objects: A button and a switch.  
These interactable objects control a third object that rotates based on interaction with the first two objects.  

## Controls 
Click the button to toggle rotation.  
Drag upwards on the switch to change direction of rotation.  
Interact a total of 10 times before choosing to try again or exit game.  

## Basic Design
- Game Manager is a high level class that contains a list of abstract interactable object classes. As well as a reference to the Try Again Modal UI game object.  
- The button and switch classes are derived from the abstract interactable object class and implement extended logic for their specific controls.  
- The Rotating Object implements an IRotatable interface that allows the interactable objects to control the rotating behavior.  
- Each abstract interactable object raises events when interacted with or when they are reset.  
- The Game Manager listens for these events and increments the total interaction count; which it uses to check against the max interaction count and enable the end of the game when reached. 
- When the end of the game is reached, the Game Manager iterates through the interactable objects and resets them, which raises an event.  
- Each Interaction Counter class listens to their related interactable object in order to reset the number of interaction UI elements (the numbers seen directly above each object).  
- A config Scriptable Object can be adjusted to control the max number of tries, the rotation speed, and the time the switch takes to reset.  

### Notes
Made by Jacob Tucker using Unity version 2022.3.20f1.  
Build for WebGL hosted here: https://play.unity.com/mg/other/unity-test-212
