using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public float jumpPower = 5f;
    public float cooldownTime = 2f;
    private float nextJumpTime;
    private float random;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        nextJumpTime = Time.time + cooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(-1.0f, 1.0f);
        if (Time.time >= nextJumpTime && !anim.GetBool("isJump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
            nextJumpTime = Time.time + cooldownTime + random;
        }
        if (rigid.velocity.y < 0)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                anim.SetBool("isJump", false);
            }
        }
    }
}
