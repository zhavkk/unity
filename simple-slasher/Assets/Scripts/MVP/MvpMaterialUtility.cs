using System.Collections.Generic;
using UnityEngine;

public static class MvpMaterialUtility
{
    private static Shader cachedLitShader;
    private static Shader cachedFallbackShader;
    private static readonly Dictionary<Material, Material> convertedMaterials = new Dictionary<Material, Material>();

    public static Material CreateLitMaterial(Color color)
    {
        Shader shader = GetLitShader();
        if (shader == null)
        {
            shader = GetFallbackShader();
        }

        if (shader == null)
        {
            shader = Shader.Find("Hidden/InternalErrorShader");
        }

        Material material = new Material(shader);
        material.color = color;
        return material;
    }

    public static Shader GetLitShader()
    {
        if (cachedLitShader == null)
        {
            cachedLitShader = Shader.Find("Universal Render Pipeline/Lit");
            if (cachedLitShader == null)
            {
                cachedLitShader = Shader.Find("Universal Render Pipeline/Simple Lit");
            }
        }

        return cachedLitShader;
    }

    public static Shader GetFallbackShader()
    {
        if (cachedFallbackShader == null)
        {
            cachedFallbackShader = Shader.Find("Standard");
            if (cachedFallbackShader == null)
            {
                cachedFallbackShader = Shader.Find("Unlit/Color");
            }
        }

        return cachedFallbackShader;
    }

    public static bool NeedsUrpUpgrade(Material material)
    {
        if (material == null || material.shader == null)
        {
            return false;
        }

        string shaderName = material.shader.name;
        return shaderName == "Standard" ||
               shaderName == "Standard (Specular setup)" ||
               shaderName == "Hidden/InternalErrorShader";
    }

    public static Material GetOrCreateUrpLit(Material source, Material fallback)
    {
        if (source == null)
        {
            return fallback;
        }

        if (!NeedsUrpUpgrade(source))
        {
            return source;
        }

        if (convertedMaterials.TryGetValue(source, out Material cached) && cached != null)
        {
            return cached;
        }

        Shader litShader = GetLitShader();
        if (litShader == null)
        {
            return fallback != null ? fallback : source;
        }

        Material converted = new Material(litShader);
        CopyStandardToUrp(source, converted);
        convertedMaterials[source] = converted;
        return converted;
    }

    private static void CopyStandardToUrp(Material source, Material target)
    {
        if (source.HasProperty("_Color"))
        {
            target.SetColor("_BaseColor", source.GetColor("_Color"));
        }
        else if (source.HasProperty("_BaseColor"))
        {
            target.SetColor("_BaseColor", source.GetColor("_BaseColor"));
        }

        if (source.HasProperty("_MainTex"))
        {
            Texture baseMap = source.GetTexture("_MainTex");
            target.SetTexture("_BaseMap", baseMap);
            target.SetTextureScale("_BaseMap", source.GetTextureScale("_MainTex"));
            target.SetTextureOffset("_BaseMap", source.GetTextureOffset("_MainTex"));
        }
        else if (source.HasProperty("_BaseMap"))
        {
            Texture baseMap = source.GetTexture("_BaseMap");
            target.SetTexture("_BaseMap", baseMap);
            target.SetTextureScale("_BaseMap", source.GetTextureScale("_BaseMap"));
            target.SetTextureOffset("_BaseMap", source.GetTextureOffset("_BaseMap"));
        }

        if (source.HasProperty("_BumpMap"))
        {
            Texture normalMap = source.GetTexture("_BumpMap");
            if (normalMap != null)
            {
                target.SetTexture("_BumpMap", normalMap);
                target.EnableKeyword("_NORMALMAP");
            }

            if (source.HasProperty("_BumpScale"))
            {
                target.SetFloat("_BumpScale", source.GetFloat("_BumpScale"));
            }
        }

        if (source.HasProperty("_MetallicGlossMap"))
        {
            Texture metallicMap = source.GetTexture("_MetallicGlossMap");
            if (metallicMap != null)
            {
                target.SetTexture("_MetallicGlossMap", metallicMap);
                target.EnableKeyword("_METALLICSPECGLOSSMAP");
            }
        }

        if (source.HasProperty("_Metallic"))
        {
            target.SetFloat("_Metallic", source.GetFloat("_Metallic"));
        }

        if (source.HasProperty("_Glossiness"))
        {
            target.SetFloat("_Smoothness", source.GetFloat("_Glossiness"));
        }

        if (source.HasProperty("_OcclusionMap"))
        {
            Texture occlusionMap = source.GetTexture("_OcclusionMap");
            if (occlusionMap != null)
            {
                target.SetTexture("_OcclusionMap", occlusionMap);
            }
        }

        if (source.HasProperty("_OcclusionStrength"))
        {
            target.SetFloat("_OcclusionStrength", source.GetFloat("_OcclusionStrength"));
        }

        bool hasEmission = false;
        Color emissionColor = Color.black;
        if (source.HasProperty("_EmissionColor"))
        {
            emissionColor = source.GetColor("_EmissionColor");
            hasEmission = emissionColor.maxColorComponent > 0.001f;
        }

        Texture emissionMap = null;
        if (source.HasProperty("_EmissionMap"))
        {
            emissionMap = source.GetTexture("_EmissionMap");
            if (emissionMap != null)
            {
                hasEmission = true;
            }
        }

        if (hasEmission)
        {
            target.SetColor("_EmissionColor", emissionColor);
            target.SetTexture("_EmissionMap", emissionMap);
            target.EnableKeyword("_EMISSION");
        }
    }
}
