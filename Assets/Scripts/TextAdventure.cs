using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Security.Policy;

public class TextAdventure : MonoBehaviour
{

	private string currentRoom = "A Spooky Hallway";
	private bool hasWeapon = false;
	private bool hasKey = false;
	private bool deadZombie = false;

	void Update ()
	{
		string textBuffer = "You are currently in: " + currentRoom + "\n";

		//Inital room
		if (currentRoom == "A Spooky Hallway") {
			if (hasWeapon && !deadZombie) {
				textBuffer += "\nYou (still) hear a noise.";
			} else if (deadZombie) {
				textBuffer += "\nThere's no sound and it looks like the new key opens that door.";
				textBuffer += "\nLets get out of here!";
			} else {
				textBuffer += "\nYou hear a noise.";
			} 
			textBuffer += "\nPress [Q] to turn around and open the door.";
			textBuffer += "\nPress [W] to investigate.";
			textBuffer += "\nPress [S] to look for a weapon.";
			//Main Destination Control
			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "A Dark Room";
			} else if (Input.GetKeyDown (KeyCode.Q) && !hasKey) {
				currentRoom = "The Hallway in Front of the Door";	
			} else if (Input.GetKeyDown (KeyCode.Q) && hasKey) {
				currentRoom = "Outside";	
			} else if (Input.GetKeyDown (KeyCode.S) && !hasWeapon) {
				currentRoom = "A Corner";	
			} else if (Input.GetKeyDown (KeyCode.S) && hasWeapon) {
				//ugly hack solution 
				currentRoom = "The Same Corner";
			}
		} else if (currentRoom == "A Dark Room") { //Fail Room
			if (hasWeapon == false) {
				textBuffer += "\nYou are eaten by a zombie.";
				textBuffer += "\nPress [Q] to try again.";
				if (Input.GetKeyDown (KeyCode.Q)) {
					currentRoom = "A Spooky Hallway";
				} 
			} else { //Correct path - find key
				hasKey = true;
				deadZombie = true;
				textBuffer += "\nYou killed a zombie!";
				textBuffer += "\nAnd look, you found a key.";
				textBuffer += "\nPress [Q] to head back.";
				if (Input.GetKeyDown (KeyCode.Q)) {
					currentRoom = "A Spooky Hallway";
				}
			}
		} else if (currentRoom == "A Corner") {
			textBuffer += "\nWhat's that pointy thing in the Closet?";
			textBuffer += "\nPress [W] to find out.";
			if (Input.GetKeyDown (KeyCode.W) && !hasWeapon) {
				currentRoom = "A Closet";
			}
			textBuffer += "\nPress [Q] to go back.";
			if (Input.GetKeyDown (KeyCode.Q)) {
				currentRoom = "A Spooky Hallway";
			}	
		} else if (currentRoom == "A Closet") {
			hasWeapon = true;
			textBuffer += "\nYou found a sword!";
			textBuffer += "\nWhat about that sound from the Hallway?";
			textBuffer += "\nPress [Q] to go back";
			if (Input.GetKeyDown (KeyCode.Q)) {
				currentRoom = "A Spooky Hallway";
			} 
		} else if (currentRoom == "The Same Corner") { //Check for weapon again
			textBuffer += "\nStop looking for more weapons you can't carry them.";
			textBuffer += "\nPress [Q] to go back to the Hallway.";
			if (Input.GetKeyDown (KeyCode.Q)) {
				currentRoom = "A Spooky Hallway";
			} 
		} else if (currentRoom == "The Hallway in Front of the Door") {
			textBuffer += "\nIts Locked!!";
			textBuffer += "\nPress [Q] to go back";
			if (Input.GetKeyDown (KeyCode.Q)) {
				currentRoom = "A Spooky Hallway";
			}
		} else if (currentRoom == "Outside") { //Win Condition
			textBuffer += "\nYou're Safe!";
		}
		//Update Text Object
		GetComponent<Text> ().text = textBuffer;
	}
}
