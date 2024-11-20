using UnityEngine;

public class Player : MonoBehaviour
{
    public float HP = 100f;

    public void TakeDamage(float damage)
    {
        HP -= damage;
        Debug.Log("Player HP: " + HP);
        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Логика смерти игрока
    }
}