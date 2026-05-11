using System.Collections.Generic;
using UnityEngine;

public class MvpEnemySpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int maxEnemies = 8;
    [SerializeField] private float spawnRadius = 12f;
    [SerializeField] private float minDistanceFromPlayer = 4f;
    [SerializeField] private GameObject enemyModelPrefab;

    private readonly List<MvpEnemy> activeEnemies = new List<MvpEnemy>();
    private Transform player;
    private MvpPlayerHealth playerHealth;
    private Material enemyMaterial;
    private float timer;

    public void Initialize(Transform playerTransform, MvpPlayerHealth health, Material material, GameObject modelPrefab)
    {
        player = playerTransform;
        playerHealth = health;
        enemyMaterial = material;
        enemyModelPrefab = modelPrefab;
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer < spawnInterval)
        {
            return;
        }

        timer = 0f;
        if (activeEnemies.Count >= maxEnemies)
        {
            return;
        }

        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Vector2 circle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = player.position + new Vector3(circle.x, 1f, circle.y);

        float distance = Vector3.Distance(spawnPosition, player.position);
        if (distance < minDistanceFromPlayer)
        {
            Vector3 direction = spawnPosition - player.position;
            if (direction.sqrMagnitude < 0.0001f)
            {
                direction = Vector3.forward;
            }

            spawnPosition = player.position + direction.normalized * minDistanceFromPlayer;
        }

        GameObject enemyObj = new GameObject("Enemy");
        enemyObj.transform.position = spawnPosition;

        CharacterController controller = enemyObj.AddComponent<CharacterController>();
        controller.height = 2f;
        controller.radius = 0.5f;
        controller.center = new Vector3(0f, 1f, 0f);

        MvpEnemy enemy = enemyObj.AddComponent<MvpEnemy>();
        enemy.Initialize(player, playerHealth);
        enemy.OnDied += HandleEnemyDied;

        if (enemyModelPrefab != null)
        {
            GameObject model = Instantiate(enemyModelPrefab, enemyObj.transform);
            model.name = "Model";
            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            model.transform.localScale = Vector3.one;
            RemoveChildColliders(model.transform);
        }
        else
        {
            GameObject model = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            model.name = "Model";
            model.transform.SetParent(enemyObj.transform);
            model.transform.localPosition = new Vector3(0f, 1f, 0f);
            model.transform.localScale = new Vector3(0.5f, 1f, 0.5f);

            Renderer renderer = model.GetComponent<Renderer>();
            if (renderer != null && enemyMaterial != null)
            {
                renderer.sharedMaterial = enemyMaterial;
            }

            Collider collider = model.GetComponent<Collider>();
            if (collider != null)
            {
                Destroy(collider);
            }
        }

        activeEnemies.Add(enemy);
    }

    private void HandleEnemyDied(MvpEnemy enemy)
    {
        if (enemy == null)
        {
            return;
        }

        enemy.OnDied -= HandleEnemyDied;
        activeEnemies.Remove(enemy);
    }

    private static void RemoveChildColliders(Transform root)
    {
        Collider[] colliders = root.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            Destroy(collider);
        }
    }
}
