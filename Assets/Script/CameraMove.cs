using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour
{
    public GameObject A;  //A��� GameObject���� ����
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