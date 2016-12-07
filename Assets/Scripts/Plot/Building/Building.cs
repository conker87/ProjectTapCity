using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Building : Plot {

	// levelToHitConstant is usually level 100, but this one will be changed to 50;

	/// To get the currentAmount, the baseAmount is multiplied by a set float amount, set per building
	/// type. To them make it harder, each type of building (Bank, Store, etc) on the map then multiplies this
	/// base number further. More and more of the same type increases the net profit for each of that
	/// type but also drastically increases the purchase cost.

	public float minimumProgressTime = 0.02f, minimumProgressTimeCooldown;

	public string basePurchaseAmount = "5";
	public float purchaseMultiplierPerLevel = 2f, purchaseMultiplierPerType = 5f;

	public string startingAmount = "1";
	public int buildingLevel = 0, levelToHitConstant = 50;
	public float startingTime = 4f;
	[SerializeField]
	float currentProgressTime, previousProgressTime;

	[SerializeField]
	float time, currentTimeDotTime, timeRemaining;

	[SerializeField]
	string currentAmount = "", previousAmount = "";

	sbyte[] currentAmount_Array = new sbyte[100];

	public Transform timerForeground;
	public Text timerText;

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

		if (buildingLevel == 0) {

			// this will need changing so that it figures it out through equations.
			currentProgressTime = startingTime;
			previousProgressTime = currentProgressTime;

		} else {

			// currentTime = LoadFromTile("currentTime");
			// previousTime = currentTime;

		}

	}

	void FixedUpdate () {

	}

	void Update() {
		
		currentTimeDotTime = Time.time;
		timeRemaining = time - currentTimeDotTime;

		if (Time.time > minimumProgressTimeCooldown) {
		
			Cash ();
			minimumProgressTimeCooldown = Time.time + minimumProgressTime;

		}

	}

	void Cash() {

		if (buildingLevel == 0) {

			return;

		}

		if (currentAmount != previousAmount) {

			currentAmount_Array = CashManager.CashPerSecondToArray (currentAmount);
			previousAmount = currentAmount;

		}

		if (currentProgressTime != previousProgressTime) {

			time = Time.time;
			previousProgressTime = currentProgressTime;

		}

		if (Time.time > time) {

			CashManager.AddCashPerSecondToTotalCash (currentAmount_Array, CashManager.instance.TotalCash);
			time = Time.time + currentProgressTime;

		}

		TimerUI (timerForeground, timerText);

	}

	void TimerUI(Transform _timerForegroundUI, Text _timerText) {

		if (timerForeground == null) {

			return;

		}

		//_timerText.text = CashManager.CashArrayToString (currentAmount_Array);

		float percentageClamped;
		Vector3 percentageScale;

		if (currentProgressTime < 1f) {

			percentageClamped = 0f;

		} else {

			percentageClamped = Mathf.Clamp01 ((time - Time.time) / currentProgressTime);


		}

		percentageScale = new Vector3 (1f - percentageClamped, 1, 1);
		_timerForegroundUI.transform.localScale = percentageScale;

	}

}
