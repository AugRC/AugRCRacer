using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GroundDetector))]
public class CarBehavior : MonoBehaviour {
	
	public float accellerationRoad;
	public float accellerationGrass;
	public float maxRoadSpeed;
	public float maxGrassSpeed;
	public float breakDrag;
	public float roadDrag;
	public float grassDrag;
	public float turnSpeed;


	public ICarController controller;
	private GroundDetector groundDetector;

	private Vector3 direction;

	private float tilt=0;
	private float maxTilt = 30;

	private bool canGo;

	public void StartCar()
	{
		canGo = true;
	}

	// Use this for initialization
	void Start () 
	{
		controller = new DummyCarController();
		this.groundDetector = this.GetComponent<GroundDetector>();
		
		StartCoroutine(startAfterSec());
		direction = new Vector2(transform.forward.x, transform.forward.y);
	}

	IEnumerator startAfterSec()
	{
		yield return new WaitForSeconds(10);
		StartCar();
	}

	void RotateDirection( float angle )
	{

		transform.Rotate(new Vector3(0,angle,0));
		this.direction = transform.forward;
		//this.direction = new Vector2(newDir.x,newDir.y);
		
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,0,-4*transform.localEulerAngles.z * Time.deltaTime));
		if(!canGo)
			return;
		controller.readControls();

		var turning = controller.getTurn();

		if(turning != TurnType.NotTurning)
		{
			RotateDirection(this.turnSpeed * Time.deltaTime * (turning == TurnType.TurningLeft ? -1 : 1));
		}

		bool onTheRoad = this.groundDetector.IsOverRoad();
		this.rigidbody.drag = onTheRoad ? roadDrag : grassDrag;

		if(controller.isBraking())
		{
			this.rigidbody.drag = this.breakDrag;
		}
		else
		{
			var acc = onTheRoad ? accellerationRoad : accellerationGrass;
			var maxSpeed = onTheRoad ? maxRoadSpeed : maxGrassSpeed;
			if(this.rigidbody.velocity.magnitude < maxSpeed)
			{
				this.rigidbody.AddForce(direction * acc);
			}

		}



	}
}
