using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    float RandX;
    Vector2 whereToSpawn;
    [SerializeField]
    private float spawnRate = 2f;
    float nextSpawn = 0.0f;
    
  
    void Update()
    {
      
          // if (Time.timeScale < nextSpawn)
            //{
                nextSpawn = Time.time * spawnRate;
                RandX = Random.Range(-6f, 400.9f);
                whereToSpawn = new Vector2(RandX, (transform.position.y)*1.5f);
                Instantiate(obj, whereToSpawn, Quaternion.identity);

     //       }
        
    }
}
