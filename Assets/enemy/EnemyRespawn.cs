using System.Collections;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����, ������� ����� ����������
    public Transform spawnPoint; // �����, ��� ����� ���������� ����
    public float respawnTime = 5f; // ����� ����������� �����

    private void Start()
    {
        // ������� ����� ����� ��� ������
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
        if (enemyAI != null)
        {
            enemyAI.spawnPoint = spawnPoint; // ������������� ���������� ��� �����
        }
    }

    public void OnEnemyDied()
    {
        StartCoroutine(RespawnEnemy());
    }

    private IEnumerator RespawnEnemy()
    {
        // ���� ��������� ����� ����� ������������
        yield return new WaitForSeconds(respawnTime);
        SpawnEnemy();
    }
}