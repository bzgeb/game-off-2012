using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {

	RhythmTracker rhythm_tracker;
	// Use this for initialization
	void Start () 
	{
		rhythm_tracker = FindObjectOfType(typeof(RhythmTracker)) as RhythmTracker;
	}
	
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			InvokeRepeating("DoPulse", 0, (60/rhythm_tracker.bpm));
		}
	}
	
	void DoPulse()
	{
		iTween.ScaleTo(gameObject, new Vector3(3, 3, 3), 0.08f);
		Invoke("Reset", 0.12f);
	}
	
	void Reset()
	{
		gameObject.transform.localScale = new Vector3(1, 1, 1);
	}
}
