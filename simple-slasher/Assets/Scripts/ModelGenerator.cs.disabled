using UnityEngine;
using UnityEditor;

/// <summary>
/// Генератор улучшенных 3D моделей для игрока и врагов.
/// Создает модели прямоугольной формы с деталями.
/// </summary>
public class ModelGenerator
{
    /// <summary>
    /// Создает модель игрока с детализированным дизайном.
    /// </summary>
    public static GameObject CreatePlayerModel()
    {
        GameObject playerModel = new GameObject("PlayerModel");

        // Основное тело (цилиндр) - УВЕЛИЧЕНО
        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        body.name = "Body";
        body.transform.SetParent(playerModel.transform);
        body.transform.localPosition = Vector3.zero;
        body.transform.localScale = new Vector3(1.5f, 2.0f, 1.5f);
        body.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Голова (сфера) - УВЕЛИЧЕНО
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        head.name = "Head";
        head.transform.SetParent(playerModel.transform);
        head.transform.localPosition = new Vector3(0, 1.4f, 0);
        head.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Плечи (два маленьких цилиндра) - УВЕЛИЧЕНО
        GameObject leftShoulder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftShoulder.name = "LeftShoulder";
        leftShoulder.transform.SetParent(playerModel.transform);
        leftShoulder.transform.localPosition = new Vector3(-0.9f, 0.6f, 0);
        leftShoulder.transform.localScale = new Vector3(0.3f, 0.7f, 0.3f);
        leftShoulder.transform.rotation = Quaternion.Euler(0, 0, 90);

        GameObject rightShoulder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightShoulder.name = "RightShoulder";
        rightShoulder.transform.SetParent(playerModel.transform);
        rightShoulder.transform.localPosition = new Vector3(0.9f, 0.6f, 0);
        rightShoulder.transform.localScale = new Vector3(0.3f, 0.7f, 0.3f);
        rightShoulder.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Ноги (два цилиндра) - УВЕЛИЧЕНО
        GameObject leftLeg = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftLeg.name = "LeftLeg";
        leftLeg.transform.SetParent(playerModel.transform);
        leftLeg.transform.localPosition = new Vector3(-0.3f, -1.2f, 0);
        leftLeg.transform.localScale = new Vector3(0.4f, 1.4f, 0.4f);

        GameObject rightLeg = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightLeg.name = "RightLeg";
        rightLeg.transform.SetParent(playerModel.transform);
        rightLeg.transform.localPosition = new Vector3(0.3f, -1.2f, 0);
        rightLeg.transform.localScale = new Vector3(0.4f, 1.4f, 0.4f);

        // Оружие (меч)
        GameObject weapon = CreateWeapon();
        weapon.transform.SetParent(playerModel.transform);
        weapon.transform.localPosition = new Vector3(0.6f, 0.3f, 0.3f);
        weapon.transform.localRotation = Quaternion.Euler(0, -45, 90);

        // Применяем материалы
        ApplyPlayerMaterials(playerModel);

        return playerModel;
    }

    /// <summary>
    /// Создает модель врага с устрашающим дизайном.
    /// </summary>
    public static GameObject CreateEnemyModel()
    {
        return CreateEnemyModel(EnemyFactory.EnemyType.Normal);
    }

    /// <summary>
    /// Создает модель врага указанного типа с уникальным дизайном.
    /// </summary>
    public static GameObject CreateEnemyModel(EnemyFactory.EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyFactory.EnemyType.Normal:
                return CreateNormalEnemyModel();
            case EnemyFactory.EnemyType.Fast:
                return CreateFastEnemyModel();
            case EnemyFactory.EnemyType.Tank:
                return CreateTankEnemyModel();
            case EnemyFactory.EnemyType.Ranged:
                return CreateRangedEnemyModel();
            default:
                return CreateNormalEnemyModel();
        }
    }

    /// <summary>
    /// Создает модель обычного врага - демон/монстр с рогами и когтями.
    /// </summary>
    private static GameObject CreateNormalEnemyModel()
    {
        GameObject enemyModel = new GameObject("NormalEnemyModel");

        // Основное тело (куб для более угрожающего вида)
        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Cube);
        body.name = "Body";
        body.transform.SetParent(enemyModel.transform);
        body.transform.localPosition = Vector3.zero;
        body.transform.localScale = new Vector3(1.5f, 2.0f, 1.2f);

        // Грудная пластина (броня)
        GameObject chestPlate = GameObject.CreatePrimitive(PrimitiveType.Cube);
        chestPlate.name = "ChestPlate";
        chestPlate.transform.SetParent(enemyModel.transform);
        chestPlate.transform.localPosition = new Vector3(0, 0.3f, 0.65f);
        chestPlate.transform.localScale = new Vector3(1.4f, 0.8f, 0.2f);

        // Голова (угловатая)
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Cube);
        head.name = "Head";
        head.transform.SetParent(enemyModel.transform);
        head.transform.localPosition = new Vector3(0, 1.4f, 0);
        head.transform.localScale = new Vector3(1.0f, 0.8f, 1.0f);

        // Глаза (светящиеся)
        GameObject leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftEye.name = "LeftEye";
        leftEye.transform.SetParent(enemyModel.transform);
        leftEye.transform.localPosition = new Vector3(-0.25f, 1.45f, 0.5f);
        leftEye.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

        GameObject rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightEye.name = "RightEye";
        rightEye.transform.SetParent(enemyModel.transform);
        rightEye.transform.localPosition = new Vector3(0.25f, 1.45f, 0.5f);
        rightEye.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

        // Рога
        GameObject leftHorn = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftHorn.name = "LeftHorn";
        leftHorn.transform.SetParent(enemyModel.transform);
        leftHorn.transform.localPosition = new Vector3(-0.3f, 2.0f, 0);
        leftHorn.transform.localScale = new Vector3(0.15f, 0.5f, 0.15f);
        leftHorn.transform.rotation = Quaternion.Euler(0, 0, -45);

        GameObject rightHorn = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightHorn.name = "RightHorn";
        rightHorn.transform.SetParent(enemyModel.transform);
        rightHorn.transform.localPosition = new Vector3(0.3f, 2.0f, 0);
        rightHorn.transform.localScale = new Vector3(0.15f, 0.5f, 0.15f);
        rightHorn.transform.rotation = Quaternion.Euler(0, 0, 45);

        // Плечи (большие и массивные)
        GameObject leftShoulder = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftShoulder.name = "LeftShoulder";
        leftShoulder.transform.SetParent(enemyModel.transform);
        leftShoulder.transform.localPosition = new Vector3(-1.0f, 0.4f, 0);
        leftShoulder.transform.localScale = new Vector3(0.5f, 0.7f, 0.7f);

        GameObject rightShoulder = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightShoulder.name = "RightShoulder";
        rightShoulder.transform.SetParent(enemyModel.transform);
        rightShoulder.transform.localPosition = new Vector3(1.0f, 0.4f, 0);
        rightShoulder.transform.localScale = new Vector3(0.5f, 0.7f, 0.7f);

        // Шипы на плечах
        GameObject leftShoulderSpike = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftShoulderSpike.name = "LeftShoulderSpike";
        leftShoulderSpike.transform.SetParent(enemyModel.transform);
        leftShoulderSpike.transform.localPosition = new Vector3(-1.0f, 0.8f, 0);
        leftShoulderSpike.transform.localScale = new Vector3(0.2f, 0.3f, 0.2f);
        leftShoulderSpike.transform.rotation = Quaternion.Euler(0, 0, 180);

        GameObject rightShoulderSpike = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightShoulderSpike.name = "RightShoulderSpike";
        rightShoulderSpike.transform.SetParent(enemyModel.transform);
        rightShoulderSpike.transform.localPosition = new Vector3(1.0f, 0.8f, 0);
        rightShoulderSpike.transform.localScale = new Vector3(0.2f, 0.3f, 0.2f);
        rightShoulderSpike.transform.rotation = Quaternion.Euler(0, 0, 180);

        // Ноги (массивные)
        GameObject leftLeg = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftLeg.name = "LeftLeg";
        leftLeg.transform.SetParent(enemyModel.transform);
        leftLeg.transform.localPosition = new Vector3(-0.4f, -1.3f, 0);
        leftLeg.transform.localScale = new Vector3(0.4f, 1.3f, 0.4f);

        GameObject rightLeg = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightLeg.name = "RightLeg";
        rightLeg.transform.SetParent(enemyModel.transform);
        rightLeg.transform.localPosition = new Vector3(0.4f, -1.3f, 0);
        rightLeg.transform.localScale = new Vector3(0.4f, 1.3f, 0.4f);

        // Когти/оружие
        GameObject leftClaw = CreateClaw();
        leftClaw.transform.SetParent(enemyModel.transform);
        leftClaw.transform.localPosition = new Vector3(-1.2f, 0, 0.5f);

        GameObject rightClaw = CreateClaw();
        rightClaw.transform.SetParent(enemyModel.transform);
        rightClaw.transform.localPosition = new Vector3(1.2f, 0, 0.5f);

        // Применяем материалы
        ApplyNormalEnemyMaterials(enemyModel);

        return enemyModel;
    }

    /// <summary>
    /// Создает модель быстрого врага - sleek, agile, feral appearance.
    /// </summary>
    private static GameObject CreateFastEnemyModel()
    {
        GameObject enemyModel = new GameObject("FastEnemyModel");

        // Основное тело (более стройное и вытянутое)
        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        body.name = "Body";
        body.transform.SetParent(enemyModel.transform);
        body.transform.localPosition = Vector3.zero;
        body.transform.localScale = new Vector3(0.8f, 1.8f, 0.8f);
        body.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Голова (более острая, как у хищника)
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        head.name = "Head";
        head.transform.SetParent(enemyModel.transform);
        head.transform.localPosition = new Vector3(0, 1.2f, 0);
        head.transform.localScale = new Vector3(0.5f, 0.7f, 0.5f);
        head.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Морда (вытянутая)
        GameObject snout = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        snout.name = "Snout";
        snout.transform.SetParent(enemyModel.transform);
        snout.transform.localPosition = new Vector3(0, 1.2f, 0.4f);
        snout.transform.localScale = new Vector3(0.25f, 0.35f, 0.25f);
        snout.transform.rotation = Quaternion.Euler(90, 0, 0);

        // Уши (острые)
        GameObject leftEar = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftEar.name = "LeftEar";
        leftEar.transform.SetParent(enemyModel.transform);
        leftEar.transform.localPosition = new Vector3(-0.2f, 1.6f, 0);
        leftEar.transform.localScale = new Vector3(0.15f, 0.3f, 0.15f);
        leftEar.transform.rotation = Quaternion.Euler(0, 0, -30);

        GameObject rightEar = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightEar.name = "RightEar";
        rightEar.transform.SetParent(enemyModel.transform);
        rightEar.transform.localPosition = new Vector3(0.2f, 1.6f, 0);
        rightEar.transform.localScale = new Vector3(0.15f, 0.3f, 0.15f);
        rightEar.transform.rotation = Quaternion.Euler(0, 0, 30);

        // Глаза (большие, хищные)
        GameObject leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftEye.name = "LeftEye";
        leftEye.transform.SetParent(enemyModel.transform);
        leftEye.transform.localPosition = new Vector3(-0.15f, 1.25f, 0.3f);
        leftEye.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);

        GameObject rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightEye.name = "RightEye";
        rightEye.transform.SetParent(enemyModel.transform);
        rightEye.transform.localPosition = new Vector3(0.15f, 1.25f, 0.3f);
        rightEye.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);

        // Руки (когтистые)
        GameObject leftArm = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        leftArm.name = "LeftArm";
        leftArm.transform.SetParent(enemyModel.transform);
        leftArm.transform.localPosition = new Vector3(-0.5f, 0.3f, 0);
        leftArm.transform.localScale = new Vector3(0.15f, 0.6f, 0.15f);
        leftArm.transform.rotation = Quaternion.Euler(0, 0, 90);

        GameObject rightArm = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        rightArm.name = "RightArm";
        rightArm.transform.SetParent(enemyModel.transform);
        rightArm.transform.localPosition = new Vector3(0.5f, 0.3f, 0);
        rightArm.transform.localScale = new Vector3(0.15f, 0.6f, 0.15f);
        rightArm.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Ноги (мощные, прыгучие)
        GameObject leftLeg = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        leftLeg.name = "LeftLeg";
        leftLeg.transform.SetParent(enemyModel.transform);
        leftLeg.transform.localPosition = new Vector3(-0.25f, -1.0f, 0);
        leftLeg.transform.localScale = new Vector3(0.2f, 0.9f, 0.2f);

        GameObject rightLeg = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        rightLeg.name = "RightLeg";
        rightLeg.transform.SetParent(enemyModel.transform);
        rightLeg.transform.localPosition = new Vector3(0.25f, -1.0f, 0);
        rightLeg.transform.localScale = new Vector3(0.2f, 0.9f, 0.2f);

        // Хвост
        GameObject tail = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        tail.name = "Tail";
        tail.transform.SetParent(enemyModel.transform);
        tail.transform.localPosition = new Vector3(0, -0.8f, -0.3f);
        tail.transform.localScale = new Vector3(0.1f, 0.6f, 0.1f);
        tail.transform.rotation = Quaternion.Euler(30, 0, 0);

        // Острые когти
        GameObject leftClaw = CreateSharpClaw();
        leftClaw.transform.SetParent(enemyModel.transform);
        leftClaw.transform.localPosition = new Vector3(-0.7f, 0, 0.3f);

        GameObject rightClaw = CreateSharpClaw();
        rightClaw.transform.SetParent(enemyModel.transform);
        rightClaw.transform.localPosition = new Vector3(0.7f, 0, 0.3f);

        // Применяем материалы
        ApplyFastEnemyMaterials(enemyModel);

        return enemyModel;
    }

    /// <summary>
    /// Создает модель танкового врага - bulky, armored, intimidating.
    /// </summary>
    private static GameObject CreateTankEnemyModel()
    {
        GameObject enemyModel = new GameObject("TankEnemyModel");

        // Основное тело (массивное, бронированное)
        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Cube);
        body.name = "Body";
        body.transform.SetParent(enemyModel.transform);
        body.transform.localPosition = Vector3.zero;
        body.transform.localScale = new Vector3(2.2f, 2.2f, 1.8f);

        // Грудная броня (толстая пластина)
        GameObject chestArmor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        chestArmor.name = "ChestArmor";
        chestArmor.transform.SetParent(enemyModel.transform);
        chestArmor.transform.localPosition = new Vector3(0, 0.3f, 0.95f);
        chestArmor.transform.localScale = new Vector3(2.0f, 1.0f, 0.3f);

        // Спинная броня
        GameObject backArmor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        backArmor.name = "BackArmor";
        backArmor.transform.SetParent(enemyModel.transform);
        backArmor.transform.localPosition = new Vector3(0, 0.3f, -0.95f);
        backArmor.transform.localScale = new Vector3(2.0f, 1.0f, 0.3f);

        // Голова (в шлеме)
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Cube);
        head.name = "Head";
        head.transform.SetParent(enemyModel.transform);
        head.transform.localPosition = new Vector3(0, 1.5f, 0);
        head.transform.localScale = new Vector3(1.2f, 0.9f, 1.2f);

        // Шлем (дополнительная защита)
        GameObject helmet = GameObject.CreatePrimitive(PrimitiveType.Cube);
        helmet.name = "Helmet";
        helmet.transform.SetParent(enemyModel.transform);
        helmet.transform.localPosition = new Vector3(0, 1.5f, 0.3f);
        helmet.transform.localScale = new Vector3(1.0f, 0.7f, 0.4f);

        // Глазница (одна, как у циклопа)
        GameObject eyeSocket = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        eyeSocket.name = "EyeSocket";
        eyeSocket.transform.SetParent(enemyModel.transform);
        eyeSocket.transform.localPosition = new Vector3(0, 1.6f, 0.6f);
        eyeSocket.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        // Плечевые пластины (огромные)
        GameObject leftShoulderPlate = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftShoulderPlate.name = "LeftShoulderPlate";
        leftShoulderPlate.transform.SetParent(enemyModel.transform);
        leftShoulderPlate.transform.localPosition = new Vector3(-1.4f, 0.5f, 0);
        leftShoulderPlate.transform.localScale = new Vector3(0.6f, 0.9f, 1.0f);

        GameObject rightShoulderPlate = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightShoulderPlate.name = "RightShoulderPlate";
        rightShoulderPlate.transform.SetParent(enemyModel.transform);
        rightShoulderPlate.transform.localPosition = new Vector3(1.4f, 0.5f, 0);
        rightShoulderPlate.transform.localScale = new Vector3(0.6f, 0.9f, 1.0f);

        // Шипы на плечах
        for (int i = 0; i < 3; i++)
        {
            GameObject leftSpike = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            leftSpike.name = "LeftSpike_" + i;
            leftSpike.transform.SetParent(enemyModel.transform);
            leftSpike.transform.localPosition = new Vector3(-1.4f, 1.0f + i * 0.15f, -0.4f + i * 0.4f);
            leftSpike.transform.localScale = new Vector3(0.15f, 0.25f, 0.15f);
            leftSpike.transform.rotation = Quaternion.Euler(90, 0, 0);

            GameObject rightSpike = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            rightSpike.name = "RightSpike_" + i;
            rightSpike.transform.SetParent(enemyModel.transform);
            rightSpike.transform.localPosition = new Vector3(1.4f, 1.0f + i * 0.15f, -0.4f + i * 0.4f);
            rightSpike.transform.localScale = new Vector3(0.15f, 0.25f, 0.15f);
            rightSpike.transform.rotation = Quaternion.Euler(90, 0, 0);
        }

        // Ноги (толстые, бронированные)
        GameObject leftLeg = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftLeg.name = "LeftLeg";
        leftLeg.transform.SetParent(enemyModel.transform);
        leftLeg.transform.localPosition = new Vector3(-0.6f, -1.4f, 0);
        leftLeg.transform.localScale = new Vector3(0.6f, 1.4f, 0.6f);

        GameObject rightLeg = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightLeg.name = "RightLeg";
        rightLeg.transform.SetParent(enemyModel.transform);
        rightLeg.transform.localPosition = new Vector3(0.6f, -1.4f, 0);
        rightLeg.transform.localScale = new Vector3(0.6f, 1.4f, 0.6f);

        // Броня на ногах
        GameObject leftLegArmor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftLegArmor.name = "LeftLegArmor";
        leftLegArmor.transform.SetParent(enemyModel.transform);
        leftLegArmor.transform.localPosition = new Vector3(-0.6f, -1.4f, 0.35f);
        leftLegArmor.transform.localScale = new Vector3(0.5f, 1.2f, 0.2f);

        GameObject rightLegArmor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightLegArmor.name = "RightLegArmor";
        rightLegArmor.transform.SetParent(enemyModel.transform);
        rightLegArmor.transform.localPosition = new Vector3(0.6f, -1.4f, 0.35f);
        rightLegArmor.transform.localScale = new Vector3(0.5f, 1.2f, 0.2f);

        // Огромное оружие (булава)
        GameObject weapon = CreateMace();
        weapon.transform.SetParent(enemyModel.transform);
        weapon.transform.localPosition = new Vector3(1.0f, 0.5f, 0.8f);
        weapon.transform.localRotation = Quaternion.Euler(0, -30, 90);

        // Применяем материалы
        ApplyTankEnemyMaterials(enemyModel);

        return enemyModel;
    }

    /// <summary>
    /// Создает модель врага дальнего боя - distinctive appearance for ranged capability.
    /// </summary>
    private static GameObject CreateRangedEnemyModel()
    {
        GameObject enemyModel = new GameObject("RangedEnemyModel");

        // Основное тело (более высокое и худое)
        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        body.name = "Body";
        body.transform.SetParent(enemyModel.transform);
        body.transform.localPosition = Vector3.zero;
        body.transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
        body.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Голова (увеличенная, с интеллектуальным видом)
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        head.name = "Head";
        head.transform.SetParent(enemyModel.transform);
        head.transform.localPosition = new Vector3(0, 1.4f, 0);
        head.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        // Лоб (увеличенный - намек на интеллект)
        GameObject forehead = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        forehead.name = "Forehead";
        forehead.transform.SetParent(enemyModel.transform);
        forehead.transform.localPosition = new Vector3(0, 1.55f, 0.2f);
        forehead.transform.localScale = new Vector3(0.5f, 0.3f, 0.4f);

        // Три глаза (для лучшего прицеливания)
        GameObject leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftEye.name = "LeftEye";
        leftEye.transform.SetParent(enemyModel.transform);
        leftEye.transform.localPosition = new Vector3(-0.2f, 1.45f, 0.45f);
        leftEye.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        GameObject centerEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        centerEye.name = "CenterEye";
        centerEye.transform.SetParent(enemyModel.transform);
        centerEye.transform.localPosition = new Vector3(0, 1.45f, 0.5f);
        centerEye.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);

        GameObject rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightEye.name = "RightEye";
        rightEye.transform.SetParent(enemyModel.transform);
        rightEye.transform.localPosition = new Vector3(0.2f, 1.45f, 0.45f);
        rightEye.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // Плечи (с платформой для оружия)
        GameObject leftShoulder = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        leftShoulder.name = "LeftShoulder";
        leftShoulder.transform.SetParent(enemyModel.transform);
        leftShoulder.transform.localPosition = new Vector3(-0.6f, 0.5f, 0);
        leftShoulder.transform.localScale = new Vector3(0.25f, 0.5f, 0.25f);
        leftShoulder.transform.rotation = Quaternion.Euler(0, 0, 90);

        GameObject rightShoulder = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        rightShoulder.name = "RightShoulder";
        rightShoulder.transform.SetParent(enemyModel.transform);
        rightShoulder.transform.localPosition = new Vector3(0.6f, 0.5f, 0);
        rightShoulder.transform.localScale = new Vector3(0.25f, 0.5f, 0.25f);
        rightShoulder.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Оружийная платформа на плече
        GameObject weaponPlatform = GameObject.CreatePrimitive(PrimitiveType.Cube);
        weaponPlatform.name = "WeaponPlatform";
        weaponPlatform.transform.SetParent(enemyModel.transform);
        weaponPlatform.transform.localPosition = new Vector3(0.8f, 0.9f, 0);
        weaponPlatform.transform.localScale = new Vector3(0.3f, 0.2f, 0.4f);

        // Лук/арбалет
        GameObject weapon = CreateCrossbow();
        weapon.transform.SetParent(enemyModel.transform);
        weapon.transform.localPosition = new Vector3(0.8f, 0.9f, 0.5f);
        weapon.transform.localRotation = Quaternion.Euler(0, -90, 0);

        // Ноги
        GameObject leftLeg = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        leftLeg.name = "LeftLeg";
        leftLeg.transform.SetParent(enemyModel.transform);
        leftLeg.transform.localPosition = new Vector3(-0.3f, -1.2f, 0);
        leftLeg.transform.localScale = new Vector3(0.25f, 1.1f, 0.25f);

        GameObject rightLeg = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        rightLeg.name = "RightLeg";
        rightLeg.transform.SetParent(enemyModel.transform);
        rightLeg.transform.localPosition = new Vector3(0.3f, -1.2f, 0);
        rightLeg.transform.localScale = new Vector3(0.25f, 1.1f, 0.25f);

        // Mana crystals (энергетические кристаллы на теле)
        GameObject crystal1 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        crystal1.name = "Crystal1";
        crystal1.transform.SetParent(enemyModel.transform);
        crystal1.transform.localPosition = new Vector3(-0.5f, 0.2f, 0.6f);
        crystal1.transform.localScale = new Vector3(0.08f, 0.25f, 0.08f);

        GameObject crystal2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        crystal2.name = "Crystal2";
        crystal2.transform.SetParent(enemyModel.transform);
        crystal2.transform.localPosition = new Vector3(0.5f, 0.2f, 0.6f);
        crystal2.transform.localScale = new Vector3(0.08f, 0.25f, 0.08f);

        // Применяем материалы
        ApplyRangedEnemyMaterials(enemyModel);

        return enemyModel;
    }

    private static GameObject CreateWeapon()
    {
        GameObject weapon = new GameObject("Weapon");

        // Рукоять
        GameObject handle = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        handle.name = "Handle";
        handle.transform.SetParent(weapon.transform);
        handle.transform.localPosition = new Vector3(0, -0.3f, 0);
        handle.transform.localScale = new Vector3(0.08f, 0.6f, 0.08f);

        // Гарда
        GameObject guard = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guard.name = "Guard";
        guard.transform.SetParent(weapon.transform);
        guard.transform.localPosition = new Vector3(0, 0, 0);
        guard.transform.localScale = new Vector3(0.4f, 0.08f, 0.1f);

        // Лезвие
        GameObject blade = GameObject.CreatePrimitive(PrimitiveType.Cube);
        blade.name = "Blade";
        blade.transform.SetParent(weapon.transform);
        blade.transform.localPosition = new Vector3(0, 0.6f, 0);
        blade.transform.localScale = new Vector3(0.12f, 1.2f, 0.04f);

        // Острие
        GameObject tip = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        tip.name = "Tip";
        tip.transform.SetParent(weapon.transform);
        tip.transform.localPosition = new Vector3(0, 0.6f, 0);
        tip.transform.localScale = new Vector3(0.12f, 0.15f, 0.12f);

        return weapon;
    }

    private static GameObject CreateClaw()
    {
        GameObject claw = new GameObject("Claw");

        // Основание когтя
        GameObject baseClaw = GameObject.CreatePrimitive(PrimitiveType.Cube);
        baseClaw.name = "Base";
        baseClaw.transform.SetParent(claw.transform);
        baseClaw.transform.localPosition = Vector3.zero;
        baseClaw.transform.localScale = new Vector3(0.15f, 0.2f, 0.1f);

        // Три когтя
        for (int i = -1; i <= 1; i++)
        {
            GameObject clawTip = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            clawTip.name = "ClawTip_" + i;
            clawTip.transform.SetParent(claw.transform);
            clawTip.transform.localPosition = new Vector3(i * 0.1f, 0.15f, 0);
            clawTip.transform.localScale = new Vector3(0.03f, 0.2f, 0.03f);
            clawTip.transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        return claw;
    }

    /// <summary>
    /// Создает острые когти для быстрого врага.
    /// </summary>
    private static GameObject CreateSharpClaw()
    {
        GameObject claw = new GameObject("SharpClaw");

        // Основание когтя
        GameObject baseClaw = GameObject.CreatePrimitive(PrimitiveType.Cube);
        baseClaw.name = "Base";
        baseClaw.transform.SetParent(claw.transform);
        baseClaw.transform.localPosition = Vector3.zero;
        baseClaw.transform.localScale = new Vector3(0.1f, 0.15f, 0.08f);

        // Три острых когтя
        for (int i = -1; i <= 1; i++)
        {
            GameObject clawTip = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            clawTip.name = "ClawTip_" + i;
            clawTip.transform.SetParent(claw.transform);
            clawTip.transform.localPosition = new Vector3(i * 0.08f, 0.12f, 0);
            clawTip.transform.localScale = new Vector3(0.04f, 0.25f, 0.04f);
            clawTip.transform.rotation = Quaternion.Euler(90, 0, 0);
        }

        return claw;
    }

    /// <summary>
    /// Создает булаву для танкового врага.
    /// </summary>
    private static GameObject CreateMace()
    {
        GameObject mace = new GameObject("Mace");

        // Рукоять (толстая)
        GameObject handle = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        handle.name = "Handle";
        handle.transform.SetParent(mace.transform);
        handle.transform.localPosition = new Vector3(0, -0.5f, 0);
        handle.transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);

        // Гарда
        GameObject guard = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guard.name = "Guard";
        guard.transform.SetParent(mace.transform);
        guard.transform.localPosition = new Vector3(0, 0, 0);
        guard.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);

        // Шаровая голова
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        head.name = "Head";
        head.transform.SetParent(mace.transform);
        head.transform.localPosition = new Vector3(0, 0.7f, 0);
        head.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

        // Шипы на голове
        for (int i = 0; i < 8; i++)
        {
            float angle = i * 45f;
            GameObject spike = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            spike.name = "Spike_" + i;
            spike.transform.SetParent(mace.transform);

            float x = Mathf.Sin(angle * Mathf.Deg2Rad) * 0.7f;
            float z = Mathf.Cos(angle * Mathf.Deg2Rad) * 0.7f;

            spike.transform.localPosition = new Vector3(x, 0.7f, z);
            spike.transform.localScale = new Vector3(0.1f, 0.25f, 0.1f);
            spike.transform.rotation = Quaternion.Euler(90, -angle, 0);
        }

        // Дополнительные шипы сверху и снизу
        GameObject topSpike = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        topSpike.name = "TopSpike";
        topSpike.transform.SetParent(mace.transform);
        topSpike.transform.localPosition = new Vector3(0, 1.1f, 0);
        topSpike.transform.localScale = new Vector3(0.12f, 0.3f, 0.12f);
        topSpike.transform.rotation = Quaternion.Euler(0, 0, 0);

        GameObject bottomSpike = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        bottomSpike.name = "BottomSpike";
        bottomSpike.transform.SetParent(mace.transform);
        bottomSpike.transform.localPosition = new Vector3(0, 0.3f, 0);
        bottomSpike.transform.localScale = new Vector3(0.12f, 0.3f, 0.12f);
        bottomSpike.transform.rotation = Quaternion.Euler(180, 0, 0);

        return mace;
    }

    /// <summary>
    /// Создает арбалет для врага дальнего боя.
    /// </summary>
    private static GameObject CreateCrossbow()
    {
        GameObject crossbow = new GameObject("Crossbow");

        // Лук (дуга)
        GameObject bow = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        bow.name = "Bow";
        bow.transform.SetParent(crossbow.transform);
        bow.transform.localPosition = new Vector3(0, 0, 0);
        bow.transform.localScale = new Vector3(0.05f, 0.8f, 0.05f);
        bow.transform.rotation = Quaternion.Euler(90, 0, 0);

        // Верхняя часть дуги
        GameObject bowTop = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        bowTop.name = "BowTop";
        bowTop.transform.SetParent(crossbow.transform);
        bowTop.transform.localPosition = new Vector3(0, 0.4f, 0);
        bowTop.transform.localScale = new Vector3(0.05f, 0.3f, 0.05f);
        bowTop.transform.rotation = Quaternion.Euler(0, 0, 45);

        // Нижняя часть дуги
        GameObject bowBottom = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        bowBottom.name = "BowBottom";
        bowBottom.transform.SetParent(crossbow.transform);
        bowBottom.transform.localPosition = new Vector3(0, -0.4f, 0);
        bowBottom.transform.localScale = new Vector3(0.05f, 0.3f, 0.05f);
        bowBottom.transform.rotation = Quaternion.Euler(0, 0, -45);

        // Тетива
        GameObject bowString = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        bowString.name = "String";
        bowString.transform.SetParent(crossbow.transform);
        bowString.transform.localPosition = new Vector3(0, 0, 0.1f);
        bowString.transform.localScale = new Vector3(0.01f, 0.8f, 0.01f);
        bowString.transform.rotation = Quaternion.Euler(90, 0, 0);

        // Ложе (приклад)
        GameObject stock = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stock.name = "Stock";
        stock.transform.SetParent(crossbow.transform);
        stock.transform.localPosition = new Vector3(-0.4f, 0, 0);
        stock.transform.localScale = new Vector3(0.8f, 0.08f, 0.1f);

        // Болт (стрела)
        GameObject bolt = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        bolt.name = "Bolt";
        bolt.transform.SetParent(crossbow.transform);
        bolt.transform.localPosition = new Vector3(0.2f, 0, 0);
        bolt.transform.localScale = new Vector3(0.03f, 0.4f, 0.03f);
        bolt.transform.rotation = Quaternion.Euler(0, 0, 90);

        // Оперение болта
        GameObject fletching = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fletching.name = "Fletching";
        fletching.transform.SetParent(crossbow.transform);
        fletching.transform.localPosition = new Vector3(0.35f, 0, 0);
        fletching.transform.localScale = new Vector3(0.08f, 0.15f, 0.02f);

        return crossbow;
    }

    private static void ApplyPlayerMaterials(GameObject playerModel)
    {
        // Синий цвет для героя
        Material bodyMaterial = new Material(Shader.Find("Standard"));
        bodyMaterial.color = new Color(0.2f, 0.5f, 1.0f);

        // Светло-серый для головы
        Material headMaterial = new Material(Shader.Find("Standard"));
        headMaterial.color = new Color(0.9f, 0.85f, 0.8f);

        // Темно-серый для плеч
        Material shoulderMaterial = new Material(Shader.Find("Standard"));
        shoulderMaterial.color = new Color(0.3f, 0.3f, 0.35f);

        // Коричневый для ног
        Material legMaterial = new Material(Shader.Find("Standard"));
        legMaterial.color = new Color(0.4f, 0.3f, 0.2f);

        // Серебристый для оружия
        Material weaponMaterial = new Material(Shader.Find("Standard"));
        weaponMaterial.color = new Color(0.8f, 0.8f, 0.9f);
        weaponMaterial.SetFloat("_Metallic", 0.8f);
        weaponMaterial.SetFloat("_Glossiness", 0.9f);

        // Применяем материалы
        Transform body = playerModel.transform.Find("Body");
        if (body != null) body.GetComponent<Renderer>().material = bodyMaterial;

        Transform head = playerModel.transform.Find("Head");
        if (head != null) head.GetComponent<Renderer>().material = headMaterial;

        Transform leftShoulder = playerModel.transform.Find("LeftShoulder");
        if (leftShoulder != null) leftShoulder.GetComponent<Renderer>().material = shoulderMaterial;

        Transform rightShoulder = playerModel.transform.Find("RightShoulder");
        if (rightShoulder != null) rightShoulder.GetComponent<Renderer>().material = shoulderMaterial;

        Transform leftLeg = playerModel.transform.Find("LeftLeg");
        if (leftLeg != null) leftLeg.GetComponent<Renderer>().material = legMaterial;

        Transform rightLeg = playerModel.transform.Find("RightLeg");
        if (rightLeg != null) rightLeg.GetComponent<Renderer>().material = legMaterial;

        Transform weapon = playerModel.transform.Find("Weapon");
        if (weapon != null)
        {
            foreach (Renderer renderer in weapon.GetComponentsInChildren<Renderer>())
            {
                renderer.material = weaponMaterial;
            }
        }
    }

    private static void ApplyEnemyMaterials(GameObject enemyModel)
    {
        // Темно-красный для тела врага
        Material bodyMaterial = new Material(Shader.Find("Standard"));
        bodyMaterial.color = new Color(0.8f, 0.1f, 0.1f);

        // Более темный для головы
        Material headMaterial = new Material(Shader.Find("Standard"));
        headMaterial.color = new Color(0.6f, 0.05f, 0.05f);

        // Черный для рогов
        Material hornMaterial = new Material(Shader.Find("Standard"));
        hornMaterial.color = new Color(0.1f, 0.1f, 0.1f);

        // Темно-серый для плеч
        Material shoulderMaterial = new Material(Shader.Find("Standard"));
        shoulderMaterial.color = new Color(0.3f, 0.2f, 0.2f);

        // Темно-коричневый для ног
        Material legMaterial = new Material(Shader.Find("Standard"));
        legMaterial.color = new Color(0.25f, 0.15f, 0.1f);

        // Серебристый для когтей
        Material clawMaterial = new Material(Shader.Find("Standard"));
        clawMaterial.color = new Color(0.7f, 0.7f, 0.7f);
        clawMaterial.SetFloat("_Metallic", 0.6f);
        clawMaterial.SetFloat("_Glossiness", 0.7f);

        // Применяем материалы
        Transform body = enemyModel.transform.Find("Body");
        if (body != null) body.GetComponent<Renderer>().material = bodyMaterial;

        Transform head = enemyModel.transform.Find("Head");
        if (head != null) head.GetComponent<Renderer>().material = headMaterial;

        Transform leftHorn = enemyModel.transform.Find("LeftHorn");
        if (leftHorn != null) leftHorn.GetComponent<Renderer>().material = hornMaterial;

        Transform rightHorn = enemyModel.transform.Find("RightHorn");
        if (rightHorn != null) rightHorn.GetComponent<Renderer>().material = hornMaterial;

        Transform leftShoulder = enemyModel.transform.Find("LeftShoulder");
        if (leftShoulder != null) leftShoulder.GetComponent<Renderer>().material = shoulderMaterial;

        Transform rightShoulder = enemyModel.transform.Find("RightShoulder");
        if (rightShoulder != null) rightShoulder.GetComponent<Renderer>().material = shoulderMaterial;

        Transform leftLeg = enemyModel.transform.Find("LeftLeg");
        if (leftLeg != null) leftLeg.GetComponent<Renderer>().material = legMaterial;

        Transform rightLeg = enemyModel.transform.Find("RightLeg");
        if (rightLeg != null) rightLeg.GetComponent<Renderer>().material = legMaterial;

        Transform leftClaw = enemyModel.transform.Find("LeftClaw");
        if (leftClaw != null)
        {
            foreach (Renderer renderer in leftClaw.GetComponentsInChildren<Renderer>())
            {
                renderer.material = clawMaterial;
            }
        }

        Transform rightClaw = enemyModel.transform.Find("RightClaw");
        if (rightClaw != null)
        {
            foreach (Renderer renderer in rightClaw.GetComponentsInChildren<Renderer>())
            {
                renderer.material = clawMaterial;
            }
        }
    }

    /// <summary>
    /// Применяет материалы для обычного врага (демон).
    /// </summary>
    private static void ApplyNormalEnemyMaterials(GameObject enemyModel)
    {
        // Темно-красный для тела
        Material bodyMaterial = CreateMaterial(new Color(0.8f, 0.1f, 0.1f));
        // Еще темнее для головы
        Material headMaterial = CreateMaterial(new Color(0.6f, 0.05f, 0.05f));
        // Черный для рогов
        Material hornMaterial = CreateMaterial(new Color(0.1f, 0.1f, 0.1f));
        // Бронзовый для брони
        Material armorMaterial = CreateMetallicMaterial(new Color(0.6f, 0.4f, 0.2f), 0.7f);
        // Светящийся красный для глаз
        Material eyeMaterial = CreateEmissiveMaterial(new Color(1f, 0.2f, 0.2f), 0.8f);
        // Серый для плеч
        Material shoulderMaterial = CreateMaterial(new Color(0.3f, 0.2f, 0.2f));
        // Коричневый для ног
        Material legMaterial = CreateMaterial(new Color(0.25f, 0.15f, 0.1f));
        // Серебристый для когтей
        Material clawMaterial = CreateMetallicMaterial(new Color(0.7f, 0.7f, 0.7f), 0.6f);

        ApplyMaterialToTransform(enemyModel, "Body", bodyMaterial);
        ApplyMaterialToTransform(enemyModel, "ChestPlate", armorMaterial);
        ApplyMaterialToTransform(enemyModel, "Head", headMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftEye", eyeMaterial);
        ApplyMaterialToTransform(enemyModel, "RightEye", eyeMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftHorn", hornMaterial);
        ApplyMaterialToTransform(enemyModel, "RightHorn", hornMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftShoulder", shoulderMaterial);
        ApplyMaterialToTransform(enemyModel, "RightShoulder", shoulderMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftShoulderSpike", armorMaterial);
        ApplyMaterialToTransform(enemyModel, "RightShoulderSpike", armorMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftLeg", legMaterial);
        ApplyMaterialToTransform(enemyModel, "RightLeg", legMaterial);
        ApplyMaterialToAllChildren(enemyModel, "LeftClaw", clawMaterial);
        ApplyMaterialToAllChildren(enemyModel, "RightClaw", clawMaterial);
    }

    /// <summary>
    /// Применяет материалы для быстрого врага (хищник).
    /// </summary>
    private static void ApplyFastEnemyMaterials(GameObject enemyModel)
    {
        // Желто-коричневый для тела (как у хищника)
        Material bodyMaterial = CreateMaterial(new Color(0.9f, 0.7f, 0.3f));
        // Светло-коричневый для головы
        Material headMaterial = CreateMaterial(new Color(0.85f, 0.65f, 0.25f));
        // Темно-коричневый для морды
        Material snoutMaterial = CreateMaterial(new Color(0.6f, 0.4f, 0.2f));
        // Светящийся желтый для глаз
        Material eyeMaterial = CreateEmissiveMaterial(new Color(1f, 0.9f, 0.3f), 0.9f);
        // Розовый для ушей
        Material earMaterial = CreateMaterial(new Color(0.9f, 0.6f, 0.6f));
        // Темно-коричневый для конечностей
        Material limbMaterial = CreateMaterial(new Color(0.7f, 0.5f, 0.3f));
        // Светло-коричневый для хвоста
        Material tailMaterial = CreateMaterial(new Color(0.8f, 0.6f, 0.4f));
        // Белый для когтей
        Material clawMaterial = CreateMaterial(new Color(0.95f, 0.95f, 0.9f));

        ApplyMaterialToTransform(enemyModel, "Body", bodyMaterial);
        ApplyMaterialToTransform(enemyModel, "Head", headMaterial);
        ApplyMaterialToTransform(enemyModel, "Snout", snoutMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftEye", eyeMaterial);
        ApplyMaterialToTransform(enemyModel, "RightEye", eyeMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftEar", earMaterial);
        ApplyMaterialToTransform(enemyModel, "RightEar", earMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftArm", limbMaterial);
        ApplyMaterialToTransform(enemyModel, "RightArm", limbMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftLeg", limbMaterial);
        ApplyMaterialToTransform(enemyModel, "RightLeg", limbMaterial);
        ApplyMaterialToTransform(enemyModel, "Tail", tailMaterial);
        ApplyMaterialToAllChildren(enemyModel, "LeftClaw", clawMaterial);
        ApplyMaterialToAllChildren(enemyModel, "RightClaw", clawMaterial);
    }

    /// <summary>
    /// Применяет материалы для танкового врага (бронированный гигант).
    /// </summary>
    private static void ApplyTankEnemyMaterials(GameObject enemyModel)
    {
        // Темно-бордовый для тела
        Material bodyMaterial = CreateMaterial(new Color(0.5f, 0.05f, 0.05f));
        // Темно-серый металлический для брони
        Material armorMaterial = CreateMetallicMaterial(new Color(0.25f, 0.25f, 0.3f), 0.8f);
        // Почти черный для шлема
        Material helmetMaterial = CreateMaterial(new Color(0.15f, 0.15f, 0.15f));
        // Светящийся оранжевый для глаза-циклопа
        Material eyeMaterial = CreateEmissiveMaterial(new Color(1f, 0.5f, 0.1f), 1.0f);
        // Темно-серый для плечевых пластин
        Material shoulderMaterial = CreateMetallicMaterial(new Color(0.3f, 0.3f, 0.35f), 0.7f);
        // Бронзовый для шипов
        Material spikeMaterial = CreateMetallicMaterial(new Color(0.5f, 0.35f, 0.2f), 0.6f);
        // Темный для ног
        Material legMaterial = CreateMaterial(new Color(0.4f, 0.1f, 0.1f));
        // Железный для оружия
        Material weaponMaterial = CreateMetallicMaterial(new Color(0.4f, 0.4f, 0.45f), 0.9f);

        ApplyMaterialToTransform(enemyModel, "Body", bodyMaterial);
        ApplyMaterialToTransform(enemyModel, "ChestArmor", armorMaterial);
        ApplyMaterialToTransform(enemyModel, "BackArmor", armorMaterial);
        ApplyMaterialToTransform(enemyModel, "Head", bodyMaterial);
        ApplyMaterialToTransform(enemyModel, "Helmet", helmetMaterial);
        ApplyMaterialToTransform(enemyModel, "EyeSocket", eyeMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftShoulderPlate", shoulderMaterial);
        ApplyMaterialToTransform(enemyModel, "RightShoulderPlate", shoulderMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftLeg", legMaterial);
        ApplyMaterialToTransform(enemyModel, "RightLeg", legMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftLegArmor", armorMaterial);
        ApplyMaterialToTransform(enemyModel, "RightLegArmor", armorMaterial);

        // Применяем материал шипов
        for (int i = 0; i < 3; i++)
        {
            ApplyMaterialToTransform(enemyModel, "LeftSpike_" + i, spikeMaterial);
            ApplyMaterialToTransform(enemyModel, "RightSpike_" + i, spikeMaterial);
        }

        ApplyMaterialToAllChildren(enemyModel, "Mace", weaponMaterial);
    }

    /// <summary>
    /// Применяет материалы для врага дальнего боя (магический лучник).
    /// </summary>
    private static void ApplyRangedEnemyMaterials(GameObject enemyModel)
    {
        // Голубой для тела
        Material bodyMaterial = CreateMaterial(new Color(0.2f, 0.6f, 0.8f));
        // Светло-голубой для головы
        Material headMaterial = CreateMaterial(new Color(0.3f, 0.7f, 0.9f));
        // Белесый для лба
        Material foreheadMaterial = CreateMaterial(new Color(0.85f, 0.9f, 0.95f));
        // Светящийся циан для глаз
        Material eyeMaterial = CreateEmissiveMaterial(new Color(0.3f, 1f, 1f), 1.0f);
        // Темно-синий для плеч
        Material shoulderMaterial = CreateMaterial(new Color(0.15f, 0.4f, 0.6f));
        // Серый для оружейной платформы
        Material platformMaterial = CreateMetallicMaterial(new Color(0.4f, 0.45f, 0.5f), 0.5f);
        // Древесный цвет для арбалета
        Material bowMaterial = CreateMaterial(new Color(0.5f, 0.35f, 0.2f));
        // Светящийся фиолетовый для кристаллов
        Material crystalMaterial = CreateEmissiveMaterial(new Color(0.7f, 0.3f, 1f), 0.8f);
        // Серебристый для болтов
        Material boltMaterial = CreateMetallicMaterial(new Color(0.8f, 0.8f, 0.85f), 0.7f);

        ApplyMaterialToTransform(enemyModel, "Body", bodyMaterial);
        ApplyMaterialToTransform(enemyModel, "Head", headMaterial);
        ApplyMaterialToTransform(enemyModel, "Forehead", foreheadMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftEye", eyeMaterial);
        ApplyMaterialToTransform(enemyModel, "CenterEye", eyeMaterial);
        ApplyMaterialToTransform(enemyModel, "RightEye", eyeMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftShoulder", shoulderMaterial);
        ApplyMaterialToTransform(enemyModel, "RightShoulder", shoulderMaterial);
        ApplyMaterialToTransform(enemyModel, "WeaponPlatform", platformMaterial);
        ApplyMaterialToTransform(enemyModel, "LeftLeg", shoulderMaterial);
        ApplyMaterialToTransform(enemyModel, "RightLeg", shoulderMaterial);
        ApplyMaterialToTransform(enemyModel, "Crystal1", crystalMaterial);
        ApplyMaterialToTransform(enemyModel, "Crystal2", crystalMaterial);

        ApplyMaterialToAllChildren(enemyModel, "Crossbow", bowMaterial);
        ApplyMaterialToTransform(enemyModel, "Bolt", boltMaterial);
    }

    /// <summary>
    /// Создает базовый материал.
    /// </summary>
    private static Material CreateMaterial(Color color)
    {
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = color;
        return mat;
    }

    /// <summary>
    /// Создает металлический материал.
    /// </summary>
    private static Material CreateMetallicMaterial(Color color, float metallic)
    {
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = color;
        mat.SetFloat("_Metallic", metallic);
        mat.SetFloat("_Glossiness", 0.7f);
        return mat;
    }

    /// <summary>
    /// Создает светящийся материал.
    /// </summary>
    private static Material CreateEmissiveMaterial(Color color, float emissionIntensity)
    {
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = color;
        mat.SetColor("_EmissionColor", color * emissionIntensity);
        mat.SetFloat("_Emission", emissionIntensity);
        return mat;
    }

    /// <summary>
    /// Применяет материал к конкретному трансформу по имени.
    /// </summary>
    private static void ApplyMaterialToTransform(GameObject parent, string transformName, Material material)
    {
        Transform transform = parent.transform.Find(transformName);
        if (transform != null)
        {
            Renderer renderer = transform.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = material;
            }
        }
    }

    /// <summary>
    /// Применяет материал ко всем детям указанного трансформа.
    /// </summary>
    private static void ApplyMaterialToAllChildren(GameObject parent, string parentName, Material material)
    {
        Transform parentTransform = parent.transform.Find(parentName);
        if (parentTransform != null)
        {
            foreach (Renderer renderer in parentTransform.GetComponentsInChildren<Renderer>())
            {
                renderer.material = material;
            }
        }
    }
}

#if UNITY_EDITOR
/// <summary>
/// Редакторский инструмент для создания моделей.
/// </summary>
public class ModelGeneratorEditor : EditorWindow
{
    [MenuItem("Tools/Model Generator/Create Player Model")]
    public static void CreatePlayerModelInScene()
    {
        GameObject playerModel = ModelGenerator.CreatePlayerModel();
        playerModel.transform.position = Vector3.zero;
        Selection.activeGameObject = playerModel;
        Debug.Log("✅ Player model created!");
    }

    [MenuItem("Tools/Model Generator/Create Enemy Model")]
    public static void CreateEnemyModelInScene()
    {
        CreateSpecificEnemyModel(EnemyFactory.EnemyType.Normal);
    }

    [MenuItem("Tools/Model Generator/Create Normal Enemy")]
    public static void CreateNormalEnemyInScene()
    {
        CreateSpecificEnemyModel(EnemyFactory.EnemyType.Normal);
    }

    [MenuItem("Tools/Model Generator/Create Fast Enemy")]
    public static void CreateFastEnemyInScene()
    {
        CreateSpecificEnemyModel(EnemyFactory.EnemyType.Fast);
    }

    [MenuItem("Tools/Model Generator/Create Tank Enemy")]
    public static void CreateTankEnemyInScene()
    {
        CreateSpecificEnemyModel(EnemyFactory.EnemyType.Tank);
    }

    [MenuItem("Tools/Model Generator/Create Ranged Enemy")]
    public static void CreateRangedEnemyInScene()
    {
        CreateSpecificEnemyModel(EnemyFactory.EnemyType.Ranged);
    }

    private static void CreateSpecificEnemyModel(EnemyFactory.EnemyType enemyType)
    {
        GameObject enemyModel = ModelGenerator.CreateEnemyModel(enemyType);
        enemyModel.transform.position = new Vector3(2, 0, 0);
        Selection.activeGameObject = enemyModel;
        Debug.Log($"✅ {enemyType} enemy model created!");
    }

    [MenuItem("Tools/Model Generator/Show Window")]
    public static void ShowWindow()
    {
        GetWindow<ModelGeneratorEditor>("Model Generator");
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("🎨 Model Generator", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        // Player Section
        EditorGUILayout.LabelField("Player Models", EditorStyles.boldLabel);
        if (GUILayout.Button("Create Player Model", GUILayout.Height(35)))
        {
            CreatePlayerModelInScene();
        }

        EditorGUILayout.Space();

        // Enemy Section
        EditorGUILayout.LabelField("Enemy Models", EditorStyles.boldLabel);

        if (GUILayout.Button("Create Normal Enemy (Demon)", GUILayout.Height(30)))
        {
            CreateNormalEnemyInScene();
        }

        if (GUILayout.Button("Create Fast Enemy (Feral)", GUILayout.Height(30)))
        {
            CreateFastEnemyInScene();
        }

        if (GUILayout.Button("Create Tank Enemy (Armored)", GUILayout.Height(30)))
        {
            CreateTankEnemyInScene();
        }

        if (GUILayout.Button("Create Ranged Enemy (Archer)", GUILayout.Height(30)))
        {
            CreateRangedEnemyInScene();
        }

        EditorGUILayout.Space();

        // Info Box
        EditorGUILayout.HelpBox(
            "Model Descriptions:\n\n" +
            "Player: Blue hero with sword\n" +
            "Normal: Red demon with horns, claws, and armor\n" +
            "Fast: Yellow feral predator with sharp claws\n" +
            "Tank: Dark armored giant with mace and spikes\n" +
            "Ranged: Cyan mage with crossbow and crystals",
            MessageType.Info
        );
    }
}
#endif