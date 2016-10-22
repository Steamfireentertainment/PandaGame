using UnityEngine; // Imports UnityEngine library.
using System.Collections; // Imports System.Collections Library.

public class UVScroll : MonoBehaviour {
	
	public float scrollSpeed = 0.5F; // Float variable scrollSpeed.
	public Renderer rend; // Renderer variable rend.

	void Start() // Called at the start of a level.
	{
		rend = GetComponent<Renderer>(); // setting Renderer variable "Rend" to the renderer attached to the object the script is on.
	}
	void Update() // Called once per frame.
	{ 
		float offset = Time.time * scrollSpeed; // Float varible Offset updated once per frame with time increased multiplied by the variable scrollSpeed;  
		rend.materials[1].SetTextureOffset("_MainTex", new Vector2(offset, offset /2)); // Updates the 2nd material on a mesh to update its textureoffset so it moves. 
	}
}