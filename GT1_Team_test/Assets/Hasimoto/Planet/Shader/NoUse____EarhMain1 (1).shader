﻿Shader "Custom/NoUse____EarhMain1 (1)" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
	}

		SubShader{
		Tags{ "Queue" = "Geometry-1" }

		Pass{
		Zwrite On
		ColorMask 0
	}
	}
}
