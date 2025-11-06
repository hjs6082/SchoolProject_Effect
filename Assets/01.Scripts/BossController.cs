using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 8f;
    [SerializeField] private GameObject deadVFX;
    Rigidbody2D body;
    Animator anim;
    SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        InvokeRepeating("Dash", 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        anim.SetFloat("Speed", body.linearVelocityX);
        if(sr.color.g <= 0f)
        {
            anim.SetTrigger("Dead");
            body.Sleep();
        }
    }

    void Dash()
    {
        speed = speed * 1.05f;
        Vector2 direction = new Vector2(transform.localScale.x, 0f);
        body.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    public void DeadVFX()
    {
        GameObject g = Instantiate(deadVFX, transform.position, Quaternion.identity);
        Destroy(g, 0.5f);
        Destroy(gameObject,0.2f);
    }
}
