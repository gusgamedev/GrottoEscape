using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    private FlashDamage _damageEffect;
    private bool _isVisible = false;

    [SerializeField] int _health = 3;
    // Start is called before the first frame update
    void Start()
    {
        _damageEffect = GetComponent<FlashDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage() 
    {
        if (_isVisible)
        {
            _health--;
            _damageEffect.SetFlashDamage();
        }

        if (_health <= 0)
        {
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
