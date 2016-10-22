using UnityEngine; // Imports UnityEngine library.
using System.Collections; // Imports System.Collections Library.

public class PandaTalking : MonoBehaviour {

	int BlendAmount;
	int dir = 0;
	int TalkSpeed = 10;
	bool talk = true;

	void FixedUpdate () // Update is called once per frame
	{
		if(talk == true)
		{
			Talk();
		}
	}

	void Talk () 
	{
		if(BlendAmount <= 99 && dir == 0)
		{
			BlendAmount += TalkSpeed;
			gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,BlendAmount);
		}
		else
		{
			dir = 1;
			if(BlendAmount >= 1 && dir == 1)
			{
				BlendAmount-= TalkSpeed;
				gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,BlendAmount);
			}
			else
			{
				dir = 0;
			}
		}

	}
}
