using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Здоровье игрока
    public int damage = 10; // Урон игрока

    void Update()
    {
        // Проверка на здоровье (дополнительно)
        if (health <= 0)
        {
            Die(); // Если здоровье 0 или ниже, вызвать смерть.
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; // Уменьшаем здоровье на величину урона
    }

    void Die()
    {
        // Логика смерти игрока
        Debug.Log("Player is dead!"); // Здесь можно добавить нужную логику
        Destroy(gameObject); // Уничтожение игрока (не обязательно, можно сделать иначе)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster")) // Проверка на соприкосновение с монстром
        {
            MovingMonster monster = collision.gameObject.GetComponent<MovingMonster>();
            if (monster != null)
            {
                monster.TakeDamage(damage); // Наносим урон монстру
            }
        }
    }
}
