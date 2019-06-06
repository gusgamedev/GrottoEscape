using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private FlashDamage _damageEffect;
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
        _damageEffect.SetFlashDamage();
    }
    
}
