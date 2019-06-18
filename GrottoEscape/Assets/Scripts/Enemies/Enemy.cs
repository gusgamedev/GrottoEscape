using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    protected FlashDamage _damageEffect;
    protected bool _isVisible = false;
    protected Rigidbody2D _rb;

    [SerializeField] int _health = 3;
    [SerializeField] protected float _speed = 4;
    [SerializeField] protected float _jumpForce = 4;
    [SerializeField] protected GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        _damageEffect = GetComponent<FlashDamage>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage) 
    {
        if (_isVisible)
        {
            _health -= damage;
            _damageEffect.SetFlashDamage();
        }

        if (_health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    private void OnBecameVisible()
    {
        _isVisible = true;
    }

    private void OnBecameInvisible()
    {
        _isVisible = false;
    }

}
