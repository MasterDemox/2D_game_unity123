using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public Text killCountText; // ������ �� UI ������� ������
    private int killCount = 0; // ������� ������ ������

    void Start()
    {
        UpdateKillCountText(); // ��������� ����� ��� ������
    }

    public void IncrementKillCount()
    {
        killCount++; // ����������� �������
        Debug.Log("���������� ������ ������: " + killCount); // ���������� �����
        UpdateKillCountText(); // ��������� �����
    }

    private void UpdateKillCountText()
    {
        killCountText.text = "����� ������: " + killCount; // ��������� �����
    }
}