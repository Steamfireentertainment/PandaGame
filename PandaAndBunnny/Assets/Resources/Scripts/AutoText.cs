using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoText : MonoBehaviour {

	public float letterPause = 0.2f;
	public AudioClip typeSound1;
	public AudioClip typeSound2;

	public string message;
	public Text textComp;
	private bool m_isAxisInUse = false;
	public GameObject TextBackground;
	public bool completed = false;
	public bool typing = false;
	public GameObject Ai;
	// Use this for initialization
	public void NewText () {
		//textComp = GetComponent<Text>();
		//message = textComp.text;
		typing = true;
		textComp.text = "";
		TextBackground.SetActive(true);
		StartCoroutine(TypeText ());

	}

	void Update ()
	{
		if(completed){
		if( Input.GetAxisRaw("Submit") != 0)
		{
			if(m_isAxisInUse == false)
			{
				ClearText();
					Ai.GetComponent<InteractableCharacter>().player.GetComponent<PlayerHandler>().Unlock();
				m_isAxisInUse = true;
			}
		}
		if( Input.GetAxisRaw("Submit") == 0)
		{
			m_isAxisInUse = false;
		}
		}
	}

	IEnumerator TypeText () {
		foreach (char letter in message.ToCharArray()) {
			if( Input.GetAxisRaw("Submit") != 0)
			{
				if(m_isAxisInUse == false)
				{
					textComp.text = "";
					textComp.text = message;
					completed = true;
					typing = false;
					m_isAxisInUse = true;
				}
			}
			if( Input.GetAxisRaw("Submit") == 0)
			{
				m_isAxisInUse = false;
			}
			if(completed == false){
			textComp.text += letter;
			
			yield return 0;
			yield return new WaitForSeconds (letterPause);
			}
		}
		completed = true;
		typing = false;
	}

	void ClearText () {
		TextBackground.SetActive(false);
		textComp.text = "";
		completed = false;
	}
}

/*PseudoCode
 * 
 * NewText called
 *     ClearText and activate background ui
 *     Start TypeText Coroutine
 *     add a new letter after a delay but check if the player wants to skip at anytime
 *     if the player skips then set the text to the message wanted.
 * 
 * ClearText called 
 *     Set background to false
 *     set text to null.
 *
 */