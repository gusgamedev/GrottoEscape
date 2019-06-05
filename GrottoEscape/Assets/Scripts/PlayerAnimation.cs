using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator _anim;
    
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
    }

    public void Shot(bool isShooting)
    {
        _anim.SetBool("shooting", isShooting);
    }





   
}
