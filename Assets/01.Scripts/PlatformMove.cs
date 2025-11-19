using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float length = 10f;
    enum MovingDirection { LEFTRIGHT, UPDOWN, BOTH }
    [SerializeField] private MovingDirection moveDir = MovingDirection.LEFTRIGHT;

    Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float diff = Mathf.PingPong(Time.time * speed, length);
        if(moveDir == MovingDirection.LEFTRIGHT)
            transform.position = new Vector3(diff + startPos.x, transform.position.y, transform.position.z);
        if (moveDir == MovingDirection.UPDOWN)
            transform.position = new Vector3(transform.position.x, diff + startPos.y, transform.position.z);
        if (moveDir == MovingDirection.BOTH)
            transform.position = new Vector3(diff + startPos.x, diff + startPos.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
