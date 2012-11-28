using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	public Player player;
	private GameObject player_object;
	public GameObject world;
	public AudioClip music;
	public float jump_strength = 15;
	private int current_rotation;
	private Vector3 camera_right;
	private bool start_moving;
	private Timer timer;
	private RhythmTracker rhythm_tracker;
	
	private float current_speed;
	public float max_speed;
	
	private float vertical_speed;
	public float gravity = 20;
	public Vector3 move_direction;
	
	void Start ()
	{
		vertical_speed = 0;
		current_speed = 1f;
		
		player_object = player.gameObject;
		
		camera_right = Camera.main.transform.right;
		
		start_moving = false;
		
		timer = FindObjectOfType(typeof(Timer)) as Timer;
		
		rhythm_tracker = FindObjectOfType(typeof(RhythmTracker)) as RhythmTracker;
	}
	
	
	void Update () 
	{
		int current_streak = rhythm_tracker.GetStreak();
		current_speed = Mathf.Clamp(1f * current_streak, 1f, max_speed);
		
		keyboard_controls();
		rotate_controls();
		
		if (!player.OnGround())
		{
			vertical_speed -= gravity * Time.deltaTime;
		}
		
		if (start_moving)
		{
			player_object.rigidbody.velocity = (current_speed * 0.5f * move_direction) + new Vector3(0, vertical_speed, 0);
		}
	}
	
	
	private void keyboard_controls()
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			start_moving = true;
			audio.clip = music;
			audio.Play();
			timer.StartTimer();
		}
		
		// Jump
		if (Input.GetKeyDown(KeyCode.W) && player.OnGround())
		{
			vertical_speed = jump_strength;
		}
	}
	
	
	private void rotate_controls()
	{
		int direction = Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0;
		direction = Input.GetKeyDown(KeyCode.RightArrow) ? -1 : direction;
	
		if (direction != 0)
		{
			current_rotation += direction;
			world.transform.rotation = Quaternion.AngleAxis(current_rotation * 90, Vector3.up);
			camera_right = Camera.main.transform.right;
		}
		
	}
}
