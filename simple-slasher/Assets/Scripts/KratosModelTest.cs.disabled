using UnityEngine;

/// <summary>
/// Test script for verifying Kratos model integration.
/// Attach to any GameObject and press Play to test.
/// </summary>
public class KratosModelTest : MonoBehaviour
{
    [Header("Test Settings")]
    [SerializeField] private bool createOnStart = true;
    [SerializeField] private bool autoRotate = false;
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private bool displayInfo = true;

    private GameObject kratosModel;
    private int componentCount;
    private Renderer[] renderers;

    void Start()
    {
        if (createOnStart)
        {
            CreateKratosModel();
        }
    }

    void Update()
    {
        if (autoRotate && kratosModel != null)
        {
            kratosModel.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        if (displayInfo && kratosModel != null)
        {
            UpdateDebugInfo();
        }
    }

    [ContextMenu("Create Kratos Model")]
    public void CreateKratosModel()
    {
        // Remove existing model if any
        Transform existingModel = transform.Find("UltimateKratos");
        if (existingModel != null)
        {
            DestroyImmediate(existingModel.gameObject);
        }

        Debug.Log("=== Creating Ultimate Kratos Model ===");

        // Create the model
        kratosModel = KratosModelGenerator.CreateUltimateKratosModel();
        kratosModel.transform.SetParent(transform);
        kratosModel.transform.localPosition = Vector3.zero;
        kratosModel.transform.localRotation = Quaternion.identity;

        // Count components
        componentCount = kratosModel.GetComponentsInChildren<Transform>().Length;
        renderers = kratosModel.GetComponentsInChildren<Renderer>();

        Debug.Log($"✅ Kratos model created successfully!");
        Debug.Log($"📊 Model Statistics:");
        Debug.Log($"   - Total components: {componentCount}");
        Debug.Log($"   - Renderers: {renderers.Length}");
        Debug.Log($"   - Materials: {GetUniqueMaterialCount()}");

        // Verify key components
        VerifyModelComponents();
    }

    private int GetUniqueMaterialCount()
    {
        System.Collections.Generic.HashSet<Material> materials = new System.Collections.Generic.HashSet<Material>();
        foreach (Renderer renderer in renderers)
        {
            if (renderer.material != null)
            {
                materials.Add(renderer.material);
            }
        }
        return materials.Count;
    }

    private void VerifyModelComponents()
    {
        Debug.Log("🔍 Verifying model components...");

        string[] requiredComponents = {
            "Torso", "Head", "LeftUpperArm", "RightUpperArm",
            "LeftThigh", "RightThigh", "UltimateLeviathanAxe"
        };

        int foundCount = 0;
        foreach (string componentName in requiredComponents)
        {
            Transform component = kratosModel.transform.Find(componentName);
            if (component != null)
            {
                foundCount++;
                Debug.Log($"   ✅ {componentName} found");
            }
            else
            {
                Debug.LogWarning($"   ❌ {componentName} NOT found");
            }
        }

        Debug.Log($"📋 Component verification: {foundCount}/{requiredComponents.Length} components found");

        // Check for tattoos
        Transform tattooLeft = kratosModel.transform.Find("TattooLeftMain");
        Transform tattooRight = kratosModel.transform.Find("TattooRightMain");
        if (tattooLeft != null && tattooRight != null)
        {
            Debug.Log("   ✅ Facial tattoos verified");
        }

        // Check for axe
        Transform axe = kratosModel.transform.Find("UltimateLeviathanAxe");
        if (axe != null)
        {
            Debug.Log("   ✅ Leviathan Axe verified");
            int axeComponents = axe.GetComponentsInChildren<Transform>().Length;
            Debug.Log($"   🪓 Axe components: {axeComponents}");
        }

        // Check for armor
        Transform leftShoulder = kratosModel.transform.Find("LeftShoulderBase");
        Transform rightShoulder = kratosModel.transform.Find("RightShoulderBase");
        if (leftShoulder != null && rightShoulder != null)
        {
            Debug.Log("   ✅ Shoulder armor verified");
        }
    }

    private void UpdateDebugInfo()
    {
        // This could display on-screen info if needed
        // For now, we'll just log periodically
        if (Time.frameCount % 60 == 0) // Every ~1 second
        {
            Debug.Log($"🔄 Model active - Components: {componentCount}, Renderers: {renderers.Length}");
        }
    }

    [ContextMenu("Test Model Materials")]
    public void TestModelMaterials()
    {
        if (kratosModel == null)
        {
            Debug.LogError("❌ No Kratos model found! Create one first.");
            return;
        }

        Debug.Log("=== Testing Model Materials ===");

        renderers = kratosModel.GetComponentsInChildren<Renderer>();
        System.Collections.Generic.Dictionary<string, int> materialColors = new System.Collections.Generic.Dictionary<string, int>();

        foreach (Renderer renderer in renderers)
        {
            if (renderer.material != null)
            {
                Color color = renderer.material.color;
                string colorKey = $"R{color.r:F2}_G{color.g:F2}_B{color.b:F2}";

                if (materialColors.ContainsKey(colorKey))
                {
                    materialColors[colorKey]++;
                }
                else
                {
                    materialColors[colorKey] = 1;
                }
            }
        }

        Debug.Log($"📊 Material Statistics:");
        Debug.Log($"   - Unique materials: {materialColors.Count}");

        foreach (var kvp in materialColors)
        {
            Debug.Log($"   - Color {kvp.Key}: {kvp.Value} objects");
        }
    }

    [ContextMenu("Clear Model")]
    public void ClearModel()
    {
        if (kratosModel != null)
        {
            DestroyImmediate(kratosModel);
            kratosModel = null;
            Debug.Log("🗑️ Kratos model cleared");
        }
    }

    [ContextMenu("Test Scale Compatibility")]
    public void TestScaleCompatibility()
    {
        if (kratosModel == null)
        {
            Debug.LogError("❌ No Kratos model found! Create one first.");
            return;
        }

        Debug.Log("=== Testing Scale Compatibility ===");

        // Get model bounds
        Renderer[] modelRenderers = kratosModel.GetComponentsInChildren<Renderer>();
        Bounds totalBounds = new Bounds(kratosModel.transform.position, Vector3.zero);

        foreach (Renderer renderer in modelRenderers)
        {
            totalBounds.Encapsulate(renderer.bounds);
        }

        Vector3 size = totalBounds.size;
        float height = size.y;
        float width = size.x;
        float depth = size.z;

        Debug.Log($"📏 Model Dimensions:");
        Debug.Log($"   - Height: {height:F2} units");
        Debug.Log($"   - Width: {width:F2} units");
        Debug.Log($"   - Depth: {depth:F2} units");

        // Check CharacterController compatibility
        Debug.Log($"🎮 CharacterController Compatibility:");
        if (height >= 1.8f && height <= 2.5f)
        {
            Debug.Log($"   ✅ Height compatible (recommended: 2.0f)");
        }
        else
        {
            Debug.LogWarning($"   ⚠️ Height may need adjustment (current: {height:F2})");
        }

        if (width >= 0.8f && width <= 1.5f)
        {
            Debug.Log($"   ✅ Width compatible (recommended: 1.0f)");
        }
        else
        {
            Debug.LogWarning($"   ⚠️ Width may need adjustment (current: {width:F2})");
        }
    }

    void OnGUI()
    {
        if (!displayInfo || kratosModel == null) return;

        GUILayout.BeginArea(new Rect(10, 10, 300, 200));
        GUILayout.BeginVertical("box");

        GUILayout.Label("🪓 Kratos Model Test", GUI.skin.box);
        GUILayout.Space(10);

        GUILayout.Label($"Components: {componentCount}");
        GUILayout.Label($"Renderers: {renderers?.Length ?? 0}");
        GUILayout.Label($"Materials: {GetUniqueMaterialCount()}");

        GUILayout.Space(10);

        if (GUILayout.Button("Test Materials"))
        {
            TestModelMaterials();
        }

        if (GUILayout.Button("Test Scale"))
        {
            TestScaleCompatibility();
        }

        if (GUILayout.Button("Clear Model"))
        {
            ClearModel();
        }

        if (GUILayout.Button("Create New Model"))
        {
            CreateKratosModel();
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(KratosModelTest))]
public class KratosModelTestEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        KratosModelTest test = (KratosModelTest)target;

        GUILayout.Space(10);
        GUILayout.Label("Quick Actions", UnityEditor.EditorStyles.boldLabel);

        if (GUILayout.Button("Create Kratos Model", GUILayout.Height(30)))
        {
            test.CreateKratosModel();
        }

        if (GUILayout.Button("Test Materials", GUILayout.Height(30)))
        {
            test.TestModelMaterials();
        }

        if (GUILayout.Button("Test Scale Compatibility", GUILayout.Height(30)))
        {
            test.TestScaleCompatibility();
        }

        if (GUILayout.Button("Clear Model", GUILayout.Height(30)))
        {
            test.ClearModel();
        }
    }
}
#endif
