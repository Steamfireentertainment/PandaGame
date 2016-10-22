using UnityEngine; // Imports UnityEngine library.
using System.Collections; // Imports System.Collections Library.

public class VaseBreak : MonoBehaviour {

	public void Break() // Standard function called Break
	{
		Instantiate(Resources.Load("Prefabs/VaseBreak"),transform.position, Quaternion.Euler(0,0,0)); // Creates a new Gamobject in the same position at the gameobject the script is attached to from the resources folder.
		Destroy(gameObject); // Destroys the gameObject;
	}
}
