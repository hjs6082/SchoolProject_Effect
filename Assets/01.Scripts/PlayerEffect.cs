using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private float scaleSpeed = 2f;
    [SerializeField] private float blinkSpeed = 3f;
    [SerializeField] private float glowSpeed = 4f;
    [SerializeField] private float glowIntensity = 4f;
    [SerializeField] [Range(0f,1f)] private float visibleRatio = 1f;
    [SerializeField] private GameObject vfx01Prefab;
    private SpriteRenderer sr;
    int effectType = -1;

    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (effectType == 0) Scaling();
        else if (effectType == 1) Blink();
        if (effectType == 2) Glow();

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
}
