using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer render;
    Animator anim;
    public float jumpPower;
    public float moveSpeed = 3f;
    public float downSpeed = 0.2f;

    public Scrollbar scrollbar;

    SpriteRenderer spriteRenderer;
    public Gamemanage gamemanage;

    public bool isGameOver = false;

    private Vector3 moveDirection;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        scrollbar.value = transform.position.x / 100f;

        if (isGameOver)
        {
            return;
        }

        moveDirection = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveDirection = Vector3.left;
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveDirection = Vector3.right;
            spriteRenderer.flipX = false;
        }
        moveSpeed = (float)gamemanage.hp / 10f + (float)gamemanage.gameLevel / 10f;
        if (moveSpeed <= 3f) moveSpeed = 3f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;



        Vector3 raycastOrigin = transform.position + Vector3.down * 0.5f;

        Debug.DrawRay(raycastOrigin, Vector3.down, new Color(0, 1, 0));


        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
        }

        
        
        if(transform.position.y <=-1.5)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(raycastOrigin, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                anim.SetBool("isJump", false);
            }
        }
        


        float h = Input.GetAxisRaw("Horizontal");
        if(h > 0)
        {
            anim.SetBool("isWalk", true);
        }
        else if (h< 0)
        {
            anim.SetBool("isWalk", true);
        }
        else anim.SetBool("isWalk", false);


       }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gamemanage.OnDamage();
            int dirc = transform.position.x - collision.transform.position.x > 0 ? 1 : -1;
            rigid.AddForce(new Vector2(dirc, 1)*7, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            isGameOver = true;
        }
        if (collision.gameObject.tag == "Final")
        {
            isGameOver = true;
            gamemanage.GameClear();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            gamemanage.OnDamage();
            int dirc = transform.position.x - collision.transform.position.x > 0 ? 1 : -1;
            rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);
        }

    }



}
