using UnityEngine; // Imports UnityEngine library.
using System.Collections; // Imports System.Collections Library.

public class MainMenu : MonoBehaviour {
	public int State = 0; // Handles State the user is on.
	public GameObject[] States; // Array State objects that can be enabled or diasabled on the Canvas.

	private bool m_isAxisInUse = false;

	void Update () // Update is called once per frame.
	{
		if(State == 0) // Checking is the State is 0.
		{
			if(Input.GetAxis("Start") > 0) // Checking to see if the Axis "Start" is pressed.
			{
				ChangeState(1); // Calling function ChangeState to change scene.
			}
		}

		if(State > 0) // Checking is the State is bigger than 0.
		{

			if( Input.GetAxisRaw("Back") != 0)
			{
				if(m_isAxisInUse == false)
				{
					ChangeState(State -1);
					// Call your event function here.
					m_isAxisInUse = true;
				}
			}
			if( Input.GetAxisRaw("Back") == 0)
			{
				m_isAxisInUse = false;
			}    
		}
	}

	public void ChangeState (int state) // ChangeState has an integer input variable that is set on the canvas button elements.
	{
		for(int i= 0; i < States.Length; i++) // For loop that increments i by 1 until it matches the Lenth of the objects in the variable States.
		{
			States[i].SetActive(false);//Sets all Canvas objects to be invisible.
		}
		States[state].SetActive(true); //Enables current required state.
		State = state;
	}

	public void Quit() // Function made for exiting the application via canvas.
	{
		Application.Quit(); // Closes the Game.
	}

	public void LoadLevel (int Level) // LoadLevel has an integer input vatiable set in the canvas level select state.
	{
		Application.LoadLevel(Level); // Loads the level via integer "Level".
	}
		
} // End of Script
