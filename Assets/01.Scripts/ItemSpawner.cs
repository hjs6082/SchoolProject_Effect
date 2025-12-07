using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject diamondPrefab;
    [SerializeField] private Transform parent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 pos;
        for(int i = 0; i < 30; i++)
        {
            pos.x = Random.Range(-70, 100f);
            pos.y = Random.Range(-9f, 9f);
            Instantiate(diamondPrefab, pos, Quaternion.identity, parent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
