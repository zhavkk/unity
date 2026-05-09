using UnityEngine;

/// <summary>
/// Создаёт более реалистичные модели врагов из примитивов
/// </summary>
public class EnemyModelCreator : MonoBehaviour
{
    public static void CreateEnemyModel(GameObject enemy, EnemyType type = EnemyType.Normal)
    {
        // Создаём контейнер для модели
        GameObject modelContainer = new GameObject("EnemyModel");
        modelContainer.transform.SetParent(enemy.transform);
        modelContainer.transform.localPosition = new Vector3(0f, 0f, 0f);

        switch (type)
        {
            case EnemyType.Normal:
                CreateNormalEnemy(modelContainer);
                break;
            case EnemyType.Fast:
                CreateFastEnemy(modelContainer);
                break;
            case EnemyType.Tank:
                CreateTankEnemy(modelContainer);
                break;
            case EnemyType.Ranged:
                CreateRangedEnemy(modelContainer);
                break;
        }
    }

    private static void CreateNormalEnemy(GameObject parent)
    {
        // Красный гуманоидный враг
        Material skinMaterial = CreateMaterial(new Color(0.8f, 0.2f, 0.2f)); // Красная кожа
        Material armorMaterial = CreateMaterial(new Color(0.3f, 0.3f, 0.3f)); // Тёмная броня

        // Тело
        GameObject body = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "Body", skinMaterial);
        body.transform.localPosition = new Vector3(0f, 1f, 0f);
        body.transform.localScale = new Vector3(0.5f, 0.9f, 0.3f);

        // Голова
        GameObject head = CreatePrimitive(parent.transform, PrimitiveType.Sphere, "Head", skinMaterial);
        head.transform.localPosition = new Vector3(0f, 1.7f, 0f);
        head.transform.localScale = new Vector3(0.3f, 0.35f, 0.3f);

        // Глаза (светящиеся)
        GameObject leftEye = CreatePrimitive(parent.transform, PrimitiveType.Sphere, "LeftEye", CreateMaterial(Color.yellow));
        leftEye.transform.localPosition = new Vector3(-0.1f, 1.75f, 0.12f);
        leftEye.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

        GameObject rightEye = CreatePrimitive(parent.transform, PrimitiveType.Sphere, "RightEye", CreateMaterial(Color.yellow));
        rightEye.transform.localPosition = new Vector3(0.1f, 1.75f, 0.12f);
        rightEye.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

        // Руки с когтями
        GameObject leftArm = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "LeftArm", skinMaterial);
        leftArm.transform.localPosition = new Vector3(-0.4f, 1.2f, 0f);
        leftArm.transform.localScale = new Vector3(0.12f, 0.5f, 0.12f);

        GameObject rightArm = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "RightArm", skinMaterial);
        rightArm.transform.localPosition = new Vector3(0.4f, 1.2f, 0f);
        rightArm.transform.localScale = new Vector3(0.12f, 0.5f, 0.12f);

        // Ноги
        GameObject leftLeg = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "LeftLeg", skinMaterial);
        leftLeg.transform.localPosition = new Vector3(-0.15f, 0.5f, 0f);
        leftLeg.transform.localScale = new Vector3(0.15f, 0.5f, 0.15f);

        GameObject rightLeg = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "RightLeg", skinMaterial);
        rightLeg.transform.localPosition = new Vector3(0.15f, 0.5f, 0f);
        rightLeg.transform.localScale = new Vector3(0.15f, 0.5f, 0.15f);
    }

    private static void CreateFastEnemy(GameObject parent)
    {
        // Быстрый, худой враг (оранжевый)
        Material skinMaterial = CreateMaterial(new Color(1.0f, 0.6f, 0.2f)); // Оранжевая кожа

        // Тонкое тело
        GameObject body = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "Body", skinMaterial);
        body.transform.localPosition = new Vector3(0f, 1.1f, 0f);
        body.transform.localScale = new Vector3(0.3f, 1.0f, 0.2f);

        // Голова
        GameObject head = CreatePrimitive(parent.transform, PrimitiveType.Sphere, "Head", skinMaterial);
        head.transform.localPosition = new Vector3(0f, 1.8f, 0f);
        head.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);

        // Длинные руки
        GameObject leftArm = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "LeftArm", skinMaterial);
        leftArm.transform.localPosition = new Vector3(-0.35f, 1.3f, 0f);
        leftArm.transform.localScale = new Vector3(0.08f, 0.7f, 0.08f);

        GameObject rightArm = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "RightArm", skinMaterial);
        rightArm.transform.localPosition = new Vector3(0.35f, 1.3f, 0f);
        rightArm.transform.localScale = new Vector3(0.08f, 0.7f, 0.08f);

        // Тонкие ноги
        GameObject leftLeg = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "LeftLeg", skinMaterial);
        leftLeg.transform.localPosition = new Vector3(-0.1f, 0.5f, 0f);
        leftLeg.transform.localScale = new Vector3(0.1f, 0.6f, 0.1f);

        GameObject rightLeg = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "RightLeg", skinMaterial);
        rightLeg.transform.localPosition = new Vector3(0.1f, 0.5f, 0f);
        rightLeg.transform.localScale = new Vector3(0.1f, 0.6f, 0.1f);
    }

    private static void CreateTankEnemy(GameObject parent)
    {
        // Большой, медленный враг (тёмно-фиолетовый)
        Material skinMaterial = CreateMaterial(new Color(0.4f, 0.2f, 0.6f)); // Фиолетовая кожа
        Material armorMaterial = CreateMaterial(new Color(0.2f, 0.2f, 0.2f)); // Тёмная броня

        // Массивное тело
        GameObject body = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "Body", skinMaterial);
        body.transform.localPosition = new Vector3(0f, 1.2f, 0f);
        body.transform.localScale = new Vector3(0.7f, 1.0f, 0.5f);

        // Большая голова
        GameObject head = CreatePrimitive(parent.transform, PrimitiveType.Sphere, "Head", skinMaterial);
        head.transform.localPosition = new Vector3(0f, 2.0f, 0f);
        head.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Броня на груди
        GameObject chestArmor = CreatePrimitive(parent.transform, PrimitiveType.Cube, "ChestArmor", armorMaterial);
        chestArmor.transform.localPosition = new Vector3(0f, 1.3f, 0.1f);
        chestArmor.transform.localScale = new Vector3(0.6f, 0.4f, 0.1f);

        // Массивные руки
        GameObject leftArm = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "LeftArm", skinMaterial);
        leftArm.transform.localPosition = new Vector3(-0.5f, 1.2f, 0f);
        leftArm.transform.localScale = new Vector3(0.2f, 0.6f, 0.2f);

        GameObject rightArm = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "RightArm", skinMaterial);
        rightArm.transform.localPosition = new Vector3(0.5f, 1.2f, 0f);
        rightArm.transform.localScale = new Vector3(0.2f, 0.6f, 0.2f);

        // Толстые ноги
        GameObject leftLeg = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "LeftLeg", skinMaterial);
        leftLeg.transform.localPosition = new Vector3(-0.2f, 0.5f, 0f);
        leftLeg.transform.localScale = new Vector3(0.2f, 0.5f, 0.2f);

        GameObject rightLeg = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "RightLeg", skinMaterial);
        rightLeg.transform.localPosition = new Vector3(0.2f, 0.5f, 0f);
        rightLeg.transform.localScale = new Vector3(0.2f, 0.5f, 0.2f);
    }

    private static void CreateRangedEnemy(GameObject parent)
    {
        // Враг-стрелок (зелёный)
        Material skinMaterial = CreateMaterial(new Color(0.3f, 0.8f, 0.3f)); // Зелёная кожа
        Material cloakMaterial = CreateMaterial(new Color(0.2f, 0.5f, 0.2f)); // Тёмно-зелёный плащ

        // Тело
        GameObject body = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "Body", skinMaterial);
        body.transform.localPosition = new Vector3(0f, 1.0f, 0f);
        body.transform.localScale = new Vector3(0.4f, 0.8f, 0.25f);

        // Голова
        GameObject head = CreatePrimitive(parent.transform, PrimitiveType.Sphere, "Head", skinMaterial);
        head.transform.localPosition = new Vector3(0f, 1.6f, 0f);
        head.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);

        // Плащ
        GameObject cloak = CreatePrimitive(parent.transform, PrimitiveType.Cube, "Cloak", cloakMaterial);
        cloak.transform.localPosition = new Vector3(0f, 0.8f, -0.1f);
        cloak.transform.localScale = new Vector3(0.5f, 1.2f, 0.1f);

        // Лук
        GameObject bow = CreateBow(parent.transform);
        bow.transform.localPosition = new Vector3(0.4f, 1.2f, 0.3f);
        bow.transform.rotation = Quaternion.Euler(0f, -90f, 0f);

        // Руки
        GameObject leftArm = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "LeftArm", skinMaterial);
        leftArm.transform.localPosition = new Vector3(-0.35f, 1.2f, 0f);
        leftArm.transform.localScale = new Vector3(0.1f, 0.45f, 0.1f);

        GameObject rightArm = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "RightArm", skinMaterial);
        rightArm.transform.localPosition = new Vector3(0.35f, 1.2f, 0f);
        rightArm.transform.localScale = new Vector3(0.1f, 0.45f, 0.1f);

        // Ноги
        GameObject leftLeg = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "LeftLeg", cloakMaterial);
        leftLeg.transform.localPosition = new Vector3(-0.12f, 0.5f, 0f);
        leftLeg.transform.localScale = new Vector3(0.12f, 0.5f, 0.12f);

        GameObject rightLeg = CreatePrimitive(parent.transform, PrimitiveType.Capsule, "RightLeg", cloakMaterial);
        rightLeg.transform.localPosition = new Vector3(0.12f, 0.5f, 0f);
        rightLeg.transform.localScale = new Vector3(0.12f, 0.5f, 0.12f);
    }

    private static GameObject CreateBow(Transform parent)
    {
        GameObject bow = new GameObject("Bow");
        bow.transform.SetParent(parent);

        // Дуга лука
        GameObject bowBody = CreatePrimitive(bow.transform, PrimitiveType.Cylinder, "BowBody", CreateMaterial(new Color(0.6f, 0.4f, 0.2f)));
        bowBody.transform.localPosition = new Vector3(0f, 0f, 0f);
        bowBody.transform.localScale = new Vector3(0.03f, 0.6f, 0.03f);
        bowBody.transform.rotation = Quaternion.Euler(0f, 0f, 90f);

        // Тетива (просто линия)
        GameObject bowString = CreatePrimitive(bow.transform, PrimitiveType.Cylinder, "BowString", CreateMaterial(Color.white));
        bowString.transform.localPosition = new Vector3(0.05f, 0f, 0f);
        bowString.transform.localScale = new Vector3(0.01f, 0.55f, 0.01f);

        return bow;
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

    private static Material CreateMaterial(Color color)
    {
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

public enum EnemyType
{
    Normal,
    Fast,
    Tank,
    Ranged
}
