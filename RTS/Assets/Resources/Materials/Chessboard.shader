Shader "rts/Chessboard"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Width ("Width", Float) = 5
        _Height ("Height", Float) = 7
        
        _OddColor("Odd Color", Color) = (1.0, 1.0, 1.0, 1)	
        _EvenColor("Even Color", Color) = (.25, 1.0, 0.5, 1)
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
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float _Width;
            float _Height;

            float4 _OddColor;
            float4 _EvenColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv * float2(_Width,_Height);

                fixed4 col = _EvenColor;
                
                if((int(uv.x) + int(uv.y)) % 2 > 0)
                {
                    col = _OddColor;
                }

                return col;
            }
            ENDCG
        }
    }
}
