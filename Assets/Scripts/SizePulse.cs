using UnityEngine;
using System.Collections;

public class SizePulse : MonoBehaviour {

	bool scaling_up = true;
	public float scale_time;
	float current_time;
	Transform _transform;
	
	Vector3 starting_scale;
	public Vector3 ending_scale;
	
	void Start ()
	{
		current_time = 0;
		_transform = transform;
		starting_scale = _transform.localScale;
	}
	
	void Update()
	{
		current_time += Time.deltaTime;
		_transform.localScale = Vector3.Lerp(starting_scale, ending_scale, current_time / scale_time);
		
		if (current_time >= scale_time)
		{
			Vector3 temp = ending_scale;
			ending_scale = starting_scale;
			starting_scale = temp;
			current_time = 0;
		}
	}
}
