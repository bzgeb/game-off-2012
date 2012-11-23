using UnityEngine;
using System.Collections;

public class RhythmTracker : MonoBehaviour {

	public float bpm = 180f;
	private Player player;
	private float last_tick_time;
	private float last_press_time;
	private bool got_input;
	private int streak;
	
	void Start () 
	{
		last_tick_time = float.MaxValue;
		last_press_time = float.MinValue;
		player = FindObjectOfType(typeof(Player)) as Player;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			InvokeRepeating("Flash", 0, (60/bpm));
		}
		
		
		if (got_input)
		{
			float diff = Mathf.Abs(last_tick_time - last_press_time);
			if (diff < 0.3f)
			{
				streak += 4;
				print("Great!");
			}
			else if (diff < 0.7f)
			{
				streak += 2;
				print("Okay!");
			}
			else
			{
				streak = Mathf.Clamp(streak - 1, 0, streak);
				print("Bad!");
			}
			print("Diff: " + diff);
			
			got_input = false;
		}
	}
	
	void OnGUI()
	{
		Event cur = Event.current;
		if (!got_input && cur.isKey && cur.type == EventType.KeyUp)
		{
			if (cur.keyCode == KeyCode.T)
			{
				last_press_time = Time.realtimeSinceStartup;
				got_input = true;
				CancelInvoke("fail");
			}
		}
	}
	
	void fail()
	{
		streak = 0;
		print("Fail!");
	}
	
	void end_flash()
	{
		player.renderer.sharedMaterial.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
	}
	
	public int GetStreak()
	{
		return streak;
	}
	
	void Flash()
	{
		last_tick_time = Time.realtimeSinceStartup;
		player.renderer.sharedMaterial.color = Color.green;
//		print("last tick: " + last_tick_time);
		Invoke("end_flash", 0.15f);
		Invoke("fail", 60 / bpm);
	}
}
