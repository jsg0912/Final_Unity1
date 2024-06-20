using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    private Animator anim;
    public Gamemanage gamemanage;
    public Scrollbar scrollbar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        speed += (float)gamemanage.gameLevel / 10f;

    }

    // Update is called once per frame
    void Update()
    {
        
        scrollbar.value = transform.position.x / 100f;
        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

    }

    public void PlayAndDestroy()
    {
        anim.Play("Attack");
        StartCoroutine(AfterAnimation());
    }

    private IEnumerator AfterAnimation()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
        gamemanage.GameOver();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayAndDestroy();
        }
    }
}
