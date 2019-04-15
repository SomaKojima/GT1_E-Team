Shader "Custom/EarhMain"
{

	// ----------------------------------------------------------------------------------------
	//	Parameters
	// ----------------------------------------------------------------------------------------
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
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

		// 毎フレーム半径が変わる
		float _Radiuas;
		// 明かりを灯す中点  雑に設定：fixed3(0,5.5,0)
		float _LightPosX;
		float _LightPosY;
		float _LightPosZ;
		// 黒くする量
		float _BlakAmount;
		// 白くする量
		float _WhiteAmount;
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			// 中点からの距離
			float dist = distance(fixed3(_LightPosX, _LightPosY, _LightPosZ), IN.worldPos);
			
			fixed4 texturecolor = tex2D(_MainTex, IN.uv_MainTex);

			if(_Radiuas < dist)
			{
				// 反映する
				o.Albedo = texturecolor;
			}
			else
			{
				
				// 反映する
				o.Albedo = texturecolor * _EmissionColor;
			}
		}
		ENDCG
	}
		FallBack "Diffuse"
}
