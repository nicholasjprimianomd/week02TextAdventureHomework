using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Security.Policy;

public class TextAdventure : MonoBehaviour
{

	private string currentRoom = "A Hallway";
	private bool hasWeapon = false;
	private bool hasKey = false;

	void Update ()
	{
		string textBuffer = "You are currently in: " + currentRoom;

		if (currentRoom == "A Hallway") {
			if (hasWeapon) {
				textBuffer += "\nYou (still) hear a noise.";
			} else {
				textBuffer += "\nYou hear a noise.";
			}
			textBuffer += "\nPress [Q] to turn around and open the door.";
			textBuffer += "\nPress [W] to investigate.";
			textBuffer += "\nPress [S] to look for a weapon.";
			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "A Dark Room";
			} else if (Input.GetKeyDown (KeyCode.Q) && !hasKey) {
				currentRoom = "The Hallway in Front of the Door";	
			} else if (Input.GetKeyDown (KeyCode.Q) && hasKey) {
				currentRoom = "Outside";	
			} else if (Input.GetKeyDown (KeyCode.S) && hasWeapon == false) {
				currentRoom = "A Corner";	
			} else if (Input.GetKeyDown (KeyCode.S) && hasWeapon) {
				textBuffer += "\nStop looking for more weapons you can't carry them.";
				textBuffer += "\nPress [Q] to go back (maybe that's not the best idea.)";
				if (Input.GetKeyDown (KeyCode.Q)) {
					currentRoom = "A Hallway";
				} 
			}
		} else if (currentRoom == "A Dark Room") {
			if (hasWeapon == false) {
				textBuffer += "\nYou are eaten by a zombie.";
				textBuffer += "\nPress [Q] to try again.";
				if (Input.GetKeyDown (KeyCode.Q)) {
					currentRoom = "A Hallway";
				} 
			} else {
				hasKey = true;
				textBuffer += "\nYou killed a zombie!";
				textBuffer += "\nAnd look, you found a key.";
				textBuffer += "\nPress [Q] to head back.";
				if (Input.GetKeyDown (KeyCode.Q)) {
					currentRoom = "A Hallway";
				}
			}
		} else if (currentRoom == "A Corner") {
			textBuffer += "\nWhat's that pointy thing in the closet?";
			textBuffer += "\npress [W] to find out.";
			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "A Closet";
			}
			textBuffer += "\npress [Q] to go back.";
			if (Input.GetKeyDown (KeyCode.Q)) {
				currentRoom = "A Hallway";
			}	
		} else if (currentRoom == "A Closet") {
			hasWeapon = true;
			textBuffer += "\nYou found a chainsaw!";
			textBuffer += "\nWhat about that sound from the Hallway?";
			textBuffer += "\nPress [Q] to go back";
			if (Input.GetKeyDown (KeyCode.Q)) {
				currentRoom = "A Hallway";
			} 
		} else if (currentRoom == "The Hallway in Front of the Door") {
			textBuffer += "\nIts Locked!!";
			textBuffer += "\nPress [Q] to go back";
			if (Input.GetKeyDown (KeyCode.Q)) {
				currentRoom = "A Hallway";
			}
		} else if (currentRoom == "Outside") { //Win Condition
			textBuffer += "\nYou're Safe!";
		}
		GetComponent<Text> ().text = textBuffer;
	}
}
