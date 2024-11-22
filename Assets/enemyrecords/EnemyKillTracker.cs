using UnityEngine;
using UnityEngine.UI;
public class EnemyKillTracker : MonoBehaviour
{
    private int killCount = 0; // Счетчик убитых врагов

    public GameObject UIText;
   
    // Метод для увеличения счетчика убитых врагов
    public void IncrementKillCount()
    {
        killCount++;
        Debug.Log($"Total enemies killed: {killCount}");
        UIText.GetComponent<Text>().text = "Убито врагов:" + killCount.ToString();
    }


}