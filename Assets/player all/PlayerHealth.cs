using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // ������������ ��������
    private int currentHealth; // ������� ��������
    public Slider healthBar; // ������ �� UI ������� (Health Bar)

    void Start()
    {
        currentHealth = maxHealth; // ������������� �������� ��������
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.value = (float)currentHealth / maxHealth; // ���������� �������� �������� �� ����
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // �������� �� ������������ � ������
        {
            TakeDamage(10); // ���������� �������� �� 10
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ���������� �������� ��������
        if (currentHealth < 0)
        {
            currentHealth = 0; // ������ �� �������������� ��������
        }
        UpdateHealthBar(); // ���������� HP ����
    }
}