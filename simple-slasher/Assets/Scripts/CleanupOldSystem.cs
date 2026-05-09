using UnityEngine;
using UnityEditor;

/// <summary>
/// Скрипт для очистки сцены от старой, нерабочей системы CompleteGameSetup
/// Запустите этот скрипт через меню: Tools → Cleanup Old System
/// </summary>
public class CleanupOldSystem
{
    [MenuItem("Tools/Cleanup Old System")]
    public static void Cleanup()
    {
        int removedCount = 0;

        // Найти и удалить CompleteGameSetup
        CompleteGameSetup[] oldSetups = GameObject.FindObjectsOfType<CompleteGameSetup>();
        foreach (var setup in oldSetups)
        {
            Debug.Log($"Удаление CompleteGameSetup: {setup.gameObject.name}");
            GameObject.DestroyImmediate(setup.gameObject);
            removedCount++;
        }

        // Найти и удалить старые менеджеры
        string[] oldManagers = { "GameManager", "VFXManager", "ComboSystem", "FloatingTextManager", "GameMenuManager", "UpgradeSystem" };
        foreach (string managerName in oldManagers)
        {
            GameObject[] managers = GameObject.FindGameObjectsWithTag(managerName);
            foreach (var manager in managers)
            {
                Debug.Log($"Удаление {managerName}: {manager.name}");
                GameObject.DestroyImmediate(manager);
                removedCount++;
            }
        }

        // Найти и удалить старый WaveManager (не SimpleWaveManager)
        WaveManager[] oldWaveManagers = GameObject.FindObjectsOfType<WaveManager>();
        foreach (var wm in oldWaveManagers)
        {
            Debug.Log($"Удаление старого WaveManager: {wm.gameObject.name}");
            GameObject.DestroyImmediate(wm.gameObject);
            removedCount++;
        }

        // Найти и удалить старых игроков (не SimplePlayerController)
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            // Проверяем, есть ли у игрока SimplePlayerController
            if (player.GetComponent<SimplePlayerController>() == null)
            {
                Debug.Log($"Удаление старого Player: {player.name}");
                GameObject.DestroyImmediate(player);
                removedCount++;
            }
        }

        // Найти и удалить EnemyTemplate
        GameObject[] enemyTemplates = GameObject.FindGameObjectsWithTag("EnemyTemplate");
        foreach (var template in enemyTemplates)
        {
            Debug.Log($"Удаление EnemyTemplate: {template.name}");
            GameObject.DestroyImmediate(template);
            removedCount++;
        }

        Debug.Log($"=== ОЧИСТКА ЗАВЕРШЕНА ===");
        Debug.Log($"Удалено объектов: {removedCount}");
        Debug.Log($"Теперь добавьте SimpleGameSetup в сцену!");

        EditorUtility.DisplayDialog("Очистка завершена",
            $"Удалено {removedCount} старых объектов.\n\nТеперь добавьте SimpleGameSetup в сцену через GameObject → Create Empty → Add Component → SimpleGameSetup",
            "OK");
    }
}
