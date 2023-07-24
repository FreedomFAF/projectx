using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform Player;
    public float distance = 100;
    public float height = 100;
    public float smoothTime = 0.1f;
    Vector3 currentVelocity;

    void Update()
    {
        Vector3 target = Player.position;
        target.z += distance;
        target += Vector3.up * height;
        transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
        transform.LookAt(Player);
    }
}


