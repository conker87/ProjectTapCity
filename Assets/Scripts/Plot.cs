using UnityEngine;
using System.Collections;

public class Plot : MonoBehaviour {

	[SerializeField]
	Vector3 plotLocation;

	// Use this for initialization
	void Start () {
	
		plotLocation = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
