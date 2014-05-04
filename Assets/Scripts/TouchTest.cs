using UnityEngine;
using System.Collections;

public class TouchTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		for (var i = 0; i < Input.touchCount; ++i) {
			Vector2 touchPosition = Input.GetTouch (0).position;
			if (touchPosition.x > (Screen.width/2f)) 
			{
				print ("touched");
			}
		}

	}
}
