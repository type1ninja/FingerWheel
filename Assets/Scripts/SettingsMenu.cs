using UnityEngine;

public class SettingsMenu : MonoBehaviour {

	public GameObject settingsPanel;
	public GameObject cantQuitText;
	public Advancer adv;

	int numOfDisabledIndexes = 0;

	void Start() {
		//Disabled by default
		cantQuitText = GameObject.Find ("CantQuit");
		cantQuitText.SetActive (false);
		adv = GameObject.Find ("_GlobalScripts").GetComponent<Advancer> ();
		settingsPanel.SetActive (false);
	}

	public void OpenSettings() {
		settingsPanel.SetActive (true);
	}

	public void CloseSettings() {
		//If the user has everything disabled, don't let them quit
		numOfDisabledIndexes = 0;
		for (int i = 0; i < 10; i++) {
			if (adv.disabledIndexes[i] == true) {
				numOfDisabledIndexes++;
			}
		}

		if (numOfDisabledIndexes == 10) {
			cantQuitText.SetActive (true);
		} else {
			cantQuitText.SetActive (false);
			settingsPanel.SetActive (false);
			adv.advance (-1);
			adv.advance (1);
		}
	}
}