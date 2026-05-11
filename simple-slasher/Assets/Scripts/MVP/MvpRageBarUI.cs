using UnityEngine;
using UnityEngine.UI;

public class MvpRageBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private MvpRageSystem rageSystem;

    public void Initialize(Image fill, MvpRageSystem rage)
    {
        fillImage = fill;
        rageSystem = rage;
    }

    private void Update()
    {
        if (fillImage == null || rageSystem == null)
        {
            return;
        }

        float value = rageSystem.NormalizedRage;
        fillImage.fillAmount = Mathf.Clamp01(value);
        fillImage.color = Color.Lerp(Color.white, Color.red, value);
    }
}
