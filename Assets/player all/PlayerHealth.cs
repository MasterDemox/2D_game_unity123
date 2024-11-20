using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // ������������ �������� ������
    private float currentHealth; // ������� �������� ������
    public Transform spawnPoint; // ����� �����������
    private PlayerMovement playerMovement; // ������ �� ������ PlayerMovement

    void Start()
    {
        currentHealth = maxHealth; // ������������� ������� �������� �� ��������
        playerMovement = GetComponent<PlayerMovement>(); // �������� ������ �� PlayerMovement
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // ��������� �������� �� �������� �����
        Debug.Log("Player took damage: " + damage + ". Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            StartCoroutine(Die()); // ���� �������� ������ ��� ����� ����, �������� �������� ������
        }
    }

    private IEnumerator Die()
    {
        playerMovement.Die(); // ��������� �������� ������
        yield return new WaitForSeconds(3f); // ���� 3 ������� ����� ������������

        transform.position = spawnPoint.position; // ����������� ������ �� spawnPoint
        RestoreHealth(); // ��������������� ��������
        playerMovement.Revive(); // ������������ �������� ������
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth; // ��������������� �������� �� ���������
        Debug.Log("Player health restored to: " + currentHealth);
    }

    // ����� ��� ��������, ����� �� �����
    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    // ����� ��� ��������� �������� ��������
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}