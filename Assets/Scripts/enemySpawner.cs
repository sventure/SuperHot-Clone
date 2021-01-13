using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemies", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemies()
    {
        float randX = Random.Range(-45f,45f);
        float randZ = Random.Range(-45f, 45f);
        if (randX<=20f && randX>=0f)
        {
            randX = 20f;
        }
        else if(randX <= 0f && randX >= -20f)
        {
            randX = -20;
        }

        if (randZ <= 20f && randZ >= 0f)
        {
            randZ = 20f;
        }
        else if (randZ <= 0f && randZ >= -20f)
        {
            randZ = -20;
        }
        Vector3 randLocation = new Vector3(randX, 1f, randZ);
        Instantiate(enemy,randLocation, Quaternion.Euler(0f,Random.Range(0f,360f),0f));
    }
}
