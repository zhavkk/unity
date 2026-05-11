using UnityEngine;

/// <summary>
/// Создаёт более реалистичную модельку игрока из примитивов
/// </summary>
public class PlayerModelCreator : MonoBehaviour
{
    public static void CreatePlayerModel(GameObject player)
    {
        // Создаём контейнер для модели
        GameObject modelContainer = new GameObject("PlayerModel");
        modelContainer.transform.SetParent(player.transform);
        modelContainer.transform.localPosition = new Vector3(0f, 0f, 0f);

        // Материалы
        Material skinMaterial = CreateMaterial(Color.white);
        Material clothesMaterial = CreateMaterial(new Color(0.2f, 0.4f, 0.8f)); // Синяя одежда
        Material hairMaterial = CreateMaterial(new Color(0.3f, 0.2f, 0.1f)); // Тёмные волосы

        // Тело (капсула)
        GameObject body = CreatePrimitive(modelContainer.transform, PrimitiveType.Capsule, "Body", skinMaterial);
        body.transform.localPosition = new Vector3(0f, 1f, 0f);
        body.transform.localScale = new Vector3(0.4f, 0.8f, 0.2f);

        // Голова (сфера)
        GameObject head = CreatePrimitive(modelContainer.transform, PrimitiveType.Sphere, "Head", skinMaterial);
        head.transform.localPosition = new Vector3(0f, 1.6f, 0f);
        head.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);

        // Волосы
        GameObject hair = CreatePrimitive(modelContainer.transform, PrimitiveType.Sphere, "Hair", hairMaterial);
        hair.transform.localPosition = new Vector3(0f, 1.75f, 0f);
        hair.transform.localScale = new Vector3(0.28f, 0.2f, 0.28f);

        // Торс (куб)
        GameObject torso = CreatePrimitive(modelContainer.transform, PrimitiveType.Cube, "Torso", clothesMaterial);
        torso.transform.localPosition = new Vector3(0f, 1.1f, 0f);
        torso.transform.localScale = new Vector3(0.5f, 0.5f, 0.25f);

        // Руки (капсулы)
        GameObject leftArm = CreatePrimitive(modelContainer.transform, PrimitiveType.Capsule, "LeftArm", skinMaterial);
        leftArm.transform.localPosition = new Vector3(-0.4f, 1.2f, 0f);
        leftArm.transform.localScale = new Vector3(0.15f, 0.5f, 0.15f);
        leftArm.transform.rotation = Quaternion.Euler(0f, 0f, 20f);

        GameObject rightArm = CreatePrimitive(modelContainer.transform, PrimitiveType.Capsule, "RightArm", skinMaterial);
        rightArm.transform.localPosition = new Vector3(0.4f, 1.2f, 0f);
        rightArm.transform.localScale = new Vector3(0.15f, 0.5f, 0.15f);
        rightArm.transform.rotation = Quaternion.Euler(0f, 0f, -20f);

        // Ноги (капсулы)
        GameObject leftLeg = CreatePrimitive(modelContainer.transform, PrimitiveType.Capsule, "LeftLeg", clothesMaterial);
        leftLeg.transform.localPosition = new Vector3(-0.15f, 0.5f, 0f);
        leftLeg.transform.localScale = new Vector3(0.15f, 0.5f, 0.15f);

        GameObject rightLeg = CreatePrimitive(modelContainer.transform, PrimitiveType.Capsule, "RightLeg", clothesMaterial);
        rightLeg.transform.localPosition = new Vector3(0.15f, 0.5f, 0f);
        rightLeg.transform.localScale = new Vector3(0.15f, 0.5f, 0.15f);

        // Добавляем меч (оружие)
        GameObject sword = CreateWeapon(modelContainer.transform);
        sword.transform.localPosition = new Vector3(0.5f, 1.2f, 0.2f);
        sword.transform.rotation = Quaternion.Euler(0f, -90f, -45f);
    }

    private static GameObject CreatePrimitive(Transform parent, PrimitiveType type, string name, Material material)
    {
        GameObject primitive = GameObject.CreatePrimitive(type);
        primitive.name = name;
        primitive.transform.SetParent(parent);

        // Удаляем коллайдер (для визуала не нужен)
        Collider collider = primitive.GetComponent<Collider>();
        if (collider != null)
        {
            Destroy(collider);
        }

        // Применяем материал
        Renderer renderer = primitive.GetComponent<Renderer>();
        if (renderer != null && material != null)
        {
            renderer.material = material;
        }

        return primitive;
    }

    private static GameObject CreateWeapon(Transform parent)
    {
        GameObject weapon = new GameObject("Sword");
        weapon.transform.SetParent(parent);

        // Рукоять
        GameObject handle = CreatePrimitive(weapon.transform, PrimitiveType.Cylinder, "Handle", CreateMaterial(new Color(0.4f, 0.3f, 0.2f)));
        handle.transform.localPosition = new Vector3(0f, 0f, 0f);
        handle.transform.localScale = new Vector3(0.05f, 0.3f, 0.05f);
        handle.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        // Гарда
        GameObject guard = CreatePrimitive(weapon.transform, PrimitiveType.Cylinder, "Guard", CreateMaterial(Color.gray));
        guard.transform.localPosition = new Vector3(0f, 0.15f, 0f);
        guard.transform.localScale = new Vector3(0.2f, 0.03f, 0.03f);
        guard.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        // Лезвие
        GameObject blade = CreatePrimitive(weapon.transform, PrimitiveType.Cylinder, "Blade", CreateMaterial(new Color(0.9f, 0.9f, 0.95f)));
        blade.transform.localPosition = new Vector3(0f, 0.6f, 0f);
        blade.transform.localScale = new Vector3(0.08f, 0.8f, 0.02f);
        blade.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        // Остриё (используем цилиндр, так как Cone не существует)
        GameObject tip = CreatePrimitive(weapon.transform, PrimitiveType.Cylinder, "Tip", CreateMaterial(new Color(0.9f, 0.9f, 0.95f)));
        tip.transform.localPosition = new Vector3(0f, 1.1f, 0f);
        tip.transform.localScale = new Vector3(0.06f, 0.15f, 0.02f); // Сужающийся конус
        tip.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);

        return weapon;
    }

    private static Material CreateMaterial(Color color)
    {
        // Пробуем URP шейдер, если не работает - используем Standard
        Shader urpLit = Shader.Find("Universal Render Pipeline/Lit");
        Material mat;

        if (urpLit != null)
        {
            mat = new Material(urpLit);
        }
        else
        {
            mat = new Material(Shader.Find("Standard"));
        }

        mat.color = color;
        return mat;
    }
}
