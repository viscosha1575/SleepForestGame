﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceball : MonoBehaviour
{
    
    // public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(direction * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destr"))
        {
            Destroy(gameObject);
        }
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            
            }
    }
}
