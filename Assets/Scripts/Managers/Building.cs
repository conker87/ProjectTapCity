using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Building : MonoBehaviour {

	// levelToHitConstant is usually level 100, but this one will be changed to 50;

	public string startingAmount = "1";
	public int buildingLevel = 0, levelToHitConstant = 50;
	public float startingTime = 4f;
	[SerializeField]
	float currentTime, previousTime;

	[SerializeField]
	float time, currentTimedotTime, timeRemaining;

	[SerializeField]
	string currentAmount = "", previousAmount = "";

	int[] currentAmount_Array = new int[100];

	public Transform timerForeground;
	public Text timerText;

	// Use this for initialization
	void Start () {

		foreach (Transform go in GetComponentsInChildren<Transform>()) {

			if (go.name == "ForegroundParent") {

				timerForeground = go;

			}

//			if (go.name == "go") {
//
//				timerText = go.GetComponent<Text> ();
//
//			}

		}

		currentAmount = startingAmount;
		currentAmount_Array = CashManager.CashPerSecondToArray (currentAmount);

		time = Time.time + startingTime;

		// this will need changing so that it figures it out through equations.
		currentTime = startingTime;
		previousTime = currentTime;

	}

	void FixedUpdate () {
	


	}

	void Update() {
		
		currentTimedotTime = Time.time;
		timeRemaining = (Time.time / time);
		Cash ();

	}

	void Cash() {

		if (buildingLevel == 0) {

			return;

		}

		if (currentAmount != previousAmount) {

			currentAmount_Array = CashManager.CashPerSecondToArray (currentAmount);
			previousAmount = currentAmount;

		}

		if (currentTime != previousTime) {

			time = Time.time;

		}

		if (Time.time > time) {

			CashManager.AddCashPerSecondToTotalCash (currentAmount_Array, CashManager.instance.TotalCash);
			previousTime = currentTime;
			time = Time.time + currentTime;

		}

		TimerUI (timerForeground, timerText);

	}

	void TimerUI(Transform _timerForegroundUI, Text _timerText) {

		if (timerForeground == null) {

			return;

		}

		//_timerText.text = CashManager.CashArrayToString (currentAmount_Array);

		float percentageClamped = Mathf.Clamp01 ((time - Time.time) / currentTime);
		Vector3 percentageScale = new Vector3 (1f - percentageClamped, 1, 1);

		_timerForegroundUI.transform.localScale = percentageScale;

	}

}
