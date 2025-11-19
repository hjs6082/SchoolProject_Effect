using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    SpriteRenderer sr;
    Animator anim;
    BoxCollider2D box;
    float dirX;
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float jumpSpeed = 5.0f;
    [SerializeField] float wallJumpX = 1500f;
    [SerializeField] float wallJumpY = 600f;
    [SerializeField] LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        Flip();

        body.linearVelocity = new Vector2(dirX * moveSpeed, body.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

        Animation();
    }

    void Jump()
    {
        if (IsGround())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpSpeed);
        }
        else if (IsRope())
        {
            body.AddForce(new Vector2(wallJumpX * dirX, wallJumpY));
        }
    }

    bool IsGround()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, 0.1f, layer);
    }

    bool IsRope()
    {
        bool left = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.left, 0.1f, layer);
        bool right = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.right, 0.1f, layer);
        return left || right;
    }

    void Flip()
    {
        if (dirX < 0)
        {
            sr.flipX = true;
        }
        else if (dirX > 0)
        {
            sr.flipX = false;
        }
    }

    void Animation()
    {
        if (dirX != 0)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
        if (body.linearVelocity.y > 0.1f)
        {
            anim.SetTrigger("jumping");
        } else if (body.linearVelocity.y < -0.1f)
        {
            anim.SetTrigger("falling");
        }
        if (IsGround())
        {
            anim.SetBool("ground", true);
        } else
        {
            anim.SetBool("ground", false);
        }
       
    }
}
