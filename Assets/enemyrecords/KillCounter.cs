using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public Text killCountText; // Ссылка на UI элемент текста
    private int killCount = 0; // Счетчик убитых врагов

    void Start()
    {
        UpdateKillCountText(); // Обновляем текст при старте
    }

    public void IncrementKillCount()
    {
        killCount++; // Увеличиваем счетчик
        Debug.Log("Количество убитых врагов: " + killCount); // Отладочный вывод
        UpdateKillCountText(); // Обновляем текст
    }

    private void UpdateKillCountText()
    {
        killCountText.text = "Убито врагов: " + killCount; // Обновляем текст
    }
}