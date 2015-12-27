using UnityEngine;
using UnityEngine.UI;

public class Advancer : MonoBehaviour {
	//A pair of parallel arrays. These represent the coordinates of each index of the highlight.
	static int[] xCoords = {-270, -234, -157, -83, -32, 32, 83, 157, 234, 270};
	static int[] yCoords = {-32, 85, 118, 101, 42, 42, 101, 118, 85, -32};

	public GameObject[] disabledImgs = new GameObject[10];
	public GameObject highlight;
	public Text indicatorText;

	public bool[] disabledIndexes = new bool[10];
	public int index = 0;
	//A count to keep track of when you should autosave settings. 
	int autosaveTickCount = 0;

	void Start() {

		//Get saved index
		index = PlayerPrefs.GetInt ("Index", 0);
		//Get saved settings - 0 for false, 1 for true
		for (int i = 0; i < 10; i++) {
			if (PlayerPrefs.GetInt ("DisabledIndexes" + i, 0) == 1) {
				disabledIndexes[i] = true;
			} else {
				disabledIndexes[i] = false;
			}
		}
		
		disabledImgs [0] = GameObject.Find ("Disabled");
		disabledImgs [1] = GameObject.Find ("Disabled (1)");
		disabledImgs [2] = GameObject.Find ("Disabled (2)");
		disabledImgs [3] = GameObject.Find ("Disabled (3)");
		disabledImgs [4] = GameObject.Find ("Disabled (4)");
		disabledImgs [5] = GameObject.Find ("Disabled (5)");
		disabledImgs [6] = GameObject.Find ("Disabled (6)");
		disabledImgs [7] = GameObject.Find ("Disabled (7)");
		disabledImgs [8] = GameObject.Find ("Disabled (8)");
		disabledImgs [9] = GameObject.Find ("Disabled (9)");

		indicatorText = GameObject.Find ("Indicator").GetComponent<Text>();

		//TODO - this just resets the highlight. Replace this with loading from a save.
		advance (-1);
		advance (1);
	}

	void OnApplicationQuit() {
		//Save current index
		PlayerPrefs.SetInt ("Index", index);
		//Save settings - 0 for false, 1 for true
		for (int i = 0; i < 10; i++) {
			if (disabledIndexes[i]) {
				PlayerPrefs.SetInt ("DisabledIndexes" + i, 1);
			} else {
				PlayerPrefs.SetInt ("DisabledIndexes" + i, 0);
			}
		}
	}
	
	void Update() {
		for (int i = 0; i < 10; i++) {
			disabledImgs[i].SetActive (disabledIndexes[i]);
		}

		switch (index) {
		case 0:
			indicatorText.text = "Left Thumb";
			break;
		case 1:
			indicatorText.text = "Left Index Finger";
			break;
		case 2:
			indicatorText.text = "Left Middle Finger";
			break;
		case 3:
			indicatorText.text = "Left Ring Finger";
			break;
		case 4:
			indicatorText.text = "Left Little Finger";
			break;
		case 5:
			indicatorText.text = "Right Little Finger";
			break;
		case 6:
			indicatorText.text = "Right Ring Finger";
			break;
		case 7:
			indicatorText.text = "Right Middle Finger";
			break;
		case 8:
			indicatorText.text = "Right Index Finger";
			break;
		case 9:
			indicatorText.text = "Right Thumb";
			break;
		}

		autosaveTickCount++;
		if (autosaveTickCount >= 100) {
			//Save current index
			PlayerPrefs.SetInt ("Index", index);
			//Save settings - 0 for false, 1 for true
			for (int i = 0; i < 10; i++) {
				if (disabledIndexes[i]) {
					PlayerPrefs.SetInt ("DisabledIndexes" + i, 1);
				} else {
					PlayerPrefs.SetInt ("DisabledIndexes" + i, 0);
				}
			}

			autosaveTickCount = 0;
		}
	}

	//Step should be either 1 or -1
	public void advance(int step) {
		if (step != 1 && step != -1 && step != 0) {
			Debug.LogWarningFormat ("The 'step' value for advancing the counter is neither 1 nor 0 nor -1. This is not intended behaviour");
		}

		index += step;
		if (index >= 10) {
			index = 0;
		}
		if (index <= -1) {
			index = 9;
		}
		while (disabledIndexes[index] == true) {
			index += step;
			if (index >= 10) {
				index = 0;
			}
			if (index <= -1) {
				index = 9;
			}
		}

		highlight.transform.localPosition = Vector3.MoveTowards (highlight.transform.position, new Vector3(xCoords[index], yCoords[index], 0), int.MaxValue);
	}
}