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
    [SerializeField] private float forceX = 10f;
    [SerializeField] private float limitSpeed = 100f;
    [SerializeField] private LayerMask layer;

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
            VelocityX();
        }
        else
        {
            body.linearVelocityX = body.linearVelocityX + AcclerationX();
        }

        if (input.jump == true) body.linearVelocityY = jumpPower;

        SpeedLimit();
    }

    void Flip()
    {
        if (direction < 0f) render.flipX = true;
        else if (direction > 0f) render.flipX = false;
    }

    void VelocityX()
    {
        if(input.move.x != 0 && input.dash)
        {
            Vector2 force = new Vector2(forceX * direction, 0f);
            body.AddForce(force, ForceMode2D.Impulse);
        }
        else
        {
            body.linearVelocityX = direction * speed;
        }
    }

    float AcclerationX()
    {
        return direction * accleration * Time.deltaTime;
    }

    void SpeedLimit()
    {
        if (Mathf.Abs(body.linearVelocityX) > limitSpeed)
            body.linearVelocityX = Mathf.Sign(body.linearVelocityX) * limitSpeed;
    }

    bool IsGround()
    {
        Vector2 size = this.gameObject.GetComponent<BoxCollider2D>().size;
        if (Physics2D.BoxCast(transform.position, size, 0f, -transform.up, 0.1f, layer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
