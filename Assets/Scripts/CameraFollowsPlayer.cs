using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    Transform player;
    Vector3 tempPos;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;  
        transform.position = tempPos;
    }
}
