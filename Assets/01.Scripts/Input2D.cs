using UnityEngine;

public class Input2D : MonoBehaviour
{
    [HideInInspector]
    public Vector2 move;
    [HideInInspector]
    public bool jump = false;
    [HideInInspector]
    public bool attack = false;
    [HideInInspector]
    public bool slide = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Attack();
        Slide();
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        move = new Vector2(x, y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            attack = true;
        }
        else
        {
            attack = false;
        }
    }

    void Slide()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("´­·¶½À´Ï´Ù.");
            slide = true;
        }
        else
        {
            slide = false;
        }
    }
}
