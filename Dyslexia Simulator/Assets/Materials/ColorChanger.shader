Shader "Ben/ColorChanger" {
	Properties {
		_Amount("Range Strength", Range(0,10)) = 5
		_Color ("Hi-Color", Color) = (0,0,1,1)
		_Color2("Hi-Color", Color) =(1,0,0,1)
		_Color3("Main Color", Color) = (0,1,0,1)
        _Range ("Max Distance", Range(0,30)) = 30
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};


		
        float _Range;
		half _Glossiness;
		half _Metallic, _Amount;
		fixed4 _Color, _Color2, _Color3;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color

			half checkBlend = clamp(sin(_Time.x*_Amount*5),-1,1);
			half blend = clamp(sin(_Time.x*_Amount*10),-1,1);

			float4 newColor = 0;
			if(checkBlend < 0)
			{
				newColor = float4(lerp(_Color2.r, _Color3.r, blend), lerp(_Color2.g, _Color3.g, blend), lerp(_Color2.b, _Color3.b,blend),1);
			}else
			{
				newColor = float4(lerp(_Color3.r, _Color.r, blend), lerp(_Color3.g, _Color.g, blend), lerp(_Color3.b, _Color.b,blend),1);
			}
			float dist = clamp(distance(_WorldSpaceCameraPos, IN.worldPos)-_Range,0,1);

			float3 finalColor = lerp(_Color3,newColor, dist);


			o.Albedo = finalColor;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = 1;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
