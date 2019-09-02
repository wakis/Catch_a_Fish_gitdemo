// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/UnText"//作ったシェーダーの名前
//"http://haraken.hatenablog.com/entry/2016/11/29/TextMesh%E3%81%A7%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88%E3%82%92%E9%80%8F%E9%81%8E%E3%81%95%E3%81%9B%E3%81%AA%E3%81%84%E6%96%B9%E6%B3%95"
{
	Properties{
		_MainTex("Font Texture", 2D) = "white" {}
	_Color("Text Color", Color) = (1,1,1,1)
	}

		SubShader{

		Tags{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
		"PreviewType" = "Plane"
	}
		Lighting Off
		Cull Back
		ZTest LEqual
		ZWrite On
		Blend SrcAlpha OneMinusSrcAlpha

		Pass{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		struct appdata_t {
		float4 vertex : POSITION;
		fixed4 color : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f {
		float4 vertex : SV_POSITION;
		fixed4 color : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	sampler2D _MainTex;
	uniform float4 _MainTex_ST;
	uniform fixed4 _Color;

	v2f vert(appdata_t v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.color = v.color * _Color;
		o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
		return o;
	}

	fixed4 frag(v2f i) : SV_Target
	{
		fixed4 col = i.color;
	col.a *= tex2D(_MainTex, i.texcoord).a;
	return col;
	}
		ENDCG
	}
	}
}