using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float speed = 0;

    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x = newPos.x - delta * speed;

        transform.localPosition = newPos;
    }

}
