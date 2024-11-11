using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float moveSpeed = 5f; // скорость движения персонажа
    public float jumpForce = 300f; // сила прыжка
    private Rigidbody2D rb; // ссылка на компонент Rigidbody2D
    private bool isGrounded; // флаг, указывающий, что персонаж на земле
    private float moveInput; // переменная для хранения ввода движения

    void Start()
    {
        // Получаем компонент Rigidbody2D на старте
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Получаем горизонтальный ввод (влево/вправо)
        moveInput = Input.GetAxis("Horizontal"); 

        // Поворот персонажа в зависимости от ввода
        if (moveInput > 0)
        {
            // Вправо
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); 
        }
        else if (moveInput < 0)
        {
            // Влево
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); 
        }

        // Проверка для прыжка
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Добавляем силу для прыжка
            rb.AddForce(new Vector2(0, jumpForce)); 
        }
    }

    void FixedUpdate()
    {
        // Движение персонажа
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, входит ли персонаж в контакт с объектом земли
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Персонаж на земле
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Как только персонаж покидает землю
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Персонаж в воздухе
        }
    }
}