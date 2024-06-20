using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public Gamemanage gamemanage;
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;

    }

    // Update is called once per frame
    void Update()
    {

        
        Vector3 movePosition = Vector3.left;
        transform.position += movePosition * moveSpeed * Time.deltaTime;
    }
}
