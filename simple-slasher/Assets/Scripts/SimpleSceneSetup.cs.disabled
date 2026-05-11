using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SimpleSceneSetup : MonoBehaviour
{
    [Header("Scene Setup")]
    [SerializeField] public bool runSetup = true;
    [SerializeField] private Color groundColor = new Color(0.3f, 0.5f, 0.3f); // Тёмно-зелёный
    [SerializeField] private Color skyColor = new Color(0.6f, 0.8f, 1.0f); // Светло-голубой
    [SerializeField] private Color ambientColor = new Color(0.6f, 0.6f, 0.6f);

    private void Awake()
    {
        if (!runSetup)
            return;

        SetupLighting();
        SetupGround();
        SetupCamera();
    }

    private void SetupLighting()
    {
        // Check if directional light already exists
        if (FindAnyObjectByType<Light>() != null)
            return;

        // Create directional light
        GameObject lightObj = new GameObject("Directional Light");
        Light light = lightObj.AddComponent<Light>();
        light.type = LightType.Directional;
        light.shadows = LightShadows.Soft;
        light.intensity = 1.5f;
        light.color = Color.white;

        // Position light at an angle
        lightObj.transform.rotation = Quaternion.Euler(50f, -30f, 0f);

        // Set ambient light
        RenderSettings.ambientMode = AmbientMode.Flat;
        RenderSettings.ambientLight = ambientColor;
        RenderSettings.ambientIntensity = 1.2f;

        // Set sky color
        RenderSettings.skybox = null;
        if (Camera.main != null)
        {
            Camera.main.backgroundColor = skyColor;
            Camera.main.clearFlags = CameraClearFlags.SolidColor;
        }

        Debug.Log("SimpleSceneSetup: Lighting configured");
    }

    private void SetupGround()
    {
        // Check if ground already exists
        GameObject existingGround = GameObject.Find("Ground");
        if (existingGround != null)
        {
            // Force update material
            UpdateGroundMaterial(existingGround);
            return;
        }

        // Create ground plane
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.position = Vector3.zero;
        ground.transform.localScale = new Vector3(10f, 1f, 10f);

        // Apply green material
        UpdateGroundMaterial(ground);

        Debug.Log("SimpleSceneSetup: Ground created with GREEN material");
    }

    private void UpdateGroundMaterial(GameObject ground)
    {
        Renderer renderer = ground.GetComponent<Renderer>();
        if (renderer == null)
            return;

        // Try different shaders
        Material groundMat = null;

        // Try URP Lit
        Shader urpLit = Shader.Find("Universal Render Pipeline/Lit");
        if (urpLit != null)
        {
            groundMat = new Material(urpLit);
            groundMat.SetColor("_BaseColor", groundColor);
            Debug.Log("Using URP Lit shader for ground");
        }
        else
        {
            // Fallback to Standard shader
            Shader standardShader = Shader.Find("Standard");
            if (standardShader != null)
            {
                groundMat = new Material(standardShader);
                groundMat.color = groundColor;
                Debug.Log("Using Standard shader for ground");
            }
            else
            {
                // Last resort - use Diffuse
                Shader diffuseShader = Shader.Find("Diffuse");
                if (diffuseShader != null)
                {
                    groundMat = new Material(diffuseShader);
                    groundMat.color = groundColor;
                    Debug.Log("Using Diffuse shader for ground");
                }
                else
                {
                    // If nothing works, just set the default material color
                    groundMat = renderer.material;
                    groundMat.color = groundColor;
                    Debug.Log("Using default material with color override");
                }
            }
        }

        if (groundMat != null)
        {
            renderer.material = groundMat;

            // Additional color setting for different shaders
            try
            {
                groundMat.SetColor("_Color", groundColor);
            }
            catch { }

            try
            {
                groundMat.SetColor("_BaseColor", groundColor);
            }
            catch { }
        }

        // Force material update
        renderer.sharedMaterial = renderer.material;
    }

    private void SetupCamera()
    {
        // Check if camera already exists (player creates one)
        if (Camera.main != null)
        {
            Camera mainCam = Camera.main;

            // Only configure if it's not a player camera
            if (mainCam.name != "PlayerCamera")
            {
                // Position camera to view the scene
                mainCam.transform.position = new Vector3(0f, 3f, -8f);
                mainCam.transform.rotation = Quaternion.Euler(15f, 0f, 0f);

                // Configure camera for URP
                if (mainCam.GetComponent<UniversalAdditionalCameraData>() == null)
                {
                    mainCam.gameObject.AddComponent<UniversalAdditionalCameraData>();
                }

                mainCam.clearFlags = CameraClearFlags.SolidColor;
                mainCam.backgroundColor = skyColor;
                mainCam.nearClipPlane = 0.1f;
                mainCam.farClipPlane = 1000f;

                Debug.Log("SimpleSceneSetup: Camera configured");
            }
            else
            {
                Debug.Log("SimpleSceneSetup: Player camera already exists, skipping camera setup");
            }
            return;
        }

        // Create camera only if no player camera exists
        // (Player controller will create its own camera)
        Debug.Log("SimpleSceneSetup: No camera found, player controller will create one");
    }
}
