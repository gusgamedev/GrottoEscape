using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
	[SerializeField] private int _damage = 1;
	[SerializeField] private GameObject _fireParticle;
	
    private Rigidbody2D _rb;

	// Use this for initialization
	void Start () {
        
		_rb = GetComponent<Rigidbody2D>();        

        _rb.velocity = transform.right * _speed;
        Destroy(gameObject, 2f);
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
        if (hitInfo.CompareTag("Enemy"))
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
            }            
        }
        
        Instantiate(_fireParticle, transform.position, transform.rotation);        
        Destroy(gameObject);
	}
}
