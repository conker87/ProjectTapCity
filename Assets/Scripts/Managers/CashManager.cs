using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CashManager : MonoBehaviour {

	public static CashManager instance = null;

	public Text TotalCashText;

	[SerializeField]
	int[] totalCash = new int[100];
	public int[] TotalCash { get { return totalCash; } set { totalCash = value; } }

	//int[] previousCashPerSecond = -1;
	int[] castPerSecond_Array = new int[100];

	void Start () {

		Singleton ();

	}

	void Update () {

			//AddCashPerSecondToTotalCash (castPerSecond_Array, totalCash);

		DisplayCashPerSecond (TotalCashText, TotalCash);

	}

	public static void AddCashPerSecondToTotalCash(int[] _cashPerSecond_Array, int[] _totalCash_Array) {

		int _cashPerSecondLength = FindLengthOffloatArrayWithoutTrailingZeros (_cashPerSecond_Array);
		int[] temp_TC = new int[100];
		temp_TC = _totalCash_Array;

		for (int i = 0; i < _cashPerSecondLength; i++) {

			temp_TC [i] += _cashPerSecond_Array [i];

		}

		_totalCash_Array = CashManager.instance.SortOutTotalCashDuringAdding (temp_TC);
			
	}

	int[] SortOutTotalCashDuringAdding(int[] _totalCash) {

		int[] temp = new int[100];
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
	public static int[] CashPerSecondToArray(int _cashPerSecond) {

		return CashPerSecondToArray (_cashPerSecond.ToString ());

	}
	public static int[] CashPerSecondToArray(string _cashPerSecond) {

		int[] cashPerSecond_Temp = new int[100];
		string cashTemp;

		cashTemp = _cashPerSecond.ToString ();

		// Remove decimals
		int index = cashTemp.IndexOf(".");
		if (index > 0) {
			cashTemp = cashTemp.Substring (0, index); // or index + 1 to keep slas
		}

		int j = 0;

		for (int i = cashTemp.Length - 1; i >= 0; i--) {

			cashPerSecond_Temp [i] = int.Parse (cashTemp [j].ToString ());
			j++;

		}

		return cashPerSecond_Temp;

	}

	public static int FindLengthOffloatArrayWithoutTrailingZeros(int[] _getLength) {

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

	public void DisplayCashPerSecond(Text _totalCashText, int[] _totalCash) {

		if (_totalCashText == null) {

			return;

		}

		_totalCashText.text = "$";
		int _totalCashLength = FindLengthOffloatArrayWithoutTrailingZeros(_totalCash);

		for (int i = _totalCashLength - 1; i >= 0 ; i--) {

			_totalCashText.text += _totalCash [i].ToString ();

		}

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
