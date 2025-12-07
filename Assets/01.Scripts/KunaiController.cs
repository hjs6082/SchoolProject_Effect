using UnityEngine;

public class KunaiController : MonoBehaviour
{
    GameObject player;
    Rigidbody2D body;
    [SerializeField] private float minSpeed = 15f;
    [SerializeField] private float maxSpeed = 30f;
    [SerializeField] private GameObject hitPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        body = this.gameObject.GetComponent<Rigidbody2D>();
        TurnToPlayer();
    }

    void TurnToPlayer()
    {
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void Shoot()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        body.AddForce(dir * Random.Range(minSpeed, maxSpeed), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("BossGirl"))
        {
            Vector3 pos = transform.position;
            if(collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerEffect>().Glow();
                pos = collision.gameObject.transform.position;
                GameObject g = GameObject.FindGameObjectWithTag("UIManager");
                g.GetComponent<UIManager>().AddPlayerDamage();
            }
            Instantiate(hitPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
