using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	public Rigidbody cube;
	public Player player;
	private GameObject player_object;
	public float force_strength = 6;
//	public ParticleSystem connect_particle;
	private SpringJoint current_joint;
	private LineRenderer line_renderer;
	public GameObject world;
	public AudioClip music;
	public float jump_strength = 2;
	private int current_rotation;
	private Vector3 camera_right;
	private bool start_moving;
	private Timer timer;
	
	public float max_speed;
	
	void Start ()
	{
		line_renderer = GetComponent<LineRenderer>();
		player_object = player.gameObject;
		camera_right = Camera.main.transform.right;
		start_moving = false;
		timer = FindObjectOfType(typeof(Timer)) as Timer;
	}
	
	void Update () 
	{
		keyboard_controls();
		rotate_controls();
	}
	
	void LateUpdate()
	{
		if (start_moving)
			player_object.rigidbody.velocity = 5f * camera_right;
	}
	
	private void keyboard_controls()
	{
//		if (player_object.GetComponent<Player>().OnGround() == false)
//			return;
		
		// Move left/right
//		if (Input.GetKey(KeyCode.A)) 
//		{
//			player_object.rigidbody.AddForce(Quaternion.AngleAxis(180f, Camera.main.transform.up) * camera_right * force_strength);
//		}
//		else if (Input.GetKey(KeyCode.D)) 
//		{
//			player_object.rigidbody.AddForce(camera_right * force_strength);
//		}	
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			start_moving = true;
			audio.clip = music;
			audio.Play();
			timer.StartTimer();
		}
		
		// Jump
		if (Input.GetKeyDown(KeyCode.W))
		{
			player_object.rigidbody.AddForce(Vector3.up * jump_strength, ForceMode.Impulse);
		}
	}
	
//	private void mouse_controls()
//	{
//		if (Input.GetMouseButtonDown(0)) 
//		{
//			RaycastHit hit_info;
//			float distance = 1000;
//			int layer_mask = 1 << LayerMask.NameToLayer("Hookable");
//			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
//			if(Physics.Raycast(r, out hit_info, distance, layer_mask)) 
//			{
//				print("Hit");
//				//Cache the currently connected joint
//				current_joint = hit_info.collider.GetComponentInChildren<SpringJoint>();
////				current_joint = hit_info.collider.GetComponent<HingeJoint>();
////				current_joint = hit_info.collider.GetComponent<ConfigurableJoint>();
//				current_joint.connectedBody = player_object.rigidbody;
//				connect_particle.transform.position = current_joint.transform.position;
//				connect_particle.Play();
//			}
//		}	
//		else if (Input.GetMouseButtonUp(0))
//		{
//			if (current_joint != null)
//			{	
//				current_joint.connectedBody = null;
//				current_joint = null;
//			}
//		}
//	}
	
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
