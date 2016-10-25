using UnityEngine;
using System.Collections;

public class InteractableCharacter : MonoBehaviour {

	GameObject Canvas;
	int TalkState = 0;
	public Transform player;
	private bool m_isAxisInUse = false;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform;
		Canvas = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Vector3.Distance(transform.position,player.transform.position) < 5)
		{
			if( Input.GetAxisRaw("Interact") != 0)
			{
				if(m_isAxisInUse == false)
				{
					if(Canvas.GetComponent<AutoText>().typing == false && Canvas.GetComponent<AutoText>().completed == false){
						player.transform.GetComponent<PlayerHandler>().Lock();
					Canvas.GetComponent<AutoText>().Ai = this.gameObject;
					Canvas.GetComponent<AutoText>().message = "This some test text , you can skip this message by pressing the A Button.";
					Canvas.GetComponent<AutoText>().NewText();
					}
					m_isAxisInUse = true;
				}
			}
			if( Input.GetAxisRaw("Interact") == 0)
			{
				m_isAxisInUse = false;
			}
		}
	
	}
		
}
