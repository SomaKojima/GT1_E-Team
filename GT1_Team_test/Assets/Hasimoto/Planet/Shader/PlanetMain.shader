Shader "Custom/PlanetMain"
{

	// ----------------------------------------------------------------------------------------
	//	Parameters
	// ----------------------------------------------------------------------------------------
	Properties
	{
		// テクスチャー
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		// エミッションカラー
		[HDR]_EmissionColor("Emission Color",Color) = (0,0,0)
	}

	SubShader
	{
		// ----------------------------------------------------------------------------------------
		//			Shader Settings
		// ----------------------------------------------------------------------------------------
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
// Upgrade NOTE: excluded shader from DX11, OpenGL ES 2.0 because it uses unsized arrays
#pragma exclude_renderers d3d11 gles
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		#include "UnityCG.cginc"

		sampler2D _MainTex;
		float4 _EmissionColor;

		// ----------------------------------------------------------------------------------------
		//			Surface Shader
		// ----------------------------------------------------------------------------------------
		struct Input
		{
			float3 worldPos;	// ワールド座標
			float2 uv_MainTex;	// テクスチャーUV座標
		};

		//// 毎フレーム半径が変わる
		//float _Radiuas;
		//
		//// 明かりを灯す中点  
		//float _LightPosX;
		//float _LightPosY;
		//float _LightPosZ;
		//
		//// 惑星の全体を灯すか(true:全体 false:一部)
		//bool _IsLightAll;
		//
		//// 配列の長さ
		//int _ArrayLength;
		//// 明かりを灯すそれぞれの位置
		//float4 _LightPos[10000];
		//// 中点からの距離
		//float dists[10000];
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{			
	//		// 中点からの距離を設定する
	//		//for (int i = 0; i < _ArrayLength; i++)
	//		//{
	//		//	dists[i]= distance(fixed3(_LightPos[i].x, _LightPos[i].y, _LightPos[i].z), IN.worldPos);
	//		//}
	//		
	//		// ---------------------------------------------------------------------------
	//
	//		// 中点からの距離
	//		float dist = distance(fixed3(_LightPos[0].x, _LightPos[0].y, _LightPos[0].z), IN.worldPos);
	//
	//		//float dist = distance(fixed3(_LightPosX, _LightPosY, _LightPosZ), IN.worldPos);
	//		
	//		fixed4 texturecolor = tex2D(_MainTex, IN.uv_MainTex);
	//
	//		if(_Radiuas < dist)
	//		{
	//			// そのまま反映する
	//			o.Albedo = texturecolor;
	//		}
	//		else
	//		{				
	//			// 光に反映する
	//			o.Albedo = texturecolor * _EmissionColor;
	//		}
		}
		ENDCG
	}
		FallBack "Diffuse"
}
