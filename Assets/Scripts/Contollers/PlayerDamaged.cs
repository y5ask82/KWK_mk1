using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {    //�浹 �߻���
        if (collision.gameObject.tag == "Enemy")
            OnDamaged(collision.transform.position);

    }


    void OnDamaged(Vector2 targetPos)
    {   //�浹 �̺�Ʈ ���� ȿ�� �Լ�
        //���̾� ����(����)
        gameObject.layer = 10;  //10�� ���̾�, PlayerDamaged

        //�浹�� ��������Ʈ ���� ��ȭ
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);    //Color(R,G,B,����)


        //�浹�� ƨ����
        //��ǥ�� ���� ���ʿ��� ������ ��������, �����ʿ��� ������ ����������
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

        //�ִϸ��̼� ����
        anim.SetTrigger("Hurt");

        Invoke("OffDamaged", 2);    //2�� �� OffDamaged �Լ� ����
    }

    void OffDamaged()
    { //�浹 �̺�Ʈ ���� ���� �Լ�
        //���̾� ����(�������)
        gameObject.layer = 9;  //9�� ���̾�, Player
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

}
