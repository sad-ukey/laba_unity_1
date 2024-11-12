using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // �������� ������
    public int damage = 10; // ���� ������

    void Update()
    {
        // �������� �� �������� (�������������)
        if (health <= 0)
        {
            Die(); // ���� �������� 0 ��� ����, ������� ������.
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; // ��������� �������� �� �������� �����
    }

    void Die()
    {
        // ������ ������ ������
        Debug.Log("Player is dead!"); // ����� ����� �������� ������ ������
        Destroy(gameObject); // ����������� ������ (�� �����������, ����� ������� �����)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster")) // �������� �� ��������������� � ��������
        {
            MovingMonster monster = collision.gameObject.GetComponent<MovingMonster>();
            if (monster != null)
            {
                monster.TakeDamage(damage); // ������� ���� �������
            }
        }
    }
}
