using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetSortingLayerToY : MonoBehaviour {

	public float offset = 0.00f;

	// Use this for initialization
	void Start () {
	


	}

	void Update() {

		SetSortingLayer ();

	}


	void SetSortingLayer() {

		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y + offset);

	}
}
