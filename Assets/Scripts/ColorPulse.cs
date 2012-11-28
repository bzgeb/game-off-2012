using UnityEngine;
using System.Collections;

public class ColorPulse : MonoBehaviour {
	public Color start_color;
	public Color end_color;
	public float pulse_time;
	private float current_time;

	// Use this for initialization
	void Start () {
		current_time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		current_time += Time.deltaTime;
		renderer.sharedMaterial.color = Color.Lerp(start_color, end_color, (current_time / pulse_time));
		
		if (current_time >= pulse_time)
		{
			Color temp = start_color;
			start_color = end_color;
			end_color = temp;
			current_time = 0;
		}
	}
}
