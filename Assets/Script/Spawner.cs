using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject EnemyType;
    public float x_random;

    // Start is called before the first frame update
    void Start()
    {
        float x = this.gameObject.transform.position.x;
        x_random = Random.Range(-10.0f, 10.0f);
        SpawnEnemy(EnemyType, x + x_random);

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void SpawnEnemy(GameObject enemy, float randomValue)
    {
        Instantiate(enemy, new Vector3(randomValue, 1.0f, 20.0f), Quaternion.identity);
    }
}
