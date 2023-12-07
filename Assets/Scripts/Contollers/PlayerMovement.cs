using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D myrigidbody;
    Rigidbody2D rigid;

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

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody2D>();
        jumpCnt = jumpCount;
    }

    private float curTime;
    public float coolTime = 0.5f;
    public Transform pos;
    public Vector2 boxSize;

    void Awake()
    {
        
    }
    private void Update()
    {
        isGround = Physics2D.OverlapCircle(player.position, checkRadius, islayer);
        if(isGround == true && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            animator.SetTrigger("Jump");
            myrigidbody.velocity = Vector2.up * power;
        }
        if (isGround == false && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            myrigidbody.velocity = Vector2.up * power;
        }
        if (isGround && jumpCnt != jumpCount)
        {
            myrigidbody.velocity = Vector2.zero;
            animator.SetTrigger("isground");
        }
        if(Input.GetKey(KeyCode.Space))
        {
            jumpCnt--;
        }
        if (isGround)
        {
            jumpCnt = jumpCount;
        }

        
        if (Input.GetKey(KeyCode.Z))
        {
            //공격
            //'Z'버튼을 공격버튼으로.
            if (curTime <= 0)
            {

                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if(collider.tag == "Enemy")
                    {
                        collider.GetComponent<Enemy>().TakeDamage(1);
                    }
                }

                animator.SetTrigger("Attack");
                curTime = coolTime;
            }
        }
        else
        {
            
            curTime -= Time.deltaTime;
        
        }
    }

    private void OnDrawGizos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        myrigidbody.velocity = new Vector2(hor * 3, myrigidbody.velocity.y);

        if (hor > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            animator.SetBool("Walk", true);
            animator.SetBool("runNIdle", true);
        }

        else if (hor < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            animator.SetBool("Walk", true);
            animator.SetBool("runNIdle", true);
        }

        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("runNIdle", false);
        }
    }
}

    
