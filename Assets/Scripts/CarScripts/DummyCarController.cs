using UnityEngine;
using System.Collections;

public class DummyCarController : ICarController {
	
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
}
