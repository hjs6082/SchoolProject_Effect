using Unity.VisualScripting;
using UnityEngine;

public class Animation2D : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Input2D input; 

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        input = this.gameObject.GetComponent<Input2D>();
    }

    private void Update()
    {
        Animating();
    }

    void Animating()
    {
        animator.SetFloat("Speed", rigidbody2D.linearVelocityX);
        animator.SetBool("Jump", input.jump);
        animator.SetBool("Attack", input.attack);
        animator.SetBool("Slide", input.slide);
    }
}
