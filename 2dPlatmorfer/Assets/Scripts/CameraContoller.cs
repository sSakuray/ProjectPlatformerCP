using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;

    private void Awake()
    {
        if (!player) 
        {
            player = FindAnyObjectByType<Character>().transform;
        }
    }

    private void Update()
    {
        pos = player.position;
        pos.z = -1f;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 5f);
    }
}
