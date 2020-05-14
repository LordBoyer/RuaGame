using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Charactors
{
    // Start is called before the first frame update
    private Rigidbody2D emy;
    private int bloodvolume = 200;
    private float collisionRadius = 1f;
    private LayerMask playermask;
    private float time = 0;
    public Transform newenemy;
    private int enemycount = 1;
    public GameObject Bullet;
    void Start()
    {
      emy  = transform.GetComponent<Rigidbody2D>();
      playermask = 1 << 8;
    }
    // Update is called once per frame
    public override void  Update()
    {
        base.Update();
        Collider2D playercollsion = isPlayerView();
        time += Time.deltaTime;
        if (time > 1)
            changemovestate();
        if (bloodvolume == 0)
        {
            Instantiate(newenemy, new Vector2(Random.Range(-4, 4), Random.Range(-2f, 2.5f)), Quaternion.identity);
            enemycount++;
            Destroy(gameObject);
        }
            
        emymove(playercollsion);
        
        if (transform.position.y < -2.5)
        {
            Instantiate(newenemy, new Vector2(Random.Range(-4, 4), Random.Range(-2f, 2.5f)), Quaternion.identity);
            enemycount++;
            Destroy(gameObject);
        }

    }
    Collider2D isPlayerView()//判断玩家是否进入了视野
    {
        //Debug.Log("true");
        return Physics2D.OverlapCircle(transform.position,collisionRadius,playermask);
    }

    void changemovestate()//静止状态时敌人左右移动
    {
        int value = Random.Range(0, 2);
        if (value == 0)
            direction = Vector2.left;
        else if (value == 1)
            direction = Vector2.right;
        else
            direction = Vector2.zero;
        time = 0;
    }
    void emymove(Collider2D playercollsion)
    {
        GunShoot();
        if (playercollsion != null&&bloodvolume>=20)
        {
            if (playercollsion.transform.position.x < transform.position.x)
                direction = Vector2.left;
            else
                direction = Vector2.right;
        }
        if(playercollsion != null && bloodvolume < 20)
        {
            if (playercollsion.transform.position.x < transform.position.x)
                direction = Vector2.right;
            else
                direction = Vector2.left;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            direction = Vector2.zero;
            bloodvolume -= 20;
            //Debug.Log(bloodvolume);
        }
        if(collision.gameObject.tag == "ammo")
        {
            direction = Vector2.zero;
            bloodvolume -= 10;
        }
    }

    private void GunShoot()
    {
        //定义鼠标点击位置
        Collider2D playercollsion = isPlayerView();
        Vector3 m_playerPos = playercollsion.transform.position;
        Vector3 m_enemyPos = transform.position;
        //调整子弹发射位置
        if (m_playerPos.x > m_enemyPos.x) m_enemyPos.x += (float)0.16;
        else if (m_playerPos.x < m_enemyPos.x) m_enemyPos.x -= (float)0.16;
        else if (m_playerPos.y > m_enemyPos.y) m_enemyPos.y += (float)0.16;
        else if (m_playerPos.y < m_enemyPos.y) m_enemyPos.y -= (float)0.16;

        //生成子弹
        GameObject m_bullet = Instantiate(Bullet, m_enemyPos, Quaternion.identity) as GameObject;
        // 速度
        m_bullet.GetComponent<Rigidbody2D>().velocity = (m_playerPos - m_enemyPos).normalized * 5;
        // 角度
        //m_bullet.transform.eulerAngles = new Vector3(m_mousePos.x, m_mousePos.y, m_fireAngle);
    }
}
