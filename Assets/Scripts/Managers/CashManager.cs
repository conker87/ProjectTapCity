using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CashManager : MonoBehaviour {

	public static CashManager instance = null;

	public Text TotalCashText;

	[SerializeField]
	sbyte[] totalCash = new sbyte[100];
	public sbyte[] TotalCash { get { return totalCash; } set { totalCash = value; } }

	sbyte[] castPerSecond_Array = new sbyte[100];

	void Start () {

		Singleton ();

	}

	void Update () {

		TotalCashText.text = CashArrayToString (TotalCash);

	}

	public static void AddCashPerSecondToTotalCash(sbyte[] _cashPerSecond_Array, sbyte[] _totalCash_Array) {

		int _cashPerSecondLength = FindLengthOffloatArrayWithoutTrailingZeros (_cashPerSecond_Array);
		sbyte[] temp_TC = new sbyte[100];
		temp_TC = _totalCash_Array;

		for (int i = 0; i < _cashPerSecondLength; i++) {

			temp_TC [i] += _cashPerSecond_Array [i];

		}

		_totalCash_Array = CashManager.instance.SortOutTotalCashDuringAdding (temp_TC);
			
	}

	sbyte[] SortOutTotalCashDuringAdding(sbyte[] _totalCash) {

		sbyte[] temp = new sbyte[100];
		temp = _totalCash;
		int _totalCashLength = FindLengthOffloatArrayWithoutTrailingZeros (temp);


		for (int i = 0; i < _totalCashLength; i++) {

			while (temp [i] >= 10) {

				temp [i] =- 10;
				temp [i + 1]++;

				if (temp [i] < 0) {

					temp [i] = 0;

				}

			}

		}

		return temp;

	}

	#region Utils
	public static sbyte[] CashPerSecondToArray(int _cashPerSecond) {

		return CashPerSecondToArray (_cashPerSecond.ToString ());

	}
	public static sbyte[] CashPerSecondToArray(string _cashPerSecond) {

		sbyte[] cashPerSecond_Temp = new sbyte[100];
		string cashTemp;

		cashTemp = _cashPerSecond.ToString ();

		// Remove decimals
		int index = cashTemp.IndexOf(".");
		if (index > 0) {
			cashTemp = cashTemp.Substring (0, index); // or index + 1 to keep slas
		}

		int j = 0;

		for (int i = cashTemp.Length - 1; i >= 0; i--) {

			cashPerSecond_Temp [i] = sbyte.Parse (cashTemp [j].ToString ());
			j++;

		}

		return cashPerSecond_Temp;

	}

	public static int FindLengthOffloatArrayWithoutTrailingZeros(sbyte[] _getLength) {

		bool hasHitNotZero = false;
		int temp = 0;

		for (int i = _getLength.Length - 1; i >= 0; i--) {

			if (_getLength [i] != 0) {

				hasHitNotZero = true;

			}

			if (hasHitNotZero) {

				temp++;

			}

		}

		return temp;

	}

	public static string CashArrayToString(sbyte[] _cashArray) {

		if (_cashArray == null) {

			return "-- CASH ARRAY NULL. -- FATAL ERROR";

		}

		string temp;

		temp = "$";
		int _totalCashLength = FindLengthOffloatArrayWithoutTrailingZeros(_cashArray);

		for (int i = _totalCashLength - 1; i >= 0 ; i--) {

			temp += _cashArray [i].ToString ();

		}

		return temp;

	}
	#endregion

	void Singleton() {

		if (instance == null) {

			instance = this;

		} else if (instance != this) {

			Destroy (this);

		}

		DontDestroyOnLoad (gameObject);

	}

}
