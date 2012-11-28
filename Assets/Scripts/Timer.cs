using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	float start_time;
	float end_time;
	float current_time;
	GUIText timer_text;
	
	void Start ()
	{
		timer_text = GameObject.Find("Timer Text").GetComponent<GUIText>();
	}
	
	void Update () 
	{
		current_time = Time.timeSinceLevelLoad - start_time;
		timer_text.text = current_time.ToString();
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
