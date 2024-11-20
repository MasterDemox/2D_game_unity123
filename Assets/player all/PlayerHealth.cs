using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Максимальное здоровье игрока
    private float currentHealth; // Текущее здоровье игрока
    public Transform spawnPoint; // Точка возрождения
    private PlayerMovement playerMovement; // Ссылка на скрипт PlayerMovement

    void Start()
    {
        currentHealth = maxHealth; // Устанавливаем текущее здоровье на максимум
        playerMovement = GetComponent<PlayerMovement>(); // Получаем ссылку на PlayerMovement
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Уменьшаем здоровье на величину урона
        Debug.Log("Player took damage: " + damage + ". Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            StartCoroutine(Die()); // Если здоровье меньше или равно нулю, вызываем корутину смерти
        }
    }

    private IEnumerator Die()
    {
        playerMovement.Die(); // Блокируем движение игрока
        yield return new WaitForSeconds(3f); // Ждем 3 секунды перед возрождением

        transform.position = spawnPoint.position; // Перемещение игрока на spawnPoint
        RestoreHealth(); // Восстанавливаем здоровье
        playerMovement.Revive(); // Разблокируем движение игрока
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth; // Восстанавливаем здоровье до максимума
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
}