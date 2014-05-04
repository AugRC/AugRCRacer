using UnityEngine;
using System.Collections;


public class CarController : MonoBehaviour{
	
	// return if the person is touching the break
	public bool isBraking()
	{
		return Input.GetKey(KeyCode.Space);
	}
	
	public TurnType getTurn()
	{
		if(Input.GetKey(KeyCode.RightArrow))
		{
			return TurnType.TurningRight;
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			return TurnType.TurningLeft;
		}
		return TurnType.NotTurning;
	}
	
	public void readControls()
	{}
	
	void OnGUI ()
	{
		if (GUI.Button(new Rect(10, 10, 50, 50), "hello"))
			print ("hello");
	}
}