using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetSortingLayerToY : MonoBehaviour {

	SpriteRenderer sp;
	public float offset = 0.00f;

	// Use this for initialization
	void Start () {
	
		sp = GetComponent<SpriteRenderer> ();

	}

	void Update() {

		SetSortingLayer ();

	}


	void SetSortingLayer() {

		//sp.sortingOrder = -Mathf.RoundToInt(transform.position.y);

		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y + offset);

	}
}
