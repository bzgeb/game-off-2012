using UnityEngine;
using System.Collections;

public class WireCamera : MonoBehaviour {
	void OnPreRender()
	{
		GL.wireframe = true;
	}
	
	void OnPostRender()
	{
		GL.wireframe = false;
	}
}
