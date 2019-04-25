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

		//// 配列の長さ
		int _ArrayLength;
		// 明かりを灯すそれぞれの位置
		float4 _LightPos[100];
		// 中点からの距離
		float dists[100];

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			// テクスチャーの色
			fixed4 texturecolor = tex2D(_MainTex, IN.uv_MainTex);

			// 光を灯す位置が１つもない場合もしくは限度超えた場合、テクスチャーの色のみ描画する
			if ((_ArrayLength == 0)||(_ArrayLength > 100))
			{
				o.Albedo = texturecolor;
				return;
			}
			
			// 中点からの距離を設定する
			for (int i = 0; i < _ArrayLength; i++)
			{
				dists[i] = distance(fixed3(_LightPos[i].x, _LightPos[i].y, _LightPos[i].z), IN.worldPos);
			}
			
			
			// ---------------------------------------------------------------------------

			// テクスチャーの色を付ける
			o.Albedo = texturecolor;
			for (int i = 0; i < _ArrayLength; i++)
			{
				// 指定した位置から円内に光を付けるか判断する
				if (_Radiuas >= dists[i])
				{
					// 黒の度合い
					float gray = texturecolor.r * 0.3f + texturecolor.g * 0.6f + texturecolor.b * 0.1f;
					// 光の強さ	 
					float4 emmsioncolor = _EmissionColor * 4;//(gray <= 0.5f) ? _EmissionColor * 4 : _EmissionColor;

					// 光を加える
					o.Albedo = texturecolor;// *_EmissionColor;
					// テスト用に白色にする
					//o.Albedo = fixed4(1.0f,1.0f,1.0f,1.0f);
					
					return;
				}
			}

		}
		ENDCG
	}
		FallBack "Diffuse"
}
