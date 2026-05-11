using UnityEngine;

/// <summary>
/// Test script to verify enemy model generation works correctly.
/// Attach this to an empty GameObject and press Play in Unity Editor.
/// </summary>
public class EnemyModelTest : MonoBehaviour
{
    [Header("Test Settings")]
    public bool spawnOnStart = true;
    public float spawnDistance = 3f;

    void Start()
    {
        if (spawnOnStart)
        {
            SpawnAllEnemyTypes();
        }
    }

    void Update()
    {
        // Press 1-4 to spawn different enemy types
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnEnemy(EnemyFactory.EnemyType.Normal, Vector3.zero);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnEnemy(EnemyFactory.EnemyType.Fast, Vector3.zero);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnEnemy(EnemyFactory.EnemyType.Tank, Vector3.zero);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SpawnEnemy(EnemyFactory.EnemyType.Ranged, Vector3.zero);
        }
    }

    void SpawnAllEnemyTypes()
    {
        Vector3[] positions = new Vector3[]
        {
            new Vector3(-spawnDistance * 1.5f, 0, 0),
            new Vector3(-spawnDistance * 0.5f, 0, 0),
            new Vector3(spawnDistance * 0.5f, 0, 0),
            new Vector3(spawnDistance * 1.5f, 0, 0)
        };

        EnemyFactory.EnemyType[] types = new EnemyFactory.EnemyType[]
        {
            EnemyFactory.EnemyType.Normal,
            EnemyFactory.EnemyType.Fast,
            EnemyFactory.EnemyType.Tank,
            EnemyFactory.EnemyType.Ranged
        };

        for (int i = 0; i < types.Length; i++)
        {
            SpawnEnemy(types[i], positions[i]);
        }

        Debug.Log("✅ All enemy types spawned for testing!");
    }

    void SpawnEnemy(EnemyFactory.EnemyType type, Vector3 position)
    {
        GameObject enemy = EnemyFactory.CreateEnemy(type, position + transform.position);
        Debug.Log($"✅ Spawned {type} enemy at {position}");
    }
}
