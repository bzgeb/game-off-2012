using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	float start_time;
	float end_time;
	float current_time;
	GUIText timer_text;
	bool started;
	
	void Start ()
	{
		timer_text = GameObject.Find("Timer Text").GetComponent<GUIText>();
		started = false;
	}
	
	void Update () 
	{
		if (started)
		{
			current_time = Time.timeSinceLevelLoad - start_time;
//			timer_text.text = current_time.ToString();
			int seconds = (int)Mathf.Floor(current_time);
			int milliseconds = (int)Mathf.Floor((current_time - seconds) * 100);
			System.TimeSpan timeSpan = new System.TimeSpan(0, 0, 0, seconds, milliseconds);
//			timer_text.text = new System.DateTime((long)current_time * System.TimeSpan.TicksPerSecond).ToString();
			timer_text.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
		}
	}
	
	public void StartTimer()
	{
		start_time = Time.timeSinceLevelLoad;
		started = true;
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
