using UnityEngine;
using System.Collections;
using System.Collections.Generic;




//use this to load everything into memory first
//so we don't have to use Resources.Load
//uses a dictionary to sort all the prefabs so you can get by string


public class PrefabManager : MonoBehaviour {


	public GameObject[] prefabs;


	private static Dictionary<string, GameObject> prefabDict;


	//make those prefabs into the dictionary
	void Awake(){
		PrefabManager.prefabDict = new Dictionary<string, GameObject>();
		for(int i = 0; i < prefabs.Length; i++){
			prefabDict.Add (prefabs[i].name, prefabs[i]);
		}


		//we don't need the array anymore
		prefabs = null;
	}


	//use this to get a prefab
	public static GameObject GetPrefab(string prefabName){
		return prefabDict[prefabName];
	}


}
