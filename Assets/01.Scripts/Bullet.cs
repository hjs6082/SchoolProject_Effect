using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void Update()
    {
        Vector2 plusVector = new Vector2(-1f, 0f);
        transform.localPosition = new Vector2(transform.position.x + 1f * speed * Time.deltaTime, transform.localPosition.y);
    }

}
