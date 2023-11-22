using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    bool isRight = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "endpoint")
        {
            if(isRight)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = true;
            }
        }
    }
}
