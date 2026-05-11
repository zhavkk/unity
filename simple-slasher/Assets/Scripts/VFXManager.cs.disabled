using UnityEngine;
using System.Collections;

/// <summary>
/// Управляет всеми визуальными эффектами в игре.
/// Создает и управляет партиклами для атак, ярости и других эффектов.
/// </summary>
public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance { get; private set; }

    [Header("Attack Effects")]
    [SerializeField] private GameObject slashEffectPrefab;
    [SerializeField] private GameObject hitEffectPrefab;
    [SerializeField] private float slashEffectDuration = 0.3f;

    [Header("Rage Effects")]
    [SerializeField] private GameObject rageAuraPrefab;
    [SerializeField] private GameObject rageBurstPrefab;
    [SerializeField] private Color rageColor = new Color(1f, 0.3f, 0f);

    [Header("Attract Effects")]
    [SerializeField] private GameObject dashTrailPrefab;
    [SerializeField] private GameObject targetIndicatorPrefab;
    [SerializeField] private Color attractColor = new Color(0.3f, 0.5f, 1f);

    [Header("Death Effects")]
    [SerializeField] private GameObject enemyDeathPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Create prefabs if not assigned
        CreateDefaultPrefabs();
    }

    private void CreateDefaultPrefabs()
    {
        if (slashEffectPrefab == null)
        {
            slashEffectPrefab = CreateSlashEffectPrefab();
        }

        if (hitEffectPrefab == null)
        {
            hitEffectPrefab = CreateHitEffectPrefab();
        }

        if (rageAuraPrefab == null)
        {
            rageAuraPrefab = CreateRageAuraPrefab();
        }

        if (rageBurstPrefab == null)
        {
            rageBurstPrefab = CreateRageBurstPrefab();
        }

        if (dashTrailPrefab == null)
        {
            dashTrailPrefab = CreateDashTrailPrefab();
        }

        if (targetIndicatorPrefab == null)
        {
            targetIndicatorPrefab = CreateTargetIndicatorPrefab();
        }

        if (enemyDeathPrefab == null)
        {
            enemyDeathPrefab = CreateDeathEffectPrefab();
        }
    }

    #region Attack Effects
    public void PlaySlashEffect(Vector3 position, Vector3 direction)
    {
        GameObject effect = Instantiate(slashEffectPrefab, position, Quaternion.LookRotation(direction));
        Destroy(effect, slashEffectDuration);
    }

    public void PlayHitEffect(Vector3 position)
    {
        GameObject effect = Instantiate(hitEffectPrefab, position, Quaternion.identity);
        Destroy(effect, 0.5f);
    }

    private GameObject CreateSlashEffectPrefab()
    {
        GameObject prefab = new GameObject("SlashEffect");

        // Create visual arc
        GameObject arc = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        arc.transform.SetParent(prefab.transform);
        arc.transform.localPosition = Vector3.zero;
        arc.transform.localRotation = Quaternion.Euler(0, 0, 90);
        arc.transform.localScale = new Vector3(0.05f, 1f, 0.5f);

        Renderer renderer = arc.GetComponent<Renderer>();
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = new Color(1f, 0.8f, 0.2f, 0.8f);
        mat.SetFloat("_Metallic", 0.5f);
        mat.SetFloat("_Glossiness", 0.8f);
        renderer.material = mat;

        Destroy(arc.GetComponent<Collider>());

        // Add animator for smooth fade
        Animator animator = prefab.AddComponent<Animator>();
        animator.runtimeAnimatorController = null;

        // Add component to handle animation
        SlashEffectAnimation anim = prefab.AddComponent<SlashEffectAnimation>();
        return prefab;
    }

    private GameObject CreateHitEffectPrefab()
    {
        GameObject prefab = new GameObject("HitEffect");

        // Create burst of particles
        for (int i = 0; i < 8; i++)
        {
            GameObject particle = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            particle.transform.SetParent(prefab.transform);
            particle.transform.localScale = Vector3.one * 0.2f;

            Renderer renderer = particle.GetComponent<Renderer>();
            Material mat = new Material(Shader.Find("Standard"));
            mat.color = Color.red;
            renderer.material = mat;

            Destroy(particle.GetComponent<Collider>());

            HitParticle hitParticle = particle.AddComponent<HitParticle>();
            hitParticle.direction = Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward;
            hitParticle.speed = Random.Range(3f, 6f);
        }

        return prefab;
    }
    #endregion

    #region Rage Effects
    public void PlayRageAura(Transform target, float intensity)
    {
        if (rageAuraPrefab != null && intensity > 0.3f)
        {
            GameObject aura = Instantiate(rageAuraPrefab, target.position, Quaternion.identity);
            aura.transform.SetParent(target);
            aura.transform.localScale = Vector3.one * (1f + intensity * 0.5f);

            RageAuraEffect auraEffect = aura.GetComponent<RageAuraEffect>();
            if (auraEffect != null)
            {
                auraEffect.intensity = intensity;
            }

            // Auto destroy when rage ends
            Destroy(aura, 2f);
        }
    }

    public void PlayRageBurst(Vector3 position)
    {
        GameObject burst = Instantiate(rageBurstPrefab, position, Quaternion.identity);
        Destroy(burst, 1f);
    }

    private GameObject CreateRageAuraPrefab()
    {
        GameObject prefab = new GameObject("RageAura");

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.SetParent(prefab.transform);
        sphere.transform.localScale = Vector3.one * 1.5f;

        Renderer renderer = sphere.GetComponent<Renderer>();
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = new Color(rageColor.r, rageColor.g, rageColor.b, 0.3f);
        mat.SetFloat("_Metallic", 0.8f);
        mat.SetFloat("_Glossiness", 0.9f);
        renderer.material = mat;

        Destroy(sphere.GetComponent<Collider>());

        RageAuraEffect auraEffect = prefab.AddComponent<RageAuraEffect>();
        return prefab;
    }

    private GameObject CreateRageBurstPrefab()
    {
        GameObject prefab = new GameObject("RageBurst");

        // Create expanding ring
        GameObject ring = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        ring.transform.SetParent(prefab.transform);
        ring.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        Renderer renderer = ring.GetComponent<Renderer>();
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = rageColor;
        renderer.material = mat;

        Destroy(ring.GetComponent<Collider>());

        RageBurstEffect burst = prefab.AddComponent<RageBurstEffect>();
        return prefab;
    }
    #endregion

    #region Attract Effects
    public void PlayDashTrail(Vector3 startPosition, Vector3 endPosition)
    {
        GameObject trail = Instantiate(dashTrailPrefab, startPosition, Quaternion.identity);
        DashTrailEffect trailEffect = trail.GetComponent<DashTrailEffect>();
        if (trailEffect != null)
        {
            trailEffect.Initialize(startPosition, endPosition);
        }
        Destroy(trail, 0.5f);
    }

    public void ShowTargetIndicator(Vector3 position, float duration = 1f)
    {
        GameObject indicator = Instantiate(targetIndicatorPrefab, position, Quaternion.identity);
        Destroy(indicator, duration);
    }

    private GameObject CreateDashTrailPrefab()
    {
        GameObject prefab = new GameObject("DashTrail");

        GameObject trail = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        trail.transform.SetParent(prefab.transform);
        trail.transform.localScale = new Vector3(0.2f, 1f, 0.2f);

        Renderer renderer = trail.GetComponent<Renderer>();
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = new Color(attractColor.r, attractColor.g, attractColor.b, 0.6f);
        renderer.material = mat;

        Destroy(trail.GetComponent<Collider>());

        DashTrailEffect trailEffect = prefab.AddComponent<DashTrailEffect>();
        return prefab;
    }

    private GameObject CreateTargetIndicatorPrefab()
    {
        GameObject prefab = new GameObject("TargetIndicator");

        // Use Cylinder instead of Torus (which doesn't exist)
        GameObject ring = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        ring.transform.SetParent(prefab.transform);
        ring.transform.localScale = new Vector3(0.1f, 2f, 2f);
        ring.transform.rotation = Quaternion.Euler(90, 0, 0);

        Renderer renderer = ring.GetComponent<Renderer>();
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = attractColor;
        mat.SetFloat("_Metallic", 0.8f);
        mat.SetFloat("_Glossiness", 0.9f);
        renderer.material = mat;

        Destroy(ring.GetComponent<Collider>());

        TargetIndicatorAnimation anim = prefab.AddComponent<TargetIndicatorAnimation>();
        return prefab;
    }
    #endregion

    #region Death Effects
    public void PlayDeathEffect(Vector3 position)
    {
        GameObject effect = Instantiate(enemyDeathPrefab, position, Quaternion.identity);
        Destroy(effect, 1f);
    }

    private GameObject CreateDeathEffectPrefab()
    {
        GameObject prefab = new GameObject("DeathEffect");

        // Create particle explosion
        for (int i = 0; i < 12; i++)
        {
            GameObject particle = GameObject.CreatePrimitive(PrimitiveType.Cube);
            particle.transform.SetParent(prefab.transform);
            particle.transform.localScale = Vector3.one * 0.15f;

            Renderer renderer = particle.GetComponent<Renderer>();
            Material mat = new Material(Shader.Find("Standard"));
            mat.color = new Color(0.8f, 0.2f, 0.2f);
            renderer.material = mat;

            Destroy(particle.GetComponent<Collider>());

            DeathParticle deathParticle = particle.AddComponent<DeathParticle>();
            deathParticle.direction = Quaternion.Euler(Random.Range(-45, 45), Random.Range(0, 360), Random.Range(-45, 45)) * Vector3.forward;
            deathParticle.speed = Random.Range(2f, 5f);
            deathParticle.rotationSpeed = Random.Range(180, 360);
        }

        return prefab;
    }
    #endregion
}

#region Effect Components
public class SlashEffectAnimation : MonoBehaviour
{
    private float age = 0f;
    private float maxAge = 0.3f;

    void Update()
    {
        age += Time.deltaTime;
        float progress = age / maxAge;

        // Scale up and fade
        transform.localScale = Vector3.one * (1f + progress * 0.5f);

        // Rotate
        transform.Rotate(0, 0, -300 * Time.deltaTime);

        if (age >= maxAge)
        {
            Destroy(gameObject);
        }
    }
}

public class HitParticle : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        transform.localScale *= 0.95f;

        if (transform.localScale.x < 0.01f)
        {
            Destroy(gameObject);
        }
    }
}

public class RageAuraEffect : MonoBehaviour
{
    public float intensity = 1f;

    void Update()
    {
        // Pulse effect
        float pulse = Mathf.Sin(Time.time * 5f) * 0.1f + 1f;
        transform.localScale = Vector3.one * (1.5f + intensity * 0.5f) * pulse;

        // Rotate
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }
}

public class RageBurstEffect : MonoBehaviour
{
    private float age = 0f;
    private float maxAge = 1f;

    void Update()
    {
        age += Time.deltaTime;
        float progress = age / maxAge;

        // Expand rapidly
        float scale = Mathf.Lerp(0.1f, 5f, progress);
        transform.localScale = Vector3.one * scale;

        // Fade out
        Renderer renderer = GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            Color color = renderer.material.color;
            color.a = 1f - progress;
            renderer.material.color = color;
        }

        if (age >= maxAge)
        {
            Destroy(gameObject);
        }
    }
}

public class DashTrailEffect : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float age = 0f;
    private float maxAge = 0.5f;

    public void Initialize(Vector3 start, Vector3 end)
    {
        startPosition = start;
        endPosition = end;
        transform.position = start;

        // Orient towards end
        Vector3 direction = (end - start).normalized;
        transform.rotation = Quaternion.LookRotation(direction);

        // Scale to fit distance
        float distance = Vector3.Distance(start, end);
        transform.localScale = new Vector3(1f, distance, 1f);
    }

    void Update()
    {
        age += Time.deltaTime;
        float progress = age / maxAge;

        // Fade out
        Renderer renderer = GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            Color color = renderer.material.color;
            color.a = 0.6f * (1f - progress);
            renderer.material.color = color;
        }

        if (age >= maxAge)
        {
            Destroy(gameObject);
        }
    }
}

public class TargetIndicatorAnimation : MonoBehaviour
{
    void Update()
    {
        // Pulse and rotate
        float pulse = Mathf.Sin(Time.time * 8f) * 0.2f + 1f;
        transform.localScale = Vector3.one * 2f * pulse;
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
}

public class DeathParticle : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float rotationSpeed;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, 0);

        speed *= 0.95f;

        if (speed < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
#endregion
