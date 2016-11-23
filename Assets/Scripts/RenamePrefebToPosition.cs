using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RenamePrefebToPosition : MonoBehaviour {

	string originalName;
	string newName;

	void Start () {

		originalName = gameObject.name;

		int index = originalName.IndexOf(" (");
		if (index > 0) {
			
			newName = originalName.Substring (0, index).Trim(); // or index + 1 to keep slas

		} else {

			newName = originalName.Trim();

		}
			
		newName += " (" + transform.position.x + "," + transform.position.y + "," + transform.position.z + ")";

		gameObject.name = newName;

	}

}
