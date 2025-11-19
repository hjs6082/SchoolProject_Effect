using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private float scaleSpeed = 2f;
    [SerializeField] private float blinkSpeed = 3f;
    [SerializeField] private float glowSpeed = 4f;
    [SerializeField] private float glowIntensity = 4f;
    [SerializeField] [Range(0f,1f)] private float visibleRatio = 1f;
    [SerializeField] private GameObject vfx01Prefab;
    [SerializeField] private GameObject vfx02Prefab;
    [SerializeField] private GameObject vfx03Prefab;
    [SerializeField] private GameObject vfx04Dash;
    [SerializeField] private GameObject vfx05Prefab;
    [SerializeField] private GameObject vfx06Prefab;

    private Input2D input;
    private SpriteRenderer sr;
    int effectType = -1;

    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        input = this.gameObject.GetComponent<Input2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (effectType == 0) Scaling();
        else if (effectType == 1) Blink();
        if (effectType == 2) Glow();

        if (input.attack == true)
            VFX02Effect();

        if (input.slide == true)
            VFX03Effect();

        VFX04Effect();

    }

    void Scaling()
    {
        float scale = (Mathf.Sin(Time.time * scaleSpeed) + 2f) / 2f;
        transform.localScale = new Vector2(scale, 1f);
    }

    void Blink()
    {
        float alpha = Mathf.PingPong(Time.time * blinkSpeed, 1f);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
    }

    void Glow()
    {
        Color c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        float emission = Mathf.PingPong(Time.time * glowSpeed, 1f);
        sr.color = c * emission * glowIntensity;
    }

    void Visible()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, visibleRatio);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Circle1"))
            effectType = 0;
        else if (collision.gameObject.CompareTag("Circle2"))
            effectType = 1;
        else if (collision.gameObject.CompareTag("Circle3"))
            effectType = 2;
        else if (collision.gameObject.CompareTag("Circle4"))
        {
            visibleRatio = 0.1f;
            Visible();
            Invoke("Visible100", 3f);
        }
        else if (collision.gameObject.CompareTag("Circle5"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Invoke("TurnOff", 5f);
            VFX01Effect(collision.gameObject.transform.position);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Rain"))
        {
            VFX05Effect();
        }
        else if (collision.gameObject.CompareTag("Snow"))
        {
            VFX06Effect();
        }
    }

    void Visible100()
    {
        visibleRatio = 1f;
        Visible();
    }

    void TurnOff()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void VFX01Effect(Vector3 pos)
    {
        GameObject g = Instantiate(vfx01Prefab, pos, Quaternion.identity);
        Destroy(g, 1f);
    }

    void VFX02Effect()
    {        
        GameObject g = Instantiate(vfx02Prefab, transform.position, Quaternion.identity);
        Transform t = g.transform.GetChild(1);
        if(sr.flipX == true)
        {
            t.Rotate(0f, 180f, 0f);
        }
        else
        {
            t.Rotate(0f, 0f, 0f);
        }
            Destroy(g, 1f);
    }

    void VFX03Effect()
    {
        float height = this.gameObject.GetComponent<BoxCollider2D>().bounds.extents.y;
        Vector3 pos = new Vector3(0f, -(height/2f), 0f);
        GameObject g = Instantiate(vfx03Prefab, transform.position + pos, Quaternion.identity, transform);
        Destroy(g, 0.7f);
    }

    void VFX04Effect()
    {
        if(input.move.x != 0 && input.dash)
        {
            float dir = 1f;
            if (sr.flipX) dir = -1f;
            vfx04Dash.SetActive(true);
            vfx04Dash.transform.localScale = new Vector3(dir, 1f, 1f);
            Time.timeScale = 0.2f;
        }
        else
        {
            vfx04Dash.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    void VFX05Effect()
    {
        GameObject g = Instantiate(vfx05Prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Destroy(g, 3f);
    }

    void VFX06Effect()
    {
        GameObject g = Instantiate(vfx06Prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Destroy(g, 15f);
    }
}
