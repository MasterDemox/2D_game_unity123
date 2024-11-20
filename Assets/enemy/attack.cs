using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; // �������� �����
    public float attackRange = 1f; // ��������� �����
    public float attackDamage = 10f; // ���� �����
    public float attackCooldown = 1f; // ����� ����� �������

    private Transform Player; // ������ �� ������
    private float lastAttackTime;

    void Start()
    {
        // ������� ������ �� ����
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Player != null)
        {
            MoveTowardsPlayer();

            // ���������, ����� �� ���������
            if (Vector2.Distance(transform.position, Player.position) <= attackRange)
            {
                AttackPlayer();
            } 
        }
    }

    void MoveTowardsPlayer()
    {
        // ������� ����� � ������
        Vector2 direction = (Player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        // ���������, ������ �� ����� ��� �����
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            // ������ �����
            Debug.Log("Attack!");
            lastAttackTime = Time.time;

            // ������� ���� ������
            Player playerScript = Player.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(attackDamage);
            }
        }
    }
}