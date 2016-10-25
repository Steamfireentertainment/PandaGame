using UnityEngine; // Imports UnityEngine library.
using System.Collections; // Imports System.Collections Library.

public class PandaControlls : MonoBehaviour {
	
	float rotspeed = 5f;// float varible rotSpeed set to 5 [Player rotation speed].
	public float movespeed = 6.0f; // float variable movespeed set to 6 [Player move speed].
	public float distToGround; // float varible distanceToGround [used for jump detection].
	public Animator anim;// Animation variable anim [Player Animator Component].
	int num = 0; // integer num set to 0 [Used for punching Left and Right].
	public bool fighting = false; // bool varaible fighting set to false .
	Vector3 FightPos; // Vector3 variable FightPos [Used for the start position when the player starts fighing]. 
	public GameObject ButtParticles; // Gameobject variable buttparicles [To be used when doing the BootySlam move].
	bool BootySlammming; //Boolean variable BootySlamming [used to stop player calling the function multiple times].
	bool Jumping; // boolean variable Jumping [Used to stop the player jumping multiple times].
	Transform cam;// Transform variable cam [Camera that is following the player].
	public bool Unlocking = false;
	void Start () // Use this for initialization
	{
		cam = GameObject.Find("Main Camera").transform; // Sets cam to the "Main camera" object in the scene.
		distToGround = GetComponent<Collider>().bounds.extents.y; // sets the disttoground to the distance between the bottom of the collider and the collider beneth it.
	}

	void LateUpdate () // Update is called once per frame
	{
		if(Vector3.Distance(transform.position,FightPos) >= 0.1) // detects the distance between the players current position and the fightpos and checks if its more than 0.1.
		{
			fighting = false;// sets fighting to false.
			anim.SetBool("FightReady",false); // sets animation boolean "FightReady" to false.
		}

		if(Input.GetMouseButtonDown(0))// checks to see if leftclick is down.
		{
			FightPos = transform.position;
			anim.SetBool("FightReady",true);// sets animation boolean "FightReady" to true.
			if(num == 0) // checks if num is equal to 0.
			{
				StartCoroutine(Right());// starts coroutine Right.
				num = 1;// sets num to 1.
			}else{ // if num is not 0.
				StartCoroutine(Left()); // starts coroutine Left. 
				num = 0; // sets num to 0.
			}
		} 
		if(Input.GetAxis("Jump") > 0 && IsGrounded() && !Unlocking){ // checks if the Jump button is pressed and the player is on the ground.
			StartCoroutine(Jump()); // Starts coroutine Jump.
		}

		if(Input.GetAxis("BootySlam") > 0 && !BootySlammming && IsGrounded()){ //Checks if the BootySlam button is pressed , the player isnt bootyslamming already and the player is grounded.
			BootySlammming = true;// sets bootyslamming to true.
			StartCoroutine(BootySlam()); //Starts coroutine BootySlam.
		}
		if(!IsGrounded() && !BootySlammming && !Jumping) // checks if the player isnt grounded , not bootyslamming and not jumping.
		{
			Physics.gravity = new Vector3(0,-150,0); // sets the gravity to -150 to pull the player down faster.
			anim.SetBool("InAir",true); // sets animation boolean "InAir" to true.
		}else if(!BootySlammming && !Jumping)
		{
			Physics.gravity = new Vector3(0,-9.81f,0);// sets the gravity to -9.81.
			anim.SetBool("InAir",false);// sets animation boolean "InAir" to false.
		}
		float Horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed; // float variable Horizontal set to the hrizontal axis mutiplied by deltatime multiplied by movespeed.  
		float Vertical= Input.GetAxis("Vertical") * Time.deltaTime * movespeed; // float variable Vertical.
		if(!BootySlammming){
			// checks if the player is not bootyslamming.
			transform.position += Camera.main.transform.forward * Vertical; // adds the forward vector of the camera times by vertical.
			transform.position += Camera.main.transform.right * Horizontal; // adds the right vector of the camera times by horizontal.
			if(Horizontal <0) // checks if horizontal is less than 0.
			{
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,cam.eulerAngles.y - 90,0),Time.deltaTime * rotspeed); //Lerps the rotation to look left.
			}
			if(Horizontal >0)// checks if horizontal is more than 0.
			{
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,cam.eulerAngles.y + 90,0),Time.deltaTime * rotspeed);//Lerps the rotation to look right.
			}

			if(Vertical <0)// checks if vertical is less than 0.
			{
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,cam.eulerAngles.y + 180,0),Time.deltaTime * rotspeed);//Lerps the rotation to look backward.
			}
			if(Vertical >0)// checks if vertical is more than 0.
			{
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,cam.eulerAngles.y ,0),Time.deltaTime * rotspeed);//Lerps the rotation to look forward.
				//Quaternion.Euler(0,cam.eulerAngles.y ,0);
			}
			//transform.Translate(Horizontal,0,Vertical);
		//transform.Rotate(0,Horizontal,0);
		}
	}

	bool IsGrounded () {
		return Physics.Raycast(transform.position,-Vector3.up,distToGround + 0.1f); // checks if the player is touching the floor using a raycast down.
	}

	public IEnumerator Unlock()
	{
		yield return new WaitForSeconds(0.5f);
		Unlocking = false;
	}

	IEnumerator Jump ()
	{
		Jumping = true; // sets jumping to true.
		gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0,10,0); //adds 10 to the gameobjects attached rigidbody's velocity on the y axis.
		yield return new WaitForSeconds(.4f);// makes the script wait for 0.4 secconds before proceeding.
		Physics.gravity = new Vector3(0,-80,0);// sets the world gravity on the y axis to -80.
		//gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0,-30,0);
		yield return new WaitForSeconds(.2f);// makes the script wait for 0.2 secconds before proceeding.
		Physics.gravity = new Vector3(0,-9.81f,0);// sets the world gravity on the y axis to -9.81.
		Jumping = false;//sets jumping to false.
	}

	IEnumerator BootySlam ()
	{
		BootySlammming = true;//sets bootyslamming to true.
		StopCoroutine("Left"); // Stops coroutine Left
		StopCoroutine("Right"); // stops cotoutie Right
		anim.SetBool("Right",false); // Sets Animation boolean "Right" to false.
		anim.SetBool("Left",false);// Sets Animation boolean "Left" to false.
		anim.SetBool("BootySlam",true);// Sets Animation boolean "BootySlam" to true.
		gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0,60,0);
		gameObject.GetComponent<Rigidbody>().velocity += transform.forward * 40;
		yield return new WaitForSeconds(.1f);// makes the script wait for 0.1 secconds before proceeding.
		Physics.gravity = new Vector3(0,-300,0); // sets the world gravity on the y axis to -300.
		//gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0,-30,0);
		yield return new WaitForSeconds(.4f);// makes the script wait for 0.4 secconds before proceeding.
		Physics.gravity = new Vector3(0,-9.81f,0);// sets the gravity to -9.81.
		ButtParticles.SetActive(true);// Sets the buttparticles opject to be visible.
		yield return new WaitForSeconds(1f);// makes the script wait for 1 seccond before proceeding.
		anim.SetBool("BootySlam",false);// Sets Animation boolean "BootySlam" to False.
		ButtParticles.SetActive(false);
		BootySlammming = false;
	}

	IEnumerator Right()
	{
		fighting = true; // sets fighting boolean to true.
		StopCoroutine("Left"); // Stops coroutine Left
		anim.SetBool("Left",false);// Sets Animation boolean "Left" to false.
		anim.SetBool("Right",true);// Sets Animation boolean "Right" to true.
		yield return new WaitForSeconds(1f);// makes the script wait for 1 seccond before proceeding.
		anim.SetBool("Right",false);// Sets Animation boolean "Right" to false.
		fighting = false;// sets fighting boolean to false.

	}

	IEnumerator Left()
	{
		fighting = true; // sets fighting to true.
		StopCoroutine("Right"); //stops coroutine right.
		anim.SetBool("Right",false); // sets Animation bool "Right" to false.
		anim.SetBool("Left",true); // sets Animation bool "Left" to true.
		yield return new WaitForSeconds(1f); // makes the script wait for 1 seccond before proceeding.
		anim.SetBool("Left",false); // sets Animation bool "Left" to false.
		fighting = false; // sets fighting to false.

	}
}
