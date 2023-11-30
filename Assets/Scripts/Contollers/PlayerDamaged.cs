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
    {    //충돌 발생시
        if (collision.gameObject.tag == "Enemy")
            OnDamaged(collision.transform.position);

    }


    void OnDamaged(Vector2 targetPos)
    {   //충돌 이벤트 무적 효과 함수
        //레이어 변경(무적)
        gameObject.layer = 10;  //10번 레이어, PlayerDamaged

        //충돌시 스프라이트 색상 변화
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);    //Color(R,G,B,투명도)


        //충돌시 튕겨짐
        //목표물 기준 왼쪽에서 닿으면 왼쪽으로, 오른쪽에서 닿으면 오른쪽으로
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

        //애니메이션 변경
        anim.SetTrigger("Hurt");

        Invoke("OffDamaged", 2);    //2초 뒤 OffDamaged 함수 실행
    }

    void OffDamaged()
    { //충돌 이벤트 무적 해제 함수
        //레이어 변경(원래대로)
        gameObject.layer = 9;  //9번 레이어, Player
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

}
