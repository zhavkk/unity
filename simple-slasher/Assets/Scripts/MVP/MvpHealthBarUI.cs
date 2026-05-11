using UnityEngine;
using UnityEngine.UI;

public class MvpHealthBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Text valueText;

    private MvpPlayerHealth playerHealth;

    public void Initialize(Image fill, Text text, MvpPlayerHealth health)
    {
        fillImage = fill;
        valueText = text;
        playerHealth = health;
        UpdateFill();

        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += HandleHealthChanged;
        }
    }

    private void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= HandleHealthChanged;
        }
    }

    private void HandleHealthChanged(float current, float max)
    {
        UpdateFill();
    }

    private void UpdateFill()
    {
        if (fillImage == null || playerHealth == null)
        {
            return;
        }

        float value = playerHealth.NormalizedHealth;
        fillImage.fillAmount = Mathf.Clamp01(value);
        fillImage.color = Color.Lerp(Color.red, new Color(0.2f, 0.9f, 0.2f, 1f), value);

        if (valueText != null)
        {
            int current = Mathf.CeilToInt(playerHealth.CurrentHealth);
            int max = Mathf.CeilToInt(playerHealth.MaxHealth);
            valueText.text = $"HP {current}/{max}";
        }
    }
}
