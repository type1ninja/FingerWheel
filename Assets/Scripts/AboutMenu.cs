using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AboutMenu : MonoBehaviour {

	GameObject AboutPanel;

	Text aboutTextObject;

	string aboutText = "A diabetic needs to draw blood in order to get a blood glucose reading. " +
		"This reading is necessary to determine the proper insulin dosage at any given time. " +
		"In order to help preserve one's fingers, it is important to test more or less evenly, but " + 
		"it is quite difficult to test in a truly random fashion, which is where this utility comes in. " +
		"Basically, Finger Wheel is a tool that allows a user to keep track of their last tested finger. " +
		"There is also a set of options allowing the user to disable certain fingers in case they can't " +
		"use them for any reason. The name \"Finger Wheel\" comes from the original, physical prototype, " + 
		"which was in the shape of a wheel. It would spin to advance. ";

	void Start() {
		aboutTextObject =   GameObject.Find ("AboutText").GetComponent<Text>();
		aboutTextObject.text = aboutText;

		AboutPanel = GameObject.Find ("AboutPanel");

		AboutPanel.SetActive (false);
	}

	public void CloseAboutMenu() {
		AboutPanel.SetActive (false);
	}

	public void OpenAboutMenu() {
		AboutPanel.SetActive (true);
	}

	//I'm just taping this function in here because I don't want to bother with another script. 
	public void CloseApp() {
		Application.Quit ();
	}
}