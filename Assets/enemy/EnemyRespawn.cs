using System.Collections;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага, который будет спавниться
    public Transform spawnPoint; // Точка, где будет спавниться враг
    public float respawnTime = 5f; // Время возрождения врага

    private void Start()
    {
        // Спавним врага сразу при старте
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
        if (enemyAI != null)
        {
            enemyAI.spawnPoint = spawnPoint; // Устанавливаем спавнпоинт для врага
        }
    }

    public void OnEnemyDied()
    {
        StartCoroutine(RespawnEnemy());
    }

    private IEnumerator RespawnEnemy()
    {
        // Ждем указанное время перед возрождением
        yield return new WaitForSeconds(respawnTime);
        SpawnEnemy();
    }
}