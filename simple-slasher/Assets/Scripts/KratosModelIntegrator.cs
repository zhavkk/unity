using UnityEngine;

/// <summary>
/// Simple integrator script for adding Kratos model to existing GameObjects.
/// Just add this component to any GameObject (like a Player) and it will handle the model.
/// </summary>
public class KratosModelIntegrator : MonoBehaviour
{
    [Header("Integration Settings")]
    [SerializeField] private bool integrateOnStart = true;
    [SerializeField] private bool destroyExistingModel = true;
    [SerializeField] private Vector3 localPosition = Vector3.zero;
    [SerializeField] private Vector3 localRotation = Vector3.zero;
    [SerializeField] private Vector3 localScale = Vector3.one;

    [Header("Optional References")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private bool configureAttackPoint = true;

    private GameObject kratosModel;

    void Start()
    {
        if (integrateOnStart)
        {
            IntegrateKratosModel();
        }
    }

    [ContextMenu("Integrate Kratos Model")]
    public void IntegrateKratosModel()
    {
        // Remove existing model if requested
        if (destroyExistingModel)
        {
            RemoveExistingModel();
        }

        // Create new Kratos model
        Debug.Log($"🪓 Integrating Kratos model into {gameObject.name}...");

        kratosModel = KratosModelGenerator.CreateUltimateKratosModel();
        kratosModel.transform.SetParent(transform);
        kratosModel.transform.localPosition = localPosition;
        kratosModel.transform.localRotation = Quaternion.Euler(localRotation);
        kratosModel.transform.localScale = localScale;

        Debug.Log($"✅ Kratos model integrated successfully!");

        // Configure attack point if requested
        if (configureAttackPoint)
        {
            ConfigureAttackPoint();
        }

        // Notify other systems
        NotifyModelIntegrated();
    }

    private void RemoveExistingModel()
    {
        Transform existingModel = transform.Find("UltimateKratos");
        if (existingModel != null)
        {
            DestroyImmediate(existingModel.gameObject);
            Debug.Log("🗑️ Removed existing Kratos model");
        }
    }

    private void ConfigureAttackPoint()
    {
        // Find or create attack point
        if (attackPoint == null)
        {
            Transform existingAttackPoint = transform.Find("AttackPoint");
            if (existingAttackPoint != null)
            {
                attackPoint = existingAttackPoint;
            }
            else
            {
                GameObject newAttackPoint = new GameObject("AttackPoint");
                newAttackPoint.transform.SetParent(transform);
                attackPoint = newAttackPoint.transform;
            }
        }

        // Position attack point near the axe
        Transform axe = kratosModel.transform.Find("UltimateLeviathanAxe");
        if (axe != null)
        {
            // Position attack point at the tip of the axe
            attackPoint.localPosition = new Vector3(1.5f, 0.5f, 1.0f);
            Debug.Log("⚔️ Attack point configured near Leviathan Axe");
        }
        else
        {
            // Fallback position
            attackPoint.localPosition = new Vector3(0, 1f, 1.5f);
            Debug.Log("⚔️ Attack point configured (fallback position)");
        }
    }

    private void NotifyModelIntegrated()
    {
        // Notify EnhancedPlayerController if present
        EnhancedPlayerController playerController = GetComponent<EnhancedPlayerController>();
        if (playerController != null)
        {
            Debug.Log("🎮 EnhancedPlayerController detected - model is ready for enhanced features");
        }


        // Notify CharacterController if present
        CharacterController charController = GetComponent<CharacterController>();
        if (charController != null)
        {
            Debug.Log($"🎮 CharacterController detected - model scale compatible");
        }
    }

    [ContextMenu("Remove Kratos Model")]
    public void RemoveKratosModel()
    {
        RemoveExistingModel();
        kratosModel = null;
        Debug.Log("🗑️ Kratos model removed");
    }

    [ContextMenu("Reset to Default Position")]
    public void ResetPosition()
    {
        if (kratosModel != null)
        {
            kratosModel.transform.localPosition = Vector3.zero;
            kratosModel.transform.localRotation = Quaternion.identity;
            kratosModel.transform.localScale = Vector3.one;
            Debug.Log("🔄 Kratos model position reset");
        }
    }

    // Public getters for other systems
    public GameObject GetKratosModel()
    {
        return kratosModel;
    }

    public Transform GetAxeTransform()
    {
        if (kratosModel != null)
        {
            return kratosModel.transform.Find("UltimateLeviathanAxe");
        }
        return null;
    }

    public Transform GetRightHandTransform()
    {
        if (kratosModel != null)
        {
            return kratosModel.transform.Find("RightHand");
        }
        return null;
    }

    public Transform GetLeftHandTransform()
    {
        if (kratosModel != null)
        {
            return kratosModel.transform.Find("LeftHand");
        }
        return null;
    }

    public Transform GetHeadTransform()
    {
        if (kratosModel != null)
        {
            return kratosModel.transform.Find("Head");
        }
        return null;
    }
}

#if UNITY_EDITOR
/// <summary>
/// Custom editor for KratosModelIntegrator with helpful buttons.
/// </summary>
[UnityEditor.CustomEditor(typeof(KratosModelIntegrator))]
public class KratosModelIntegratorEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        KratosModelIntegrator integrator = (KratosModelIntegrator)target;

        DrawDefaultInspector();

        GUILayout.Space(10);
        GUILayout.Label("Quick Actions", UnityEditor.EditorStyles.boldLabel);

        // Integration button
        GUI.backgroundColor = new Color(0.4f, 0.8f, 0.4f);
        if (GUILayout.Button("🪓 Integrate Kratos Model", GUILayout.Height(40)))
        {
            integrator.IntegrateKratosModel();
        }
        GUI.backgroundColor = Color.white;

        GUILayout.Space(5);

        // Removal button
        GUI.backgroundColor = new Color(0.8f, 0.4f, 0.4f);
        if (GUILayout.Button("🗑️ Remove Kratos Model", GUILayout.Height(30)))
        {
            integrator.RemoveKratosModel();
        }
        GUI.backgroundColor = Color.white;

        GUILayout.Space(5);

        // Reset button
        if (GUILayout.Button("🔄 Reset Position", GUILayout.Height(30)))
        {
            integrator.ResetPosition();
        }

        GUILayout.Space(10);
        GUILayout.Label("Model Transforms", UnityEditor.EditorStyles.boldLabel);

        // Display transform info
        if (integrator.GetKratosModel() != null)
        {
            GUILayout.Label($"✅ Model Status: Active");
            GUILayout.Label($"📏 Position: {integrator.GetKratosModel().transform.localPosition}");
            GUILayout.Label($"🔄 Rotation: {integrator.GetKratosModel().transform.localRotation.eulerAngles}");
            GUILayout.Label($"📐 Scale: {integrator.GetKratosModel().transform.localScale}");

            GUILayout.Space(5);

            // Check key components
            if (integrator.GetAxeTransform() != null)
            {
                GUILayout.Label("🪓 Leviathan Axe: ✅ Found");
            }
            else
            {
                GUILayout.Label("🪓 Leviathan Axe: ❌ Not Found");
            }

            if (integrator.GetHeadTransform() != null)
            {
                GUILayout.Label("😐 Head: ✅ Found");
            }
            else
            {
                GUILayout.Label("😐 Head: ❌ Not Found");
            }
        }
        else
        {
            GUILayout.Label("❌ No model integrated yet");
            GUILayout.Label("Click 'Integrate Kratos Model' to begin");
        }

        GUILayout.Space(10);
        GUILayout.Label("Help", UnityEditor.EditorStyles.boldLabel);
        GUILayout.Label("This component automatically integrates the");
        GUILayout.Label("Kratos model into this GameObject.");
        GUILayout.Label("Use the buttons above to manage the model.");
    }
}
#endif
