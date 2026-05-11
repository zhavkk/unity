using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Тестовый запускщик для проверки всех игровых систем.
/// Используйте для отладки и тестирования механик.
/// </summary>
public class GameTestRunner : MonoBehaviour
{
    [Header("Тестовые настройки")]
    [SerializeField] private bool runTestsOnStart = true;
    [SerializeField] private bool verboseLogging = true;

    private int passedTests = 0;
    private int failedTests = 0;

    private void Start()
    {
        if (runTestsOnStart)
        {
            RunAllTests();
        }
    }

    private void RunAllTests()
    {
        Debug.Log("=== НАЧИНАЕМ ТЕСТИРОВАНИЕ ИГРОВЫХ СИСТЕМ ===");

        TestPlayerComponents();
        TestEnemyComponents();
        TestWaveManager();
        TestUIComponents();
        TestInputSystem();
        TestModelGeneration();

        Debug.Log($"=== ТЕСТИРОВАНИЕ ЗАВЕРШЕНО ===");
        Debug.Log($"✅ Пройдено: {passedTests}");
        Debug.Log($"❌ Не пройдено: {failedTests}");

        if (failedTests == 0)
        {
            Debug.Log("🎉 ВСЕ ТЕСТЫ ПРОЙДЕНЫ! Игра готова к запуску.");
        }
        else
        {
            Debug.LogWarning("⚠️ Некоторые тесты не пройдены. Проверьте логи.");
        }
    }

    private void TestPlayerComponents()
    {
        LogTest("Тестирование компонентов игрока...");

        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            FailTest("Игрок не найден в сцене");
            return;
        }

        PassTest("Игрок найден");

        // Проверяем CharacterController
        CharacterController charController = player.GetComponent<CharacterController>();
        if (charController == null)
        {
            FailTest("CharacterController отсутствует");
        }
        else
        {
            PassTest("CharacterController присутствует");
        }

        // Проверяем EnhancedPlayerController
        EnhancedPlayerController playerController = player.GetComponent<EnhancedPlayerController>();
        if (playerController == null)
        {
            FailTest("EnhancedPlayerController отсутствует");
        }
        else
        {
            PassTest("EnhancedPlayerController присутствует");
        }

        // Проверяем PlayerAttract
        PlayerAttract playerAttract = player.GetComponent<PlayerAttract>();
        if (playerAttract == null)
        {
            FailTest("PlayerAttract отсутствует");
        }
        else
        {
            PassTest("PlayerAttract присутствует");
        }

        // Проверяем RageSystem
        RageSystem rageSystem = player.GetComponent<RageSystem>();
        if (rageSystem == null)
        {
            FailTest("RageSystem отсутствует");
        }
        else
        {
            PassTest("RageSystem присутствует");
            TestRageSystem(rageSystem);
        }

        // Проверяем PlayerHealth
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            FailTest("PlayerHealth отсутствует");
        }
        else
        {
            PassTest("PlayerHealth присутствует");
            TestPlayerHealth(playerHealth);
        }

        // Проверяем GameIntegrator
        GameIntegrator gameIntegrator = player.GetComponent<GameIntegrator>();
        if (gameIntegrator == null)
        {
            FailTest("GameIntegrator отсутствует");
        }
        else
        {
            PassTest("GameIntegrator присутствует");
        }

        // Проверяем модель игрока
        Transform playerModel = player.transform.Find("PlayerModel");
        if (playerModel == null)
        {
            FailTest("Модель игрока отсутствует");
        }
        else
        {
            PassTest("Модель игрока присутствует");
        }
    }

    private void TestRageSystem(RageSystem rageSystem)
    {
        LogTest("Тестирование системы ярости...");

        if (rageSystem.maxRage <= 0)
        {
            FailTest("Максимальная ярость не задана");
            return;
        }

        PassTest($"Максимальная ярость: {rageSystem.maxRage}");

        if (rageSystem.ragePerAttack <= 0)
        {
            FailTest("Ярость за атаку не задана");
        }
        else
        {
            PassTest($"Ярость за атаку: {rageSystem.ragePerAttack}");
        }

        if (rageSystem.maxDamageMultiplier <= 1)
        {
            FailTest("Множитель урона не задан");
        }
        else
        {
            PassTest($"Множитель урона: x{rageSystem.maxDamageMultiplier}");
        }
    }

    private void TestPlayerHealth(PlayerHealth playerHealth)
    {
        LogTest("Тестирование системы здоровья...");

        float maxHealth = playerHealth.GetMaxHealth();
        if (maxHealth <= 0)
        {
            FailTest("Максимальное здоровье не задано");
            return;
        }

        PassTest($"Максимальное здоровье: {maxHealth}");

        float currentHealth = playerHealth.GetCurrentHealth();
        if (currentHealth != maxHealth)
        {
            FailTest($"Текущее здоровье ({currentHealth}) не равно максимальному ({maxHealth})");
        }
        else
        {
            PassTest("Текущее здоровье равно максимальному");
        }
    }

    private void TestEnemyComponents()
    {
        LogTest("Тестирование компонентов врага...");

        // Проверяем наличие врагов в сцене
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            LogTest("Враги в сцене не найдены (это нормально для старта игры)");
            return;
        }

        PassTest($"Найдено врагов в сцене: {enemies.Length}");

        GameObject testEnemy = enemies[0];

        // Проверяем компоненты врага
        EnemyController enemyController = testEnemy.GetComponent<EnemyController>();
        if (enemyController == null)
        {
            FailTest("EnemyController отсутствует у врага");
        }
        else
        {
            PassTest("EnemyController присутствует у врага");
        }

        EnemyHealth enemyHealth = testEnemy.GetComponent<EnemyHealth>();
        if (enemyHealth == null)
        {
            FailTest("EnemyHealth отсутствует у врага");
        }
        else
        {
            PassTest("EnemyHealth присутствует у врага");
        }

        // Проверяем модель врага
        Transform enemyModel = testEnemy.transform.Find("EnemyModel");
        if (enemyModel == null)
        {
            FailTest("Модель врага отсутствует");
        }
        else
        {
            PassTest("Модель врага присутствует");
        }
    }

    private void TestWaveManager()
    {
        LogTest("Тестирование WaveManager...");

        WaveManager[] waveManagers = Object.FindObjectsByType<WaveManager>();
        if (waveManagers == null || waveManagers.Length == 0)
        {
            FailTest("WaveManager не найден в сцене");
            return;
        }

        PassTest("WaveManager найден в сцене");

        WaveManager waveManager = waveManagers[0];

        if (waveManager.startingEnemies <= 0)
        {
            FailTest("Начальное количество врагов не задано");
        }
        else
        {
            PassTest($"Начальное количество врагов: {waveManager.startingEnemies}");
        }

        if (waveManager.enemyPrefab == null)
        {
            FailTest("Префаб врага не назначен");
        }
        else
        {
            PassTest("Префаб врага назначен");
        }
    }

    private void TestUIComponents()
    {
        LogTest("Тестирование UI компонентов...");

        Canvas[] canvases = Object.FindObjectsByType<Canvas>();
        if (canvases == null || canvases.Length == 0)
        {
            FailTest("Canvas не найден в сцене");
            return;
        }

        PassTest("Canvas найден в сцене");

        Canvas canvas = canvases[0];

        // Проверяем наличие базовых UI элементов
        bool hasHealthPanel = canvas.transform.Find("HealthPanel") != null;
        bool hasRagePanel = canvas.transform.Find("RagePanel") != null;
        bool hasWavePanel = canvas.transform.Find("WavePanel") != null;
        bool hasInstructions = canvas.transform.Find("InstructionsPanel") != null;

        if (hasHealthPanel)
        {
            PassTest("Панель здоровья присутствует");
        }
        else
        {
            FailTest("Панель здоровья отсутствует");
        }

        if (hasRagePanel)
        {
            PassTest("Панель ярости присутствует");
        }
        else
        {
            FailTest("Панель ярости отсутствует");
        }

        if (hasWavePanel)
        {
            PassTest("Панель волн присутствует");
        }
        else
        {
            FailTest("Панель волн отсутствует");
        }

        if (hasInstructions)
        {
            PassTest("Панель инструкций присутствует");
        }
        else
        {
            FailTest("Панель инструкций отсутствует");
        }
    }

    private void TestInputSystem()
    {
        LogTest("Тестирование системы ввода...");

        // Проверяем наличие файла InputSystem_Actions
        bool inputActionsExists = System.IO.File.Exists("Assets/InputSystem_Actions.inputactions");
        if (!inputActionsExists)
        {
            FailTest("InputSystem_Actions.inputactions файл не найден");
            return;
        }

        PassTest("InputSystem_Actions.inputactions файл найден");

        // Проверяем что Input System доступен
        try
        {
            var inputSystem = UnityEngine.InputSystem.InputSystem.settings;
            if (inputSystem != null)
            {
                PassTest("Input System доступен");
            }
            else
            {
                FailTest("Input System не доступен");
            }
        }
        catch (System.Exception e)
        {
            FailTest($"Ошибка при проверке Input System: {e.Message}");
        }
    }

    private void TestModelGeneration()
    {
        LogTest("Тестирование генерации моделей...");

        // Тестируем создание модели игрока
        try
        {
            GameObject testPlayerModel = ModelGenerator.CreatePlayerModel();
            if (testPlayerModel == null)
            {
                FailTest("Не удалось создать модель игрока");
            }
            else
            {
                PassTest("Модель игрока успешно создана");

                // Проверяем наличие частей тела
                bool hasBody = testPlayerModel.transform.Find("Body") != null;
                bool hasHead = testPlayerModel.transform.Find("Head") != null;
                bool hasWeapon = testPlayerModel.transform.Find("Weapon") != null;

                if (hasBody && hasHead && hasWeapon)
                {
                    PassTest("Модель игрока содержит все необходимые части");
                }
                else
                {
                    FailTest("Модель игрока не содержит все необходимые части");
                }

                Object.DestroyImmediate(testPlayerModel);
            }
        }
        catch (System.Exception e)
        {
            FailTest($"Ошибка при создании модели игрока: {e.Message}");
        }

        // Тестируем создание модели врага
        try
        {
            GameObject testEnemyModel = ModelGenerator.CreateEnemyModel();
            if (testEnemyModel == null)
            {
                FailTest("Не удалось создать модель врага");
            }
            else
            {
                PassTest("Модель врага успешно создана");

                // Проверяем наличие частей тела
                bool hasBody = testEnemyModel.transform.Find("Body") != null;
                bool hasHead = testEnemyModel.transform.Find("Head") != null;
                bool hasClaws = testEnemyModel.transform.Find("LeftClaw") != null &&
                               testEnemyModel.transform.Find("RightClaw") != null;

                if (hasBody && hasHead && hasClaws)
                {
                    PassTest("Модель врага содержит все необходимые части");
                }
                else
                {
                    FailTest("Модель врага не содержит все необходимые части");
                }

                Object.DestroyImmediate(testEnemyModel);
            }
        }
        catch (System.Exception e)
        {
            FailTest($"Ошибка при создании модели врага: {e.Message}");
        }
    }

    private void LogTest(string message)
    {
        if (verboseLogging)
        {
            Debug.Log($"🧪 {message}");
        }
    }

    private void PassTest(string message)
    {
        passedTests++;
        if (verboseLogging)
        {
            Debug.Log($"✅ {message}");
        }
    }

    private void FailTest(string message)
    {
        failedTests++;
        Debug.LogError($"❌ {message}");
    }
}