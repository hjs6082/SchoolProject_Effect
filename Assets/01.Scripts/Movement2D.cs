using System;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    Input2D input;
    SpriteRenderer render;
    float direction;
    Rigidbody2D body;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float accleration = 10f;
    [SerializeField] private bool constantSpeed = true;
    [SerializeField] private float jumpPower = 10f;

    private void Start()
    {
        input = this.gameObject.GetComponent<Input2D>();
        render = this.gameObject.GetComponent<SpriteRenderer>();
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        direction = input.move.x;
        Flip();
        if (constantSpeed == true)
        {
            body.linearVelocityX = VelocityX();
        }
        else
        {
            body.linearVelocityX = body.linearVelocityX + AcclerationX();
        }

        if (input.jump == true) body.linearVelocityY = jumpPower;
    }

    void Flip()
    {
        if (direction < 0f) render.flipX = true;
        else if (direction > 0f) render.flipX = false;
    }

    float VelocityX()
    {
        return direction * speed;
    }

    float AcclerationX()
    {
        return direction * accleration * Time.deltaTime;
    }
}
