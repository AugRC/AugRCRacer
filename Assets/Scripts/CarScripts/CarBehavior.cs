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


	public CarController controller;
	private GroundDetector groundDetector;

	private Vector3 accelerationDirection;

	private float tilt=0;
	private float maxTilt = 30;

	private bool canGo;



	public void StartCar()
	{
		//this.rigidbody.useGravity = true;
		canGo = true;
	}

	// Use this for initialization
	void Start () 
	{
		controller = this.GetComponent<CarController>();
		this.groundDetector = this.GetComponent<GroundDetector>();
		
		StartCoroutine(startAfterSec());
		accelerationDirection = new Vector2(transform.forward.x, transform.forward.y);
	}

	IEnumerator startAfterSec()
	{
		yield return new WaitForSeconds(5);
		StartCar();
	}

	void RotateDirection( float angle )
	{

		transform.Rotate(new Vector3(0,angle,0));
		this.accelerationDirection = transform.forward;
		//this.direction = new Vector2(newDir.x,newDir.y);
		
	}
	/*
	void OnCollisionEnter(Collision collisionInfo)
	{
		var collitionNormal = collisionInfo.contacts[0].normal;

		//this.rigidbody.AddForceAtPosition(Vector3.Reflect(this.rigidbody.velocity*3, collitionNormal),collisionInfo.contacts[0].point);

	}*/

	// Update is called once per frame
	void Update () {
		//transform.Rotate(new Vector3(0,0,-1*transform.localEulerAngles.z));
		if(!canGo)
			return;
		//controller.readControls();

		var turning = controller.getTurn();

		if(turning != TurnType.NotTurning)
		{
			var turnAmount = this.turnSpeed * Time.deltaTime * (turning == TurnType.TurningLeft ? -1 : 1);
			transform.RotateAround(transform.position, transform.up, turnAmount);
			//transform.localEulerAngles = new Vector3((this.transform.localEulerAngles.x+turnAmount)%360,90,270);
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
				this.rigidbody.AddForce(transform.forward * acc);
			}
		}

		Vector3 worldUp = -TrackManager.World.transform.forward;
		Vector3 pivot = Vector3.Cross(worldUp, transform.up);
		float angl = Vector3.Angle(transform.up, worldUp);
		Debug.Log(angl);
		if (angl > 0)
			transform.RotateAround(transform.position, pivot, -1*angl);// turnSpeed*Time.deltaTime/10f);

		//Debug.DrawLine(this.transform.position, transform.forward * 60 + this.transform.position, Color.red);
		

		//transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x,90,270);
	}
}
