using UnityEngine;
using System.Collections;

public class AugRacerFrameMarker : MonoBehaviour,
	ITrackableEventHandler
	{
		#region PRIVATE_MEMBER_VARIABLES
		
		private TrackableBehaviour mTrackableBehaviour;
		
		#endregion // PRIVATE_MEMBER_VARIABLES
		
	private bool childrenCreated = false;
		
		#region UNTIY_MONOBEHAVIOUR_METHODS
		
		void Start()
		{
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
		}
		
		#endregion // UNTIY_MONOBEHAVIOUR_METHODS
		
		
		
		#region PUBLIC_METHODS
		
		/// <summary>
		/// Implementation of the ITrackableEventHandler function called when the
		/// tracking state changes.
		/// </summary>
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
			    newStatus == TrackableBehaviour.Status.TRACKED ||
			    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{

				OnTrackingFound();
			}
			else
			{
				OnTrackingLost();
			}
		}
		
		#endregion // PUBLIC_METHODS
		
		
		
		#region PRIVATE_METHODS
		
		
		private void OnTrackingFound()
		{
		if(childrenCreated)
			return;

		//here instantiate if not instantiated before

		string prefabname = "";

		MarkerBehaviour mb = this.GetComponent<MarkerBehaviour>();
		Debug.LogWarning(mb.Marker.MarkerID);

		if (mb.Marker.MarkerID != 0){
			switch (mb.Marker.MarkerID % 4){
			case 0: 
				break;
			case 1: prefabname = "CurveTrack";
				break;
			case 2: prefabname = "CrossTrack";
				break;
			case 3: prefabname = "StraightTrack";
				break;
			}

			GameObject g = (GameObject)Instantiate(PrefabManager.GetPrefab(prefabname), transform.position, Quaternion.identity);
			g.transform.localScale = Vector3.Scale( this.transform.localScale, g.transform.localScale);
			g.transform.parent = TrackManager.World.transform;


		}
		else{

			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			
			// Enable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}
			
			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}
		}
			
		childrenCreated = true;
		}
		
		
		private void OnTrackingLost()
		{
			
		}
		
		#endregion // PRIVATE_METHODS
	}
