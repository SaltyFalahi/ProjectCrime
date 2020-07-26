using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform player;

    [Range(0.01f, 1.0f)]
    public float smoothMultiplier;

    Vector3 camOffset;

    void Start()
    {
        camOffset = transform.position - player.position;
    }

    void Update()
    {
        Vector3 newPos = player.position + camOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothMultiplier);
    }
}
