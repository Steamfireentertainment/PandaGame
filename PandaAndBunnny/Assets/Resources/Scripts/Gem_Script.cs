using UnityEngine; // Imports UnityEngine library.
using System.Collections; // Imports System.Collections Library.

public class Gem_Script : MonoBehaviour {
	public Transform Player;
	public float Distance;
	public Color[] colourchoice;
	// Use this for initialization
	void Start () 
	{
		this.GetComponent<MeshRenderer>().material.color = colourchoice[Random.Range(0,colourchoice.Length)];
		Player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Distance = Vector3.Distance(transform.position,Player.position);
		transform.Rotate(0,0,70 * Time.deltaTime * 2);
		if(Distance <= 1)
		{
			Player.GetComponent<PlayerHandler>().Gems++;
			Destroy(this.gameObject);
		}
		if(Distance <=7 ){
			transform.parent = Player;
			transform.name = "CollectedGem";
			transform.position = Vector3.Lerp(transform.position,Player.position,Time.deltaTime * 4);
		}

	}
}
