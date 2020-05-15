using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Networking;

public class Player : Charactors
{
    private bool isDead;
    private Rigidbody2D m_rg;
    public GameObject Bullet;
    public Animator animator;
    //public GameObject Doy;
    public int bloodvolume = 100;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        m_rg = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public override void Update()
    {
        //print(this.transform.position.y);
        if (bloodvolume <= 0|| this.transform.position.y < -2.0) Dead();
        if (!isDead)
        {
            base.Update();
            GetInput();
        }
        
     /*   float Horizontalmove = Input.GetAxis("Horizontal");
        if(Horizontalmove != 0)
        {
            animator.SetFloat("running", Mathf.Abs(Facedirection));
        }*/
     /*   float Facedirection = Input.GetAxisRaw("Horizontal");
        if(Facedirection != 0)
        {
            transform.localScale = new Vector3(Facedirection, 1, 1);
         //   animator.SetFloat("running", Mathf.Abs(Facedirection));
        }*/
    }
    //碰撞函数
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            direction = Vector2.zero;
            bloodvolume -= 30;
            Debug.Log(bloodvolume);
        }
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        float Facedirection = Input.GetAxisRaw("Horizontal");
        if (Facedirection != 0)
        {
            transform.localScale = new Vector3(Facedirection, 1, 1);
            //   animator.SetFloat("running", Mathf.Abs(Facedirection));
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            animator.SetFloat("running",Mathf.Abs(Facedirection));
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            animator.SetFloat("running", Mathf.Abs(Facedirection));
        }
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("running",(float)0);
        }
        if (Input.GetKeyDown(KeyCode.Space))   PlayerJump();
        if (Input.GetMouseButtonDown(0)) GunShoot();
        //if (Input.GetKeyDown(KeyCode.E)) DavidDoy();
    }

    //跳跃函数
    private void PlayerJump()
    {
        if (m_rg.velocity.y.Equals(0))
            m_rg.velocity = new Vector2(m_rg.velocity.x, (float)2.3);
    }

    //射击函数
    private void GunShoot()
    {
        //定义鼠标点击位置
        Vector3 m_mousePos = Input.mousePosition;
        Vector3 m_playerPos = transform.position;
        m_mousePos = Camera.main.ScreenToWorldPoint(m_mousePos);
        m_mousePos.z = 0;//因为是2D，用不到z轴。使将z轴的值为0，这样鼠标的坐标就在(x,y)平面上了
        //print(m_fireAngle);
        //调整子弹发射位置
        if(m_mousePos.x > m_playerPos.x)    m_playerPos.x += (float)0.16;
        else if(m_mousePos.x < m_playerPos.x)    m_playerPos.x -= (float)0.16;
        else if(m_mousePos.y > m_playerPos.y)    m_playerPos.y += (float)0.16;
        else if(m_mousePos.y < m_playerPos.y)    m_playerPos.y -= (float)0.16;
        
        //生成子弹
        GameObject m_bullet = Instantiate(Bullet, m_playerPos, Quaternion.identity) as GameObject;
        // 速度
        m_bullet.GetComponent<Rigidbody2D>().velocity = (m_mousePos - m_playerPos).normalized * 5;
        // 角度
        //m_bullet.transform.eulerAngles = new Vector3(m_mousePos.x, m_mousePos.y, m_fireAngle);
    }
    
    //召唤替身使者
    //private void DavidDoy()
    //{
    //    //生成替身使者
    //    GameObject m_david = Instantiate(Doy, transform.position, Quaternion.identity) as GameObject;
    //    //速度
    //    m_david.GetComponent<Rigidbody2D>().velocity = (Input.mousePosition - transform.position).normalized * 5;
    //    //m_david.transform
    //}
    
    private void Dead()
    {
        //Destroy(gameObject);
        print("rua");
        playerSpeed = 0;
        isDead = true;
        Physics.gravity = new Vector3(1.0f, 1.0f, 0);
    }
    
}
