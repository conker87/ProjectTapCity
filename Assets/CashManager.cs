using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CashManager : MonoBehaviour {

	public Text TotalCashText;

	float[] totalCash = new float[100];

	float cashPerSecond = 999999999999999f;
	float previousCashPerSecond = -1;
	float[] castPerSecond_Array = new float[100];

	float time;

	void Start () {
	
		time = Time.fixedTime + 1f;

	}

	void FixedUpdate () {

		if (Time.fixedTime > time) {

			if (cashPerSecond != previousCashPerSecond) {

				castPerSecond_Array = null;
				castPerSecond_Array = CashPerSecondToArray (cashPerSecond);

			}

			AddCashPerSecondToTotalCash (castPerSecond_Array, totalCash);

			DisplayCashPerSecond (TotalCashText, totalCash);

			previousCashPerSecond = cashPerSecond;

			time = Time.fixedTime + 1f;
		}



	}


	void AddCashPerSecondToTotalCash(float[] _cashPerSecond_Array, float[] _totalCash_Array) {

		float _cashPerSecondLength = FindLengthOffloatArrayWithoutTrailingZeros (_cashPerSecond_Array);
		float[] temp_TC = new float[100];
		temp_TC = _totalCash_Array;

		for (int i = 0; i < _cashPerSecondLength; i++) {

			temp_TC [i] += _cashPerSecond_Array [i];

		}

		_totalCash_Array = SortOutTotalCashDuringAdding (temp_TC);
			
	}

	float[] SortOutTotalCashDuringAdding(float[] _totalCash) {

		float[] temp = new float[100];
		temp = _totalCash;
		float _totalCashLength = FindLengthOffloatArrayWithoutTrailingZeros (temp);


		for (int i = 0; i < _totalCashLength; i++) {

			while (temp [i] >= 10f) {

				temp [i] =- 10f;
				temp [i + 1]++;

				if (temp [i] < 0f) {

					temp [i] = 0f;

				}

			}

		}

		return temp;

	}

	#region Utils
	float[] CashPerSecondToArray(float _cashPerSecond) {

		float[] cashPerSecond_Temp = new float[100];
		string cashTemp;

		cashTemp = _cashPerSecond.ToString ();

		// Remove decimals
		int index = cashTemp.IndexOf(".");
		if (index > 0) {
			cashTemp = cashTemp.Substring (0, index); // or index + 1 to keep slas
		}

		int j = 0;

		for (int i = cashTemp.Length - 1; i >= 0; i--) {

			cashPerSecond_Temp [i] = float.Parse (cashTemp [j].ToString ());
			j++;

		}

		return cashPerSecond_Temp;

	}

	int FindLengthOffloatArrayWithoutTrailingZeros(float[] _getLength) {

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

	public void DisplayCashPerSecond(Text _totalCashText, float[] _totalCash) {

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

}
