﻿using UnityEngine;
using System.Collections;


public class CarController : MonoBehaviour  {
	public Texture leftButtonTex;
	public Texture rightButtonTex;
	public Texture brakeButtonTex;
	
	private bool brakePressed = false;
	private bool leftPressed = false;
	private bool rightPressed = false;

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0)
		{
			for(int i = 0; i < Input.touchCount; i++){
				Vector2 touchPosition = Input.GetTouch (i).position;
				
				// Left button
				if (!rightPressed && touchPosition.x < (Screen.width/5)) 
				{
					print (touchPosition.x);
					Press ("left");
				}
				
				// Right button
				else if (!leftPressed && touchPosition.x < (Screen.width * (2f / 5f)))
				{
					print (touchPosition.x);
					Press ("right");
				}
				else 
				{
					print (touchPosition.x);
					Press ("brake");
				} 
			}
		}
		else
		{	
			// No finger is on the tablet, so make all bools false
			Press ("nothing");
		}
	}
	// return if user is touching the brake
	public bool isBraking()
	{
		return brakePressed;
	}
	
	public TurnType getTurn()
	{
		if (rightPressed == true)
		{
			return TurnType.TurningRight;
		}
		else if(leftPressed == true)
		{
			return TurnType.TurningLeft;
		}
		return TurnType.NotTurning;
	}

	private void Press (string button)
	{
		switch (button)
		{
			case "nothing":
				leftPressed = false;
				rightPressed = false;
				brakePressed = false;
				break;
			case "left":
				leftPressed = true;
				rightPressed = false;
				brakePressed = false;
				break;
			case "right":
				leftPressed = false;
				rightPressed = true;
				brakePressed = false;
				break;
			case "brake":
				leftPressed = false;
				rightPressed = false;
				brakePressed = true;
				break;
		}
	}
	
	void OnGUI ()
	{
		GUI.DrawTexture(new Rect(Screen.width / 25f, Screen.height / 3f, Screen.width / 7f, Screen.height), leftButtonTex, ScaleMode.ScaleToFit, true);
		GUI.DrawTexture(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 7f, Screen.height), rightButtonTex, ScaleMode.ScaleToFit, true);
		GUI.DrawTexture(new Rect(Screen.width / 1.23f, Screen.height / 3f, Screen.width / 7f, Screen.height), brakeButtonTex, ScaleMode.ScaleToFit, true);
	}
}
