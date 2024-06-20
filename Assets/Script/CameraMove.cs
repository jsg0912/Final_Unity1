using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour
{
    public GameObject A;  //A라는 GameObject변수 선언
    Transform AT;
    void Start()
    {
        AT = A.transform;
    }
    void LateUpdate()
    {
        transform.position = new Vector3(AT.position.x, 1.1f, transform.position.z);
    }
}