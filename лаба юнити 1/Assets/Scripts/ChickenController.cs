using UnityEngine;

public class MovingMonster : MonoBehaviour
{
    public float speed = 2.0f; // �������� �������� �������
    public int health = 200; // �������� �������
    public int damage = 5; // ���� ������� (���� ����� �������������� � �������)

    private Vector2 direction = Vector2.right; // ����������� ��������

    void Update()
    {
        // �������� �������
        transform.Translate(direction * speed * Time.deltaTime);
        FaceDirection();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �������� �� ������������ � ������ ���������
        if (collision.gameObject.CompareTag("Wall"))
        {
            ChangeDirection();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; // ��������� �������� �� �������� �����
        if (health <= 0)
        {
            Die(); // �������� ����� ������, ���� �������� ������ ��� ����� ����
        }
    }

    void Die()
    {
        // ������ ������ �������
        Destroy(gameObject); // ����������� �������
    }

    void ChangeDirection()
    {
        // �������� �����������
        direction = -direction; // ������ ����������� �� ���������������
    }

    void FaceDirection()
    {
        // ����������� ������� � ������ �������
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // ����� ������
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // ����� �����
        }
    }
}
