using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

	public int state;
	//states: 0-menu 1-play

	// Use this for initialization
	void Start () {
		state = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){

	}

	public void StartGame(){
		state = 1;
		DontDestroyOnLoad(this.gameObject);
		Application.LoadLevel("RaceTrackScene");
	}
}
