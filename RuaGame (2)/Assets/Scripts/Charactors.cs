using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactors : MonoBehaviour
{
    protected Vector2 direction;
    [SerializeField]
    protected float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(direction * playerSpeed * Time.deltaTime);
    }
}
