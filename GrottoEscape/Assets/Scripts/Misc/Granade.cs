﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] private float collisionRadius = 0.5f;
    [SerializeField] private int damage = 5;
    [SerializeField] private float timeToDestroy = 3f;
    [SerializeField] private LayerMask damageLayer;
    [SerializeField] private GameObject explosion;

    private Vector2 force;
   
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (transform.rotation.y == -1f)
            force = new Vector2(Random.Range(-5f, -7f), Random.Range(5f, 7f));
        else
            force = new Vector2(Random.Range(7f, 7f), Random.Range(5f, 7f));

        rb.AddForce(force, ForceMode2D.Impulse);
        
        Destroy(gameObject, 3f);
    }

    private void OnDestroy()
    {    
        Collider2D[] hits = Physics2D.OverlapCircleAll((Vector2)transform.position, collisionRadius, damageLayer);

        foreach (Collider2D hit in hits)
        {            
            if(hit.CompareTag("Enemy"))
                hit.GetComponent<Enemy>().TakeDamage(damage);
           // else if (hit.CompareTag("BreakWall"))
           //     hit.GetComponent<BreakWall>().TakeDamage(damage);
            else if (hit.CompareTag("Player"))
                hit.GetComponent<PlayerDamage>().TakeDamage(damage);
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position, collisionRadius);
        
    }
}
