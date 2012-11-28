Shader "Custom/Unlit-Color-NoCulling" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1) 
	}
	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		LOD 100
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		Cull Off
	
		Pass {
			Lighting Off
			Color [_Color]
		}

	} 
	FallBack "Diffuse"
}