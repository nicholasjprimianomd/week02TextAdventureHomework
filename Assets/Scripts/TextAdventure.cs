using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Security.Policy;

public class TextAdventure : MonoBehaviour
{

	string currentRoom = "Lobby";

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		string textBuffer = "You are currently in: " + currentRoom;
		bool hasStudentID = false;

		if (currentRoom == "Lobby") {
			textBuffer += "\nYou see the security gaurd.";
			textBuffer += "\nPress [W] to go to the elevators";
			textBuffer += "\nPress [S] to go outside.";
			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "Elevators";
			} else if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "Outside";	
			}
		} else if (currentRoom == "Elevators") {
			textBuffer += "\nYou are waiting";
			if (hasStudentID == false) {
				textBuffer += "\nYou can't go in without your ID car, though...";
			} else {
				textBuffer += "\nYou swipe your student ID and the gaur smiles.";
			}
			//TODO: add choice to take elevator up to the classroom?
		} else if (currentRoom == "Outside") {
			textBuffer += "\nIT IS REALY HOT WHAT IS WRONG WITH YOU";
			textBuffer += "\npress [S] to go back INSIDE,LIKE RIGHT NOW";
			textBuffer += "\n(oh hey you found your student IF on the floor!)";
			hasStudentID = true;
			if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "Lobby";
			}
		}
		GetComponent<Text> ().text = textBuffer;

	}
}
