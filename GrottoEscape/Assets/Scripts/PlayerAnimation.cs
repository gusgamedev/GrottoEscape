using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator _anim;

    [Header("Particles Animations")]
    [SerializeField] private ParticleSystem _jumpParticles;
    [SerializeField] private ParticleSystem _shotParticles;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Walk(float speed)
    {
        _anim.SetFloat("horizontalSpeed", Mathf.Abs(speed));       
    }

    public void Jump(bool isOnFloor)
    {
        _anim.SetBool("isOnFloor", isOnFloor);
        _jumpParticles.Play();
    }

    public void Land(bool isOnFloor)
    {
        _anim.SetBool("isOnFloor", isOnFloor);
        _jumpParticles.Play();
    }

    public void Shot(bool isShooting, bool showParticles)
    {
        _anim.SetBool("shooting", isShooting);

        if (showParticles)
            _shotParticles.Play();
    }





   
}
