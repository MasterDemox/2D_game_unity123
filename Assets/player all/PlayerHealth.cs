using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное здоровье
    private int currentHealth; // Текущее здоровье
    public Slider healthBar; // Ссылка на UI элемент (Health Bar)

    void Start()
    {
        currentHealth = maxHealth; // Инициализация текущего здоровья
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.value = (float)currentHealth / maxHealth; // Обновление значения здоровья на баре
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Проверка на столкновение с врагом
        {
            TakeDamage(10); // Уменьшение здоровья на 10
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Уменьшение текущего здоровья
        if (currentHealth < 0)
        {
            currentHealth = 0; // Защита от отрицательного здоровья
        }
        UpdateHealthBar(); // Обновление HP бара
    }
}