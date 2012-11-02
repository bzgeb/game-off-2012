using UnityEngine;
using System.Collections;

public class RhythmTracker : MonoBehaviour {

	public float bpm = 180f;
	private Player player;
	private float last_tick_time;
	private float last_press_time;
	private bool got_input;
	
	// Use this for initialization
	IEnumerator Flash()
	{
		while (true)
		{
			last_tick_time = Time.realtimeSinceStartup;
			player.renderer.sharedMaterial.color = Color.green;
			Invoke("end_flash", 0.1f);
			Invoke("fail", 60 / bpm);
			yield return new WaitForSeconds(60 / bpm);
		}
	}
	void Start () {
		last_tick_time = float.MaxValue;
		last_press_time = float.MinValue;
		player = FindObjectOfType(typeof(Player)) as Player;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(Flash());
		}
		
		
		if (got_input)
		{
			float diff = Mathf.Abs(last_tick_time - last_press_time);
			if (diff < 0.5f)
			{
				print("Great!");
			}
			else if (diff < 1f)
			{
				print("Okay!");
			}
			else
			{
				print("Bad!");
			}
			print("Diff: " + diff);
			
			got_input = false;
		}
	}
	
	void OnGUI()
	{
		Event cur = Event.current;
		if (!got_input && cur.isKey && cur.type == EventType.KeyDown)
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
		print("Fail!");
	}
	
	void end_flash()
	{
		player.renderer.sharedMaterial.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
	}
}
