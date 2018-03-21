// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/InGameLifeShader" {
	Properties {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}  
		_WhiteColor ("WhiteColor", Color) = (1,1,1,1)
        _RedColor ("RedColor", Color) = (1,1,1,1)
		_LifeRate ("LifeRate", Range(0,1)) = 1.0
        _ParentX ("Parent X", Float) = 0.0
        _ParentWidth ("Parent Width", Float) = 0.0
	}

    CGINCLUDE  
        #include "Lighting.cginc"  
        #include "unitycg.cginc"   

        sampler2D _MainTex;    
        float4 _MainTex_ST;  
        fixed4 _WhiteColor;
        fixed4 _RedColor;
        float _LifeRate;  
        float _ParentX;
        float _ParentWidth;

        struct appdata
        {
            float4 vertex : POSITION;
            float4 texcoord : TEXCOORD0;    
            float3 normal : NORMAL;  
 
        };
        struct v2f
        {
            float4 vertex : SV_POSITION;
            float3 worldPos : TEXCOORD0;   
            float2 uv : TEXCOORD1;    
            float lightdir : TEXCOORD2;
        };

        v2f vert (appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);

            o.worldPos = mul(unity_ObjectToWorld,v.vertex).xyz;   

            o.uv = TRANSFORM_TEX(v.texcoord,_MainTex);  

            //获取法线方向  
            fixed3 worldNormal = normalize(UnityObjectToWorldNormal(v.normal));  
            //灯光方向  
            fixed3 worldLightDir = normalize(_WorldSpaceLightPos0).xyz;   
            o.lightdir = saturate(dot(worldNormal,worldLightDir));
            return o;
        }

        fixed4 frag(v2f i) : SV_Target {  
            fixed4 c = _WhiteColor ;  
            if(i.worldPos.x - _ParentX -  _ParentWidth / 2 > -_LifeRate * _ParentWidth){
                c = _RedColor;  
            }
            fixed4 color = lerp(tex2D(_MainTex,i.uv),c,0.4) ;  
            return color * (i.lightdir+0.5) ;    
        }      
    ENDCG  

	SubShader {
		 

        Pass{    
            Tags { "RenderType"="Opaque"  "LightMode" = "ForwardBase"}
            LOD 200  
            CGPROGRAM  
 

            #pragma vertex vert      
            #pragma fragment frag  
            ENDCG   
        }    
        Pass{    
            Tags { "RenderType"="Opaque"  "LightMode" = "ForwardAdd"}
            Blend One Zero
            LOD 200  
            CGPROGRAM  
            #include "AutoLight.cginc"
 
            #include "UnityPBSLighting.cginc"
            //指令可以保证我们在shader中使用光照衰减等光照变量可以被正确赋值。
            #pragma multi_compile_fwdbase
            #pragma vertex vert      
            #pragma fragment frag2 
            fixed4 frag2(v2f i) : SV_Target {  
                float3 wpos = mul(unity_ObjectToWorld, i.vertex).xyz;

                  
                fixed4 c = _WhiteColor ;  
                if(i.worldPos.x - _ParentX -  _ParentWidth / 2 > -_LifeRate * _ParentWidth){
                    c = _RedColor;  
                }
                fixed4 color = lerp(tex2D(_MainTex,i.uv),c,0.4) ;

                //UNITY_LIGHT_ATTENUATION(attenuation, 0, i.worldPos);
                float dis = length(_WorldSpaceLightPos0.xyz -i.worldPos);  
                float attenuation = 1.0 / dis;

                return color * (attenuation + 0.5);    
            }      

            ENDCG   
        }   

	}
	FallBack "Diffuse"
}
