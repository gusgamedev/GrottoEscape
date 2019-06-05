using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerCollision _collision;
    private PlayerAnimation _animation;
    private bool _canMove = true;
    private bool _isOnFloor = false;

    [Header("Stats")]
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _jumpForce = 12f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); 
        _collision = GetComponent<PlayerCollision>();
        _animation = GetComponentInChildren<PlayerAnimation>();
        

    }

    // Update is called once per frame
    void Update()
    {

        float direction = Input.GetAxisRaw("Horizontal");
        Walk(direction);
            
        if (Input.GetButtonDown("Jump"))
            Jump(_jumpForce);

        _animation.Jump(_collision.isOnFloor);

        if (Input.GetButton("Fire1"))
        {   
            //Shot();
            _animation.Shot(true);
        } else if (Input.GetButtonUp("Fire1"))
            _animation.Shot(false);



    }

    private void Walk(float direction) {

        if (_canMove)
            _rb.velocity = new Vector2(direction * _speed, _rb.velocity.y);
        else
            _rb.velocity = new Vector2(0, _rb.velocity.y);

        Flip(direction);
        _animation.Walk(_rb.velocity.x);
    }

    private void Jump(float jumpForce) {

        if ( _collision.isOnFloor)
            _rb.velocity = Vector2.up * jumpForce;
    }

    private void Flip(float direction)
    {
        if ((direction > 0 && transform.localScale.x < 0) || (direction < 0 && transform.localScale.x > 0))
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);        
    }

    private void Shot()
    {        
        
    }

   

}
