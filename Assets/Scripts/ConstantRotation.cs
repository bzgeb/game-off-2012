using UnityEngine;
using System.Collections;

public class ConstantRotation : MonoBehaviour {
	public Vector3 axis;
	public float rotation_speed;
	float angle;
	Transform _transform;
	
	// Use this for initialization
	void Start () 
	{
		_transform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		angle = rotation_speed * Time.deltaTime;
		_transform.RotateAround(axis, angle);
	}
}
