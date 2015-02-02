Shader "Custom/FakeRain"
 {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MainColor ("MainColor", Color) = (1,1,1,1)
	}
	
	SubShader
	{	
		Tags { "Queue"="Overlay" "RenderType"="Transparent" }
		
        Pass 
        {  
			ZTest Off
			Blend SrcAlpha OneMinusSrcAlpha 
			CGPROGRAM
		    #pragma vertex vert
		    #pragma fragment frag
		    #include "UnityCG.cginc"

            uniform sampler2D _MainTex;
			uniform float4 _MainColor;
            
            struct vertexInput 
            {
			     float4 vertex   : POSITION;  // The vertex position in model space.
			  //   float3 normal   : NORMAL;    // The vertex normal in model space.
			     float4 color     : COLOR;     // Per-vertex color
			     float4 texcoord : TEXCOORD0; // The first UV coordinate.
            };
            
            struct vertexOutput 
            {
                float4 pos      : POSITION;
				float4 color	: COLOR;
                float2 tex      : TEXCOORD0;
				float3 normal	: TEXCOORD1;
            };
			
			vertexOutput vert(vertexInput v)
			{
				vertexOutput o;
				//o.pos = mul(UNITY_MATRIX_P, v.vertex);
				// 傳送來的頂點坐標限 1~-1.
				o.pos = v.vertex;
				o.color = v.color;
				o.tex = v.texcoord;
				//o.normal = v.normal;
				return o;
			}
			
            float4 frag (vertexOutput input ) : COLOR
            {
            	float4 outcolor = float4(0 , 0, 0, 0);
                float4 lMainTex = tex2D(_MainTex, input.tex) * _MainColor;
                outcolor = outcolor + lMainTex;
                return outcolor;
			}

			

			ENDCG
		}
	}
	FallBack "Diffuse"
}
