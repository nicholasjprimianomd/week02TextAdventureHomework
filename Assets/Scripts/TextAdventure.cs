using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Security.Policy;

public class TextAdventure : MonoBehaviour
{

	string currentRoom = "roomNoise";
	bool hasWeapon = false;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		string textBuffer = "You are currently in: " + currentRoom;


		if (currentRoom == "roomNoise") {
			textBuffer += "\nYou hear a strange noise.";
			textBuffer += "\nPress [W] to investigate.";
			textBuffer += "\nPress [S] to look for a weapon.";
			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "roomInvestigate";
			} else if (Input.GetKeyDown (KeyCode.S) && hasWeapon == false) {
				currentRoom = "roomWeapon";	
			} else if (Input.GetKeyDown (KeyCode.S) && hasWeapon) {
				textBuffer += "\nStop looking for more weapons you can't carry them.";
				textBuffer += "\nPress [Q] to go back";
				if (Input.GetKeyDown (KeyCode.Q)) {
					currentRoom = "roomNoise";
				} 
			}
		} else if (currentRoom == "roomInvestigate") {
			if (hasWeapon == false) {
				textBuffer += "\nYou are eaten by a zombie.";
				textBuffer += "\nPress [Q] to try again.";
				if (Input.GetKeyDown (KeyCode.Q)) {
					currentRoom = "roomNoise";
				} 
			} else {
				textBuffer += "\nYou killed the zombie!";
				textBuffer += "\nPress [Q] to kill it again.";
				if (Input.GetKeyDown (KeyCode.Q)) {
					currentRoom = "roomNoise";
				}
			}
		} else if (currentRoom == "roomWeapon") {
			textBuffer += "\nWhat's that pointy thing over there?";
			textBuffer += "\npress [W] to find out.";
			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "roomChainsaw";
			}
			textBuffer += "\npress [Q] to go back.";
			if (Input.GetKeyDown (KeyCode.Q)) {
				currentRoom = "roomNoise";
			}	
		} else if (currentRoom == "roomChainsaw") {
			hasWeapon = true;
			textBuffer += "\nYou found a chainsaw!";
			textBuffer += "\nPress [Q] to go back";
			if (Input.GetKeyDown (KeyCode.Q)) {
				currentRoom = "roomNoise";
			} 	
		}
		GetComponent<Text> ().text = textBuffer;
	}
}
