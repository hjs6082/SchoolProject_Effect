using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCamera : MonoBehaviour
{
    [SerializeField] private Transform map;
    float prevX;

    private void Start()
    {
        prevX = transform.position.x;
    }

    private void Update()
    {
        if(transform.position.x != prevX)
        {
            float delta = prevX - transform.position.x;
            foreach (ParallaxLayer layer in map.GetComponentsInChildren<ParallaxLayer>())
            {
                layer.Move(delta);
            }
            prevX = transform.position.x;
        }
    }
}
