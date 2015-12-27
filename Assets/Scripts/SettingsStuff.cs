using UnityEngine;

//TODO: Quit Button. *facepalm*
public class SettingsStuff : MonoBehaviour {

	public Advancer adv;

	public GameObject[] leftChecks = new GameObject[5];
	public GameObject[] leftXs = new GameObject[5];
	public GameObject[] rightChecks = new GameObject[5];
	public GameObject[] rightXs = new GameObject[5];

	// Use this for initialization
	void Start () {
		adv = GameObject.Find ("_GlobalScripts").GetComponent<Advancer> ();

		leftChecks [0] = GameObject.Find ("LCheck");
		leftChecks [1] = GameObject.Find ("LCheck (1)");
		leftChecks [2] = GameObject.Find ("LCheck (2)");
		leftChecks [3] = GameObject.Find ("LCheck (3)");
		leftChecks [4] = GameObject.Find ("LCheck (4)");

		leftXs [0] = GameObject.Find ("LX");
		leftXs [1] = GameObject.Find ("LX (1)");
		leftXs [2] = GameObject.Find ("LX (2)");
		leftXs [3] = GameObject.Find ("LX (3)");
		leftXs [4] = GameObject.Find ("LX (4)");

		//Right hand stuff is reversed because the ordering is weird
		rightChecks [0] = GameObject.Find ("RCheck (4)");
		rightChecks [1] = GameObject.Find ("RCheck (3)");
		rightChecks [2] = GameObject.Find ("RCheck (2)");
		rightChecks [3] = GameObject.Find ("RCheck (1)");
		rightChecks [4] = GameObject.Find ("RCheck");

		rightXs [0] = GameObject.Find ("RX (4)");
		rightXs [1] = GameObject.Find ("RX (3)");
		rightXs [2] = GameObject.Find ("RX (2)");
		rightXs [3] = GameObject.Find ("RX (1)");
		rightXs [4] = GameObject.Find ("RX");
	}

	//Update the symbols each frame
	void Update () {
		for (int i = 0; i < 5; i++) {
			leftChecks [i].SetActive (!adv.disabledIndexes [i]);
			leftXs [i].SetActive (adv.disabledIndexes [i]);
		}
		for (int i = 0; i < 5; i++) {
			rightChecks[i].SetActive (!adv.disabledIndexes[i + 5]);
			rightXs[i].SetActive (adv.disabledIndexes[i + 5]);
		}
	}

	public void ToggleIndex(int index) {
		adv.disabledIndexes [index] = !adv.disabledIndexes [index];
	}
}