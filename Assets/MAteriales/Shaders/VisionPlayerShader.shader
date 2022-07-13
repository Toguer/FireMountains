Shader "Custom/VisionPlayerShader"
{
    SubShader
    {
        Tags { "RenderType" = "Opaque" "Queue" = "Geometry+1"}
        ColorMask 0

        Pass{
            Stencil{
                Ref 1
                Comp Always
                Pass Replace
            }
        }

    }
}
