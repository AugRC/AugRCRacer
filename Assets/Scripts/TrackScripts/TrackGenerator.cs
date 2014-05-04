﻿using UnityEngine;
using System.Collections;

public class TrackGenerator : MonoBehaviour {


	public void generateTrack()
	{
		segmentArray = new Vector3[segments+1];
		
		//Get all the targets in the scene
		targets = GameObject.FindGameObjectsWithTag ("target");
		
		// Create a targetPoints array with the size of the targets array
		targetPoints = new Vector3[targets.Length];
		
		// Create an array  of all the target Vector3 coords
		for (int i = 0; i < targets.Length; i++)
			targetPoints[i] = targets[i].transform.position;
		
		VectorLine spline = new VectorLine("Spline", segmentArray, Color.white, roadTexture, 20.0f, LineType.Continuous);
		spline.MakeSpline (targetPoints, segments, true);
		spline.Draw3D();

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
