using UnityEngine;
using System.Collections;

public enum TurnType
{
	TurningLeft,
	TurningRight,
	NotTurning
};

public interface ICarController {
	
	bool isBraking();
	
	TurnType getTurn();

	void readControls();


}
