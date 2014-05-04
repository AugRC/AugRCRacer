using UnityEngine;
using System.Collections;

public class TrackGenerator : MonoBehaviour {

	public GameObject MarkerPrefab;

	private int numPieces = 50;

	// Use this for initialization
	void Start () {
	
		MarkerTracker mt = TrackerManager.Instance.GetTracker<MarkerTracker>();
		for(int i=1; i<numPieces; i++)
		{
			var newObj = mt.CreateMarker(i,"marker"+i,10);
			Destroy(newObj.gameObject.GetComponent<DefaultTrackableEventHandler>());
			newObj.gameObject.AddComponent<AugRacerFrameMarker>();
		}

}
	
	// Update is called once per frame
	void Update () {
	
	}
}
