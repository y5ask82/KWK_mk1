using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D myrigidbody;

    [SerializeField]
    private float power;
    [SerializeField]
    Transform player;
    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask islayer;
    

    public int jumpCount;

    int jumpCnt;

    bool isGround;
    private void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        jumpCnt = jumpCount;
    }

    private void Update()
    {
        isGround = Physics2D.OverlapCircle(player.position, checkRadius, islayer);
        if(isGround == true && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            myrigidbody.velocity = Vector2.up * power;
        }
        if (isGround == false && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            myrigidbody.velocity = Vector2.up * power;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            jumpCnt--;
        }
        if (isGround)
        {
            jumpCnt = jumpCount;
        }
    }
    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        myrigidbody.velocity = new Vector2(hor * 3, myrigidbody.velocity.y);
    }
}

    
