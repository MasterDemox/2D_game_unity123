using UnityEngine;

public class EnemyKillTracker : MonoBehaviour
{
    private int killCount = 0; // ������� ������ ������

    // ����� ��� ���������� �������� ������ ������
    public void IncrementKillCount()
    {
        killCount++;
        Debug.Log($"Total enemies killed: {killCount}");
    }
}