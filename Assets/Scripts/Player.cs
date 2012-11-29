using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private Vector3 checkpoint;
	private Controls controls;
	private bool on_ground = false;
	private SmoothFollow smooth_follow;
	
	// Use this for initialization
	void Start () 
	{
		checkpoint = transform.position;
		controls = FindObjectOfType(typeof(Controls)) as Controls;
		smooth_follow = FindObjectOfType(typeof(SmoothFollow)) as SmoothFollow;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.y < -10)
		{
			respawn();
		}
	}
	
	void respawn()
	{
		transform.position = checkpoint;
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Goal"))
		{
			stop();
		}
		
		if (other.tag == "RotationTrigger")
		{
			smooth_follow.desired_rotation = other.GetComponent<RotationTrigger>().desired_rotation;
		}
	}
	
	void stop()
	{
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		rigidbody.Sleep();
		controls.enabled = false;
	}
	
	void OnCollisionExit(Collision collision_info)
	{
		on_ground = false;
	}
	
	void OnCollisionEnter(Collision collision_info)
	{
		if (collision_info.contacts[0].normal.y > 0)
		{
			on_ground = true;
		}
	}
	
	public bool OnGround()
	{
		return on_ground;
	}
	
}
