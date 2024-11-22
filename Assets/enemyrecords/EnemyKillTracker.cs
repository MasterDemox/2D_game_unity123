using UnityEngine;
using UnityEngine.UI;
public class EnemyKillTracker : MonoBehaviour
{
    private int killCount = 0; // ������� ������ ������

    public GameObject UIText;
   
    // ����� ��� ���������� �������� ������ ������
    public void IncrementKillCount()
    {
        killCount++;
        Debug.Log($"Total enemies killed: {killCount}");
        UIText.GetComponent<Text>().text = "����� ������:" + killCount.ToString();
    }


}