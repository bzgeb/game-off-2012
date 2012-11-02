using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	float start_time;
	float end_time;
	float current_time;
	
	void Update () 
	{
		current_time = Time.timeSinceLevelLoad - start_time;
	}
	
	public void StartTimer()
	{
		start_time = Time.timeSinceLevelLoad;
	}
	
	void StopTimer()
	{
		end_time = Time.timeSinceLevelLoad;
		current_time = end_time - start_time;
	}
	
	float GetTime()
	{
		return current_time;
	}
}
