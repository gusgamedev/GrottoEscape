using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] float collisionRadius = 0.5f;
    [SerializeField] LayerMask playerLayer;
    
    // Update is called once per frame
    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle((Vector2)transform.position, collisionRadius, playerLayer);

        if (hit != null)
        {
            if (hit.CompareTag("Player"))
            {
                hit.GetComponent<PlayerDamage>().TakeDamage(1);
            }
        }

    }

}
