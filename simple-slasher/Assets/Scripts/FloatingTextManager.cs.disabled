using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Управляет плавающим текстом для отображения урона, очков и других событий.
/// </summary>
public class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager Instance { get; private set; }

    [Header("Settings")]
    [SerializeField] private float floatDuration = 1.5f;
    [SerializeField] private float floatSpeed = 50f;
    [SerializeField] private float fadeDuration = 0.5f;

    [Header("Fonts")]
    [SerializeField] private Font damageFont;
    [SerializeField] private Font scoreFont;

    private Canvas canvas;
    private List<FloatingText> activeTexts = new List<FloatingText>();

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
        canvas = FindAnyObjectByType<Canvas>();
        if (canvas == null)
        {
            Debug.LogWarning("FloatingTextManager: No Canvas found!");
        }
    }

    /// <summary>
    /// Показывает плавающий текст на экране
    /// </summary>
    public void ShowFloatingText(string text, Vector3 screenPosition, Color color, int fontSize = 20)
    {
        if (canvas == null) return;

        FloatingText floatingText = CreateFloatingText(text, screenPosition, color, fontSize);
        activeTexts.Add(floatingText);
    }

    /// <summary>
    /// Показывает плавающий текст над 3D объектом
    /// </summary>
    public void ShowFloatingTextWorld(string text, Vector3 worldPosition, Color color, int fontSize = 20)
    {
        Camera camera = Camera.main;
        if (camera == null)
        {
            camera = FindAnyObjectByType<Camera>();
        }

        if (camera == null) return;

        Vector3 screenPosition = camera.WorldToScreenPoint(worldPosition);
        ShowFloatingText(text, screenPosition, color, fontSize);
    }

    /// <summary>
    /// Показывает урон
    /// </summary>
    public void ShowDamage(float damage, Vector3 worldPosition, bool isCritical = false)
    {
        string text = Mathf.RoundToInt(damage).ToString();
        Color color = isCritical ? new Color(1f, 0.5f, 0f) : Color.red;
        int fontSize = isCritical ? 28 : 20;

        ShowFloatingTextWorld(text, worldPosition, color, fontSize);
    }

    /// <summary>
    /// Показывает текст комбо
    /// </summary>
    public void ShowComboText(int combo, Vector3 screenPosition)
    {
        string text = $"{combo}x COMBO!";
        Color color = Color.yellow;
        ShowFloatingText(text, screenPosition, color, 24);
    }

    private FloatingText CreateFloatingText(string text, Vector3 position, Color color, int fontSize)
    {
        GameObject textObj = new GameObject("FloatingText");
        textObj.transform.SetParent(canvas.transform);

        RectTransform rectTransform = textObj.AddComponent<RectTransform>();
        rectTransform.position = position;
        rectTransform.sizeDelta = new Vector2(200, 50);

        Text textComponent = textObj.AddComponent<Text>();
        textComponent.text = text;
        textComponent.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        textComponent.fontSize = fontSize;
        textComponent.color = color;
        textComponent.alignment = TextAnchor.MiddleCenter;
        textComponent.fontStyle = FontStyle.Bold;

        Outline outline = textObj.AddComponent<Outline>();
        outline.effectColor = Color.black;
        outline.effectDistance = new Vector2(2, -2);

        Shadow shadow = textObj.AddComponent<Shadow>();
        shadow.effectColor = new Color(0, 0, 0, 0.5f);
        shadow.effectDistance = new Vector2(3, -3);

        FloatingText floatingText = textObj.AddComponent<FloatingText>();
        floatingText.Initialize(floatDuration, floatSpeed, fadeDuration);

        return floatingText;
    }

    private void LateUpdate()
    {
        // Cleanup destroyed texts
        activeTexts.RemoveAll(t => t == null);
    }
}

/// <summary>
/// Компонент для управления жизненным циклом плавающего текста
/// </summary>
public class FloatingText : MonoBehaviour
{
    private float floatDuration;
    private float floatSpeed;
    private float fadeDuration;
    private float age = 0f;
    private Text textComponent;
    private Vector3 startPosition;

    public void Initialize(float duration, float speed, float fade)
    {
        floatDuration = duration;
        floatSpeed = speed;
        fadeDuration = fade;
        textComponent = GetComponent<Text>();
        startPosition = transform.position;
    }

    private void Update()
    {
        age += Time.deltaTime;

        // Float upward
        Vector3 newPosition = startPosition;
        newPosition.y += floatSpeed * age * Time.deltaTime;
        transform.position = newPosition;

        // Scale effect
        float scale = 1f;
        if (age < 0.2f)
        {
            // Pop in
            scale = Mathf.Lerp(0.5f, 1.2f, age / 0.2f);
        }
        else if (age > floatDuration - fadeDuration)
        {
            // Fade out
            float fadeProgress = (age - (floatDuration - fadeDuration)) / fadeDuration;
            scale = Mathf.Lerp(1.2f, 0.8f, fadeProgress);

            if (textComponent != null)
            {
                Color color = textComponent.color;
                color.a = 1f - fadeProgress;
                textComponent.color = color;
            }
        }
        else
        {
            scale = 1.2f;
        }

        transform.localScale = Vector3.one * scale;

        // Destroy when done
        if (age >= floatDuration)
        {
            Destroy(gameObject);
        }
    }
}
