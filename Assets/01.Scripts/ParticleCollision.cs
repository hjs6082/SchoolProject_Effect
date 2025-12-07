using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Boss") || other.CompareTag("BossGirl"))
        {
            SpriteRenderer sr = other.GetComponent<SpriteRenderer>();
            float r = sr.color.r;
            float g = sr.color.g - 0.001f;
            float b = sr.color.b - 0.001f;
            sr.color = new Color(r, g, b);
        }
        else if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().life -= 1f;
        }
    }
}
