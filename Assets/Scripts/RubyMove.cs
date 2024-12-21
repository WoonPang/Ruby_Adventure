using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyMove : MonoBehaviour
{
    public float Speed;
    public GameManager manager;

    public AudioClip audioWalk;
    public AudioClip audioDamage;
    public AudioClip audioDie;
    public AudioClip audioCollect;
    public AudioClip audioFinished;

    [SerializeField]
    float normalSpped, runSpeed;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;
    AudioSource audioSource;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckMove();
        CheckObject();

        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = false;
        }
    }

    void CheckMove()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        isHorizonMove = false;

        if (h != 0)
        {
            v = 0;
            isHorizonMove = true;
        }
        else if (v != 0)
        {
            h = 0;
            isHorizonMove = false;
        }

        anim.SetInteger("hAxisRaw", (int)h);
        anim.SetInteger("vAxisRaw", (int)v);
    }

    void Move()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        PlaySound("WALK");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rigid.velocity = moveVec * Speed * 1.5f;
        }
        else
        {
            rigid.velocity = moveVec * Speed;
        }
    }

    void CheckObject()
    {
        if (v == 1)
            dirVec = Vector3.up;
        else if (v == -1)
            dirVec = Vector3.down;
        else if (h == -1)
            dirVec = Vector3.left;
        else if (h == 1)
            dirVec = Vector3.right;

        if (Input.GetButtonDown("Jump") && scanObject != null)
            manager.Action(scanObject);
    }

    void Scan()
    {
        Debug.DrawRay(rigid.position, dirVec * 1f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
            scanObject = rayHit.collider.gameObject;
        else
            scanObject = null;
    }

    void FixedUpdate()
    {
        Move();
        Scan();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
            OnDamaged();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            manager.collectPoint += 1;
            PlaySound("COLLECT");

            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Finish")
        {
            manager.GameClear();
            PlaySound("FINSHED");
        }
    }

    void OnDamaged()
    {
        manager.HPDown();
        PlaySound("DAMAGED");

        gameObject.layer = 11;

        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        anim.SetTrigger("doDamaged");

        Invoke("OffDamaged", 3);
    }

    void OffDamaged()
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void OnDie()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        PlaySound("DIE");
    }

    void PlaySound(string action)
    {
        switch (action)
        {
            case "WALK":
                audioSource.clip = audioWalk;
                break;
            case "DAMAGED":
                audioSource.clip = audioDamage;
                break;
            case "DIE":
                audioSource.clip = audioDie;
                break;
            case "COLLECT":
                audioSource.clip = audioCollect;
                break;
            case "FINISHED":
                audioSource.clip = audioFinished;
                break;
        }
    }
}
