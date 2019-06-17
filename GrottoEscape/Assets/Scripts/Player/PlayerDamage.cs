using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private int  health;
    private bool isInvencible = false;

    private FlashDamage damageEffect;
    [SerializeField] private GameObject cameraShake;

    private void Start()
    {
        damageEffect = GetComponentInChildren<FlashDamage>();
        health = GameManager.instance.PlayerHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!isInvencible && health > 0)
        {
            SetInvecible(true);
            health -= damage;
            damageEffect.SetFlashDamage();
            GameManager.instance.PlayerHealth = health;
            Instantiate(cameraShake, transform.position, Quaternion.identity);
            Invoke("SetInvecible", 1.5f);
        }

        if (health <= 0)
        {
            //Destroy(gameObject);
            //Die
        }
    }

    void SetInvecible(bool invencible)
    {
        isInvencible = invencible;
    }
    void SetInvecible()
    {
        isInvencible = false;
    }
}
