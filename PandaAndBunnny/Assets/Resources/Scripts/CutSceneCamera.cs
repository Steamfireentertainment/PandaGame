using UnityEngine; // Imports UnityEngine library.
using System.Collections; // Imports System.Collections Library.

public class CutSceneCamera : MonoBehaviour {

	public Transform[] path; // Array Transform varible called path which the camera will follow.
	public int currenttarget = 0; // Iteger variable currentTarget by default set to 0;

	GameObject Canvas; // Gameobject Canvas to be defined [Canvas object].
	GameObject cam; // Gameobject cam to be defined [Player camera].

	void Start () // Use this for initialization
	{
		Canvas = GameObject.Find("Canvas"); // Sets the Canvas varible to be the Canvas in the scene which if its found.
	    Canvas.SetActive(false); //Disabled the Canvas object.
		cam = GameObject.Find("Main Camera");// Sets the cam varible to be the "Main Camera" in the scene which if its found.
		cam.SetActive(false);// Disables the cam object.
	}

	void Update () // Update is called once per frame
	{
		if(transform.position != path[currenttarget].position && transform.rotation != path[currenttarget].rotation ) // checks to see if the transform is not set to the position and rotation of the currenttarget on the path.
		{
			transform.rotation = Quaternion.Lerp(transform.rotation,path[currenttarget].localRotation, Time.deltaTime); // sets the transforms rotation the transform to match the localrotation but lerped so it only moves slightly.
			transform.position = Vector3.MoveTowards(transform.position,path[currenttarget].position,Time.deltaTime * 15);//transform.Translate(path[currenttarget].position * Time.deltaTime); // sets the transforms position the transform to match the position of the target but lerped so it only moves slightly.
		}
		else
		{
			if(currenttarget != path.Length -1 )// checks to see if the path length is not equal to -1.
			{
				currenttarget++; // Adds one to the currenttarget [E.g. target goes from 0 to 1 in the list].
			}
			else
			{
				Canvas.SetActive(true); // enables the Canvas object.
				cam.SetActive(true); // Enables the cam object.
				Destroy(gameObject); // Destroys the Object the script is attached to.
			}
		}
	}

	void OnDrawGizmos() // Function that is used in the editor to display Fake Gizmos.
	{
		for(int i =0; i< path.Length; i++) // Loops and increments i by 1 until it matches path.Length.
		{
			Gizmos.color = Color.white; // Sets the Gizmos colour to white.
			Gizmos.DrawSphere(path[i].position,1f); // Draws a Gizmo sphere at the position of the path[i] with a scale of 1. 
			Gizmos.color = Color.red;// Sets the Gizmos colour to Red.
			if(path[i] != path[path.Length -1]){ // checks to make sure the point isnt the last in the path array.
			Gizmos.DrawLine(path[i].position, path[i + 1].position); // Draws a Line between points in the array.
			}else{
				Gizmos.DrawLine(path[i].position, path[0].position);// Draws a line between the end and beginning of the path.
			}
		}

	}
}
