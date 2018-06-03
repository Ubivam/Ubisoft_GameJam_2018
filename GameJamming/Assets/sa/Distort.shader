Shader "Unlit/Distort"
{
	Properties
	{
		_Pos("_Pos", Range(0, 400)) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
			};
			
			uniform float _Pos;
			//uniform float _Trigger;
			uniform float2 _MousePos;

			v2f vert (appdata v)
			{
				float4 currClipPos = UnityObjectToClipPos(v.vertex);
				float xPos = currClipPos.x;
				float dist = abs(xPos - _Pos);
				float factor = 1 / dist;

				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex * _Pos);
				o.color = float4(_MousePos.x, _MousePos.y, 1, 1);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return i.color;
			}
			ENDCG
		}
	}
}
