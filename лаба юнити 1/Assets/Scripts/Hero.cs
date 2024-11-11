using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа
    public float jumpForce = 5f; // Сила прыжка

    private bool isGrounded; // Проверка, находится ли персонаж на земле
    private Rigidbody2D rb; // Ссылка на компонент Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Получаем ввода по оси X
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Изменяем скорость по X

        // Поворот спрайта в зависимости от направления движения
        if (moveInput > 0) 
        {
            transform.localScale = new Vector3(1, 1, 1); // Поворачиваемся вправо
        }
        else if (moveInput < 0) 
        {
            transform.localScale = new Vector3(-1, 1, 1); // Поворачиваемся влево
        }
    }

    void Jump()
    {
        // Проверяем нажатие кнопки "Jump" и если персонаж на земле
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Применяем силу прыжка
            isGrounded = false; // Персонаж теперь не на земле
        }
    }

    // Метод для проверки, находится ли персонаж на земле
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Убедитесь, что объект земли имеет тег "Ground"
        {
            isGrounded = true; // Персонаж на земле
        }
    }
}