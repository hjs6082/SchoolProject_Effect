using UnityEngine;

public class GetShieldItemController : MonoBehaviour
{
    [SerializeField] private GameObject shieldPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject g = Instantiate(shieldPrefab, collision.gameObject.transform);
            Destroy(g, 60f);
        }
    }
}
