using UnityEngine;
using System.Collections;

public class PowerupTween : MonoBehaviour {
	public Vector3 initial_position;
	public Vector3 final_position;
	public float fade_time;
	
	public void Play()
	{
		transform.localPosition = initial_position;
		guiText.material.color = Color.yellow;
		iTween.MoveTo(gameObject, final_position, fade_time);
		iTween.MoveTo(gameObject, iTween.Hash("position", final_position, "time", fade_time, "islocal", true));
		iTween.ColorTo(gameObject, new Color(1, 1, 1, 0), fade_time);
	}
}
