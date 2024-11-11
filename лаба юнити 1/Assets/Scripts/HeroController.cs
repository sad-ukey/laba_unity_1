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
    private Animator animator; // ссылка на компонент Animator
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Получаем компонент Animator
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        // Поворот персонажа в зависимости от ввода
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput < 0)
        {

            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        // Обновляем параметр Speed в Animator
        animator.SetFloat("Speed", Mathf.Abs(moveInput)); // Устанавливаем значение Speed для Animator

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}