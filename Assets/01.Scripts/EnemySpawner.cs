using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, 3f);
    }

    void Spawn()
    {
        Vector2 pos;
        pos.x = Random.Range(-70f, 100f);
        pos.y = 10f;
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.down, 25f, groundLayer);
        if (hit.collider && hit.transform.childCount == 0)
        {
            Vector2 spawnPos = hit.point + Vector2.up * 0.5f;
            Instantiate(enemyPrefab, pos, Quaternion.identity, hit.transform);
        }
    }
}
