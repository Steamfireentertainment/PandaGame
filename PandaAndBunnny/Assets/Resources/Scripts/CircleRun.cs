using UnityEngine; // Imports UnityEngine library.
using System.Collections; // Imports System.Collections Library.

public class CircleRun : MonoBehaviour {


	void Update () {// Update is called once per frame
		transform.Translate(0,0,0.1f); // moves the object 0.1 on the z axis.
		transform.Rotate(0,1,0); // rotates the object by 1 on the y axis.
	}
}
