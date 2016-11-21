using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	// levelToHitConstant is usually level 100, but this one will be changed to 50;

	const string startingAmount = "1";
	public int buildingLevel = 0, levelToHitConstant = 50;
	float startingTime = 4f, currentTime;
	[SerializeField]
	float time;

	string currentAmount = "", previousAmount = "";

	int[] currentAmount_Array = new int[100];

	// Use this for initialization
	void Start () {
	
		currentAmount_Array = CashManager.CashPerSecondToArray (currentAmount);

		currentAmount = startingAmount;

		time = Time.time + startingTime;

		// this will need changing so that it figures it out through equations.
		currentTime = startingTime;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (buildingLevel == 0) {

			return;

		}

		// Check building level and set new amount

		if (currentAmount != previousAmount) {

			currentAmount_Array = CashManager.CashPerSecondToArray (currentAmount);

		}

		if (Time.time > time) {

			CashManager.AddCashPerSecondToTotalCash (currentAmount_Array, CashManager.instance.TotalCash);
			time = Time.time + currentTime;

		}

	}

}
