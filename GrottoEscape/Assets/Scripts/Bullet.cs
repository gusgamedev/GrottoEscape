using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
p   [SerializeField] private float _speed = 20f;
	[SerializeField] private int _damage = 1;
	[SerializeField] private Rigidbody2D _rb;

	// Use this for initialization
	void Start () {
		_rb.velocity = transform.right * _speed;
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		if (hitInfo.CompareTag("Enemy"))
        {
           /* Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
            }            
             */
            
        }

        Destroy(gameObject);
	}
}
