using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RhythmTracker : MonoBehaviour {

	public float bpm = 180f;
	private Player player;
	private float last_tick_time;
	private float last_press_time;
	private float last_tick_frame;
	private float last_press_frame;
	private bool got_input;
	private int streak;
	private const bool USE_FRAME_COUNT = true;
	private int beats_queued;
	private int inputs_queued;
	private Queue<float> queued_ticks;
	private Queue<float> queued_input;
	private bool dropped_tick;
	
	void Start () 
	{
		last_tick_time = float.MaxValue;
		last_press_time = float.MinValue;
		player = FindObjectOfType(typeof(Player)) as Player;
		
		queued_input = new Queue<float>();
		queued_ticks = new Queue<float>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			InvokeRepeating("Flash", 0, (60/bpm));
		}
		
#if UNITY_IOS || UNITY_ANDROID
		if (Input.touchCount > 0)
		{
			foreach(Touch t in Input.touches)
			{
				if (t.phase == TouchPhase.Ended)
				{
					GotInput();
				}
			}
		}
#else
		if (Input.GetKeyDown(KeyCode.D))
		{
			Debug.Break();
		}
		if (Input.GetKeyUp(KeyCode.B))
		{
			GotInput();
		}
#endif	
//		if (got_input)
//		{
//			float diff;
//			if (USE_FRAME_COUNT)
//			{
//				diff = Mathf.Abs(last_tick_frame - last_press_frame);
//				if (diff < 14)
//				{
//					streak += 3;
//					print("Great!");
//				}
//				else if (diff < 20)
//				{
//					streak += 1;
//					print("Okay!");
//				}
//				else
//				{
//					streak = Mathf.Clamp(streak - 1, 0, streak);
//					print("Bad!");				
//				}
//			}
//			else
//			{
//				diff = Mathf.Abs(last_tick_time - last_press_time);
//				if (diff < 0.1f)
//				{
//					streak += 3;
//					print("Great!");
//				}
//				else if (diff < 0.4f)
//				{
//					streak += 1;
//					print("Okay!");
//				}
//				else
//				{
//					streak = Mathf.Clamp(streak - 1, 0, streak);
//					print("Bad!");
//				}
//			}
//			print("Diff: " + diff);
//			
//			got_input = false;
//		}
	}
	
	void GotInput()
	{
		last_press_time = Time.realtimeSinceStartup;
		last_press_frame = Time.frameCount;
		
		CancelInvoke("fail");
		
		if (queued_ticks.Count > 0)
		{
			CheckTiming(last_press_frame, queued_ticks.Dequeue());
			queued_ticks.Clear();
		}
		else if(!dropped_tick)
		{
			queued_input.Enqueue(last_press_frame);
		}
		
//		got_input = true;
	}
	
//	void OnGUI()
//	{
//		Event cur = Event.current;
//		if (!got_input && cur.isKey && cur.type == EventType.KeyUp)
//		{
//			if (cur.keyCode == KeyCode.T)
//			{
//				last_press_time = Time.realtimeSinceStartup;
//				got_input = true;
//			}
//		}
//	}
	
	void fail()
	{
		streak = 0;
		print("Fail!");
	}
	
	public int GetStreak()
	{
		return streak;
	}
	
	void Flash()
	{
		last_tick_time = Time.realtimeSinceStartup;
		last_tick_frame = Time.frameCount;
		
		if (dropped_tick)
		{
			dropped_tick = false;
		}
		
		if (queued_input.Count > 1)
		{
			fail();
			queued_input.Clear();
			dropped_tick = true;
		}
		else if (queued_input.Count == 1)
		{
			CheckTiming(queued_input.Dequeue(), last_tick_frame);
		}
		else
		{
			queued_ticks.Enqueue(last_tick_frame);
			Invoke("fail", 60 / bpm);
		}
	}
	
	void CheckTiming(float input_time, float beat_time)
	{
		float diff = Mathf.Abs(beat_time - input_time);
		if (diff < 14)
		{
			streak += 3;
			print("Great!");
		}
		else if (diff < 20)
		{
			streak += 1;
			print("Okay!");
		}
		else
		{
			streak = Mathf.Clamp(streak - 1, 0, streak);
			print("Bad!");				
		}
	}
}
