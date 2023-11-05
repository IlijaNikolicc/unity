using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float distance = 16.0f;

    void Update()
    {
        transform.position = player.transform.position + Vector3.up * distance;
    }
}
