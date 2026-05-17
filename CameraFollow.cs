using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private Vector3 TempPos;
    [SerializeField]
    private float minX ,maxX;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;  
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(!player)
            return;

        TempPos = transform.position;
        TempPos.x = player.position.x;

        transform.position = TempPos;



    }
}
