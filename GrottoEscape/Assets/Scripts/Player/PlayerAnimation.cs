using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    [Header("Particles Animations")]
    [SerializeField] private ParticleSystem dustParticles;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();        
    }

    public void Walk(float speed)
    {
        anim.SetFloat("horizontalSpeed", Mathf.Abs(speed));  

    }
    public void Dust()
    {
        dustParticles.Play();
    }

    public void Shoot(bool isShooting)
    {
        anim.SetBool("isShooting", isShooting);
            
    }

    public void Grounded(bool isGrounded)
    {
        anim.SetBool("isOnFloor", isGrounded);
    }




}
