using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    public float Speed;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Invoke("Think", 2);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, nextMove * Speed);

        // 벽에 부딪히면 바로 돌게끔 만들고 싶은데 잘 모르겠습니다.
        Vector2 frontVec = new Vector2(rigid.position.x, rigid.position.y + nextMove * 0.2f);
        Debug.DrawRay(frontVec, Vector3.up, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.up, 1);
        if (rayHit.collider == null)
            Turn();
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);

        anim.SetInteger("WalkSpeed", nextMove);

        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }

    void Turn()
    {
        nextMove *= -1;

        CancelInvoke();
        Invoke("Think", 1);
    }
}
