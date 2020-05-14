using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //游戏人物的位置
    private Transform player;
    //相机要移动的点
    private Vector3 cameraPos;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CamMove();
    }

    private void CamMove()
    {
        cameraPos = new Vector3(player.position.x, player.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, cameraPos, 5*Time.deltaTime);
    }
}
