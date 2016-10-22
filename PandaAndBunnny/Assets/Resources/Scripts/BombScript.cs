using UnityEngine; // Imports UnityEngine library.
using System.Collections; // Imports System.Collections Library.

public class BombScript : MonoBehaviour {


	void OnTriggerEnter(Collider col)// Gets called when something enters the Collider on the object the script is attached to.
	{
		Debug.Log("Collision"); // Outputs "Collision" to the Log as a developer Message to confirm the code has run.
		StartCoroutine(Explode()); // Starts a Coroutine of the IEnumerator (type of function) "Explode".
	}

	IEnumerator Explode(){
		transform.GetChild(1).GetComponent<MeshRenderer>().materials[0].color = Color.red; //Sets the first material to Red of the 2nd child of the gamobject the script is attached to.
		yield return new WaitForSeconds(0.1f); // Makes the script wait 0.1 secconds before progressing .. works like a Thread.Sleep function.
		transform.GetChild(1).GetComponent<MeshRenderer>().materials[0].color = Color.black;//Sets the first material to Black of the 2nd child of the gamobject the script is attached to.
		yield return new WaitForSeconds(0.1f);// Makes the script wait 0.1 secconds before progressing .. works like a Thread.Sleep function.
		transform.GetChild(1).GetComponent<MeshRenderer>().materials[0].color = Color.red;//Sets the first material to Red of the 2nd child of the gamobject the script is attached to.
		yield return new WaitForSeconds(0.1f);// Makes the script wait 0.1 secconds before progressing .. works like a Thread.Sleep function.
		transform.GetChild(1).GetComponent<MeshRenderer>().materials[0].color = Color.black;//Sets the first material to Black of the 2nd child of the gamobject the script is attached to.
		yield return new WaitForSeconds(0.1f);// Makes the script wait 0.1 secconds before progressing .. works like a Thread.Sleep function.
		transform.GetChild(1).GetComponent<MeshRenderer>().materials[0].color = Color.red;//Sets the first material to Red of the 2nd child of the gamobject the script is attached to.
		yield return new WaitForSeconds(0.1f);// Makes the script wait 0.1 secconds before progressing .. works like a Thread.Sleep function.
		transform.GetChild(1).GetComponent<MeshRenderer>().materials[0].color = Color.black;//Sets the first material to Black of the 2nd child of the gamobject the script is attached to.
		yield return new WaitForSeconds(0.1f);// Makes the script wait 0.1 secconds before progressing .. works like a Thread.Sleep function.
		transform.GetChild(1).GetComponent<MeshRenderer>().materials[0].color = Color.red;//Sets the first material to Red of the 2nd child of the gamobject the script is attached to.
		yield return new WaitForSeconds(0.1f);// Makes the script wait 0.1 secconds before progressing .. works like a Thread.Sleep function.
		transform.GetChild(1).GetComponent<MeshRenderer>().materials[0].color = Color.black;//Sets the first material to Black of the 2nd child of the gamobject the script is attached to.
		yield return new WaitForSeconds(0.1f);// Makes the script wait 0.1 secconds before progressing .. works like a Thread.Sleep function.
		transform.GetChild(1).GetComponent<MeshRenderer>().materials[0].color = Color.red;//Sets the first material to Red of the 2nd child of the gamobject the script is attached to.
		yield return new WaitForSeconds(0.1f);// Makes the script wait 0.1 secconds before progressing .. works like a Thread.Sleep function.

		transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false; // Disables the MeshRenderer attached to the 2nd child object of the Transform.
		transform.GetChild(0).gameObject.SetActive(true); // Sets the first child object of the transform to be visible;
		GetComponent<ExplosionTest>().Explode(); // Gets the script ExplosionTest and calls the Explode function.

		yield return new WaitForSeconds(3f);// Makes the script wait 3 secconds before progressing .. works like a Thread.Sleep function.
		Destroy(this.gameObject);// Destroys the GameObject.
	}
}
