using UnityEngine;

public class MovingMonster : MonoBehaviour
{
    public float speed = 2.0f; // Скорость движения монстра
    public int health = 200; // Здоровье монстра
    public int damage = 5; // Урон монстра (если будет взаимодействие с игроком)

    private Vector2 direction = Vector2.right; // Направление движения

    void Update()
    {
        // Движение монстра
        transform.Translate(direction * speed * Time.deltaTime);
        FaceDirection();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверка на столкновение с другой сущностью
        if (collision.gameObject.CompareTag("Wall"))
        {
            ChangeDirection();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; // Уменьшаем здоровье на величину урона
        if (health <= 0)
        {
            Die(); // Вызываем метод смерти, если здоровье меньше или равно нулю
        }
    }

    void Die()
    {
        // Логика смерти монстра
        Destroy(gameObject); // Уничтожение монстра
    }

    void ChangeDirection()
    {
        // Изменяем направление
        direction = -direction; // Меняем направление на противоположное
    }

    void FaceDirection()
    {
        // Оборачиваем монстра в нужную сторону
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Лицом вправо
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Лицом влево
        }
    }
}
