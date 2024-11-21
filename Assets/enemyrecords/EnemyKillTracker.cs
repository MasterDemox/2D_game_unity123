using UnityEngine;

public class EnemyKillTracker : MonoBehaviour
{
    private int killCount = 0; // Счетчик убитых врагов

    // Метод для увеличения счетчика убитых врагов
    public void IncrementKillCount()
    {
        killCount++;
        Debug.Log($"Total enemies killed: {killCount}");
    }
}