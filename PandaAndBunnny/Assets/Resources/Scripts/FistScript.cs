using UnityEngine; // Imports UnityEngine library.
using System.Collections; // Imports System.Collections Library.

public class FistScript : MonoBehaviour {
	
	GameObject Player;// Gameobject variable player [Player Object].

	void Start () // Use this for initialization
	{
		Player = GameObject.Find("Player");// Finds the Gameobject "Player" in the scene.
	}

	void OnTriggerEnter(Collider col)// called when an object enteres the collider attached to the object cointaining the script.
	{
		Debug.Log(col.transform.name);//outputs the collision objects name to debug comsole.
		if(col.transform.name == "Vase") // checks to see if the collision transforms name is Vase.
		{
			Debug.Log("Hit Vase");// Outputs "Hit vase" to debug comsole.
			if(Player.GetComponent<PandaControlls>().fighting == true)// checks to see if the PandaControlls script attached to the player has f ighting enabled. 
			{
				col.transform.GetComponent<VaseBreak>().Break(); // calls Break function in attached VaseBreak script on the collided object.
			}
		}
	}
}// End of script.
