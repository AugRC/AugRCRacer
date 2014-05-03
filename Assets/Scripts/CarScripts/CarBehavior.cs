using UnityEngine;
using System.Collections;

public class CarBehavior : MonoBehaviour {

	public float accelleration;
	public float maxRoadSpeed;
	public float maxGrassSpeed;
	public float dragComponent;


	public ICarController controller;

	private Vector2 currentSpeed;

	private Vector2 direction;

	private bool canGo;

	public void StartCar()
	{
		canGo = true;
	}

	// Use this for initialization
	void Start () {
	}


	
	// Update is called once per frame
	void Update () {
		if(!canGo)
			return;
		controller.readControls();




	}
}
