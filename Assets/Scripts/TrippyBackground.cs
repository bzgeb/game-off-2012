using UnityEngine;
using System.Collections;

public class TrippyBackground : MonoBehaviour {

	Camera _cam;
	float color_timer = 1;
	float start_time;
	float current_time;
	Color current_color;
	Color next_color;
	// Use this for initialization
	void Start () 
	{
		_cam = GetComponent<Camera>();
		current_time = 0;
		current_color = _cam.backgroundColor;
		next_color = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, 255);
	}
	
	// Update is called once per frame
	void Update () 
	{
		current_time += Time.deltaTime;
		_cam.backgroundColor = Color.Lerp(current_color, next_color, current_time / color_timer);
		
		if ((current_time / color_timer) > 1)
		{
			current_color = _cam.backgroundColor;
			next_color = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, 255);
			current_time = 0;
		}
	}
}
