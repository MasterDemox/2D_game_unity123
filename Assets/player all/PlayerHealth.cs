using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Переменные для первого скрипта
    public float maxHealth = 100f; // Максимальное здоровье
    private float currentHealth; // Текущее здоровье
    public Transform spawnPoint; // Точка возрождения
    private PlayerMovement playerMovement; // Ссылка на компонент PlayerMovement

    // Переменные для второго скрипта
    public Slider healthBar; // Слайдер здоровья на UI

    void Start()
    {
        currentHealth = maxHealth; // Инициализация текущего здоровья
        playerMovement = GetComponent<PlayerMovement>(); // Получение компонента PlayerMovement
        UpdateHealthBar(); // Обновление слайдера здоровья
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Уменьшение текущего здоровья
        Debug.Log("Player took damage: " + damage + ". Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            StartCoroutine(Die()); // Если здоровье равно 0 или меньше, запускаем корутину смерти
        }
        else
        {
            UpdateHealthBar(); // Обновляем слайдер здоровья
        }
    }

    private IEnumerator Die()
    {
        playerMovement.Die(); // Вызываем метод смерти из PlayerMovement
        yield return new WaitForSeconds(3f); // Ждем 3 секунды

        transform.position = spawnPoint.position; // Перемещаем игрока на точку возрождения
        RestoreHealth(); // Восстанавливаем здоровье
        playerMovement.Revive(); // Вызываем метод возрождения из PlayerMovement
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth; // Восстанавливаем здоровье до максимального
        UpdateHealthBar(); // Обновляем слайдер здоровья
        Debug.Log("Player health restored to: " + currentHealth);
    }

    // Метод для проверки, мертв ли игрок
    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    // Метод для получения текущего здоровья
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    void UpdateHealthBar()
    {
        healthBar.value = currentHealth / maxHealth; // Обновление значения слайдера
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Проверка на столкновение с врагом
        {
            TakeDamage(10); // Уменьшение здоровья на 10
        }
    }
}