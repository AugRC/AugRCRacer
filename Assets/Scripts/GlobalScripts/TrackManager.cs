using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackManager : MonoBehaviour{

	//static HashSet<int> initializedIds = new HashSet<int>();

	public GameObject WorldObj;
	public static GameObject World;

	void Awake(){
		World = WorldObj;
	}

}
