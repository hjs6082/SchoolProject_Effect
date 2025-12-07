using UnityEngine;

public class GirlController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D body;
    private Animator anim;
    float waited = 0f, maxWait = 3f;
    [SerializeField] private GameObject kunaiPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        TurnToPlayer();
        ForwardAndShoot();
    }

    void TurnToPlayer()
    {
        if(player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void ForwardAndShoot()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 15f, LayerMask.GetMask("Player"));
        if(hit.collider)
        {
            waited += Time.deltaTime;
            body.linearVelocity = dir * 5f;
            if(hit.distance < 10f && waited > maxWait)
            {
                anim.SetTrigger("Shoot");
                GameObject g = Instantiate(kunaiPrefab, transform.position, Quaternion.identity);
                g.GetComponent<KunaiController>().Shoot();
                waited = 0f;
            }
        }
        else
        {
            body.linearVelocityX = 0f;
        }
        anim.SetFloat("Speed", Mathf.Abs(body.linearVelocityX));
    }
}
