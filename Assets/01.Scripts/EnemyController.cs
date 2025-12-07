using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D body;
    SpriteRenderer render;
    [SerializeField] private float force = 3f;
    float maxLife = 200f;
    public float life;

    private void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        render = this.gameObject.GetComponent<SpriteRenderer>();
        InvokeRepeating("Jump", 0f, 3f);
        life = maxLife;
    }

    private void Update()
    {
        Blocking();
        if (life < 0f)
            Destroy(gameObject);
        Color c = render.color;
        c.a = life / maxLife;
        render.color = c; 
    }

    void Jump()
    {
        body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    void Blocking()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 blockDir = player.transform.position - transform.position;
        if (Vector2.Distance(player.transform.position, transform.position) < 1.5f)
        {
            body.AddForce(blockDir * 0.4f, ForceMode2D.Impulse);
        }
    }
}
