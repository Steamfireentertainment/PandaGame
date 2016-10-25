using UnityEngine; // Imports UnityEngine library.
using UnityEngine.UI;
using System.Collections; // Imports System.Collections Library.

public class PlayerHandler : MonoBehaviour {

	public int Gems; // Integer varable "Gems" for storing the Gems the player has.
	public bool TalkingToAi;
	public Text UI;
	private bool m_isAxisInUse = false;
	public bool Paused = false;

	public GameObject Pause;
	// Use this for initialization
	void Update () 
	{
		UI.text = "" + Gems;

		if( Input.GetAxisRaw("Start") != 0)
		{
			if(m_isAxisInUse == false)
			{
				if(Paused){
					Time.timeScale = 1;
					Pause.SetActive(false);
					Paused = !Paused;
				}
				else
				{
					Paused = !Paused;
					Pause.SetActive(true);
					Time.timeScale = 0;
				}
				}
				m_isAxisInUse = true;
			}
		if( Input.GetAxisRaw("Start") == 0)
		{
			m_isAxisInUse = false;
		}

	}
	
	// Update is called once per frame
	public void Lock () 
	{
		GetComponent<PandaControlls>().enabled = false;
	}

	public void Unlock(){
		GetComponent<PandaControlls>().enabled = true;
		GetComponent<PandaControlls>().Unlocking = true;
		StartCoroutine(	GetComponent<PandaControlls>().Unlock());
	}
}
