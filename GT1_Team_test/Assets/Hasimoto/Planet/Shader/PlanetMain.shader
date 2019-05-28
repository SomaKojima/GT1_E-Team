﻿Shader "Custom/PlanetMain"
{
	// ----------------------------------------------------------------------------------------
	//	Parameters
	// ----------------------------------------------------------------------------------------
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		[HDR]_AfterEmissionColor("Emission Color",Color) = (255,255,255)
	}

		SubShader
	{
		// ----------------------------------------------------------------------------------------
		//			Shader Settings
		// ----------------------------------------------------------------------------------------
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0
		
		#include "UnityCG.cginc"

		sampler2D _MainTex;
		float4 _AfterEmissionColor;

		// ----------------------------------------------------------------------------------------
		//			Surface Shader
		// ----------------------------------------------------------------------------------------
		struct Input
		{
			float3 worldPos;	// ワールド座標
			float2 uv_MainTex;	// テクスチャーUV座標
		};

		// 毎フレーム半径が変わる
		float _Radiuas;
		// 明かりを灯す中点  雑に設定：fixed3(0,5.5,0)
		float _LightPosX;
		float _LightPosY;
		float _LightPosZ;

		// 中点からの距離
		float dists;

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			// テクスチャーの色
			fixed4 texturecolor = tex2D(_MainTex, IN.uv_MainTex);
			
			// 中点からの距離を設定する
			dists = distance(fixed3(_LightPosX, _LightPosY, _LightPosZ), IN.worldPos);

			// テクスチャーの色を付ける
			o.Albedo = texturecolor;

			// 指定した位置から円内に光を付けるか判断する
			if (_Radiuas >= dists)
			{
				// 黒の度合い
				float gray = texturecolor.r * 0.3f + texturecolor.g * 0.6f + texturecolor.b * 0.1f;
				// 光の強さ	 
				float4 emmsioncolor = _AfterEmissionColor;//(gray <= 0.5f) ? _AfterEmissionColor * 4 : _AfterEmissionColor;

				// 光を加える
				o.Albedo *=_AfterEmissionColor;
				// テスト用に白色にする
				//o.Albedo = fixed4(1.0f,1.0f,1.0f,1.0f);

			}
		}
		ENDCG
	}
		FallBack "Diffuse"
}
