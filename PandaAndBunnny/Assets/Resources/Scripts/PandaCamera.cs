using UnityEngine; // Imports UnityEngine library.
using System.Collections; // Imports System.Collections Library.

public class PandaCamera : MonoBehaviour {

	public Transform target;// transform variable called target [Player object].
	public float wantedHeight; //float variable called wantedHeight [Camera height from above].
	public float distance = 2.85f; //float variable called distance [Distance from player Object].

	private float currentX = 0.0f; // float varible currentX set to 0 as defualt [Current X rotation] . 
	private float currentY = 0.0f;// float varible currentY set to 0 as defualt [Current Y rotation] . 
	float rotSpeed = 3f;// float variable rotSpeed set to 3 by default [Speed camera rotates].


	void LateUpdate() {
		currentX += Input.GetAxis("RightH") * rotSpeed; // adds the input axis "RightH" times by rotspeed to currentX.
		currentY += Input.GetAxis("RightV") * rotSpeed;// adds the input axis "RightV" times by rotspeed to currentY.

		currentY = Mathf.Clamp(currentY,10,40);// Sets the currentY rotation to only be between 10 and 40 used to stop camera going through the ground.
		Vector3 dir = new Vector3(0,0,-distance - (currentY / 3)); // Vector3 variable dir sets z to -distance - (currentY / 3) to work out its direction.
		Quaternion rotation = Quaternion.Euler(currentY,-currentX,0); // Quaternion variable rotation set to an eular angles with CurrentY being the x, -CurrentX being the y and 0 being the Z.
		transform.position = target.position + rotation * dir; // Sets the transforms position to be at the targets position but with added roation multipled by its direction.
		transform.LookAt(target.position); // makes the camera allways look at the player [Acts like a pivot point].
	}

}// End of Script.