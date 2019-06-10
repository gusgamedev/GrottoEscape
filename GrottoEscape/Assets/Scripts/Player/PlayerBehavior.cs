using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerCollision _collision;
    private PlayerAnimation _animation;

    private Shot _shot;

    private bool _canMove = true;
    private bool _facingRight = true;
    private bool _isOnFloor = true;
 
    [Header("Jump Variables")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 10f;
   
    // Start is called before the first frame update
    private void Awake() {
        
        _rb = GetComponent<Rigidbody2D>(); 
        _collision = GetComponent<PlayerCollision>();
        _animation = GetComponentInChildren<PlayerAnimation>();
        _shot = GetComponent<Shot>();        

        _isOnFloor = _collision.isOnFloor;
    }

    private void FixedUpdate()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        Walk(direction);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            Jump(_jumpForce);

        _animation.Groudend(_isOnFloor);

        if (Input.GetButton("Fire1") )
        {      
            _animation.Shot(true, _shot._canShoot);
            _canMove = !_collision.isOnFloor;
            _shot.Shoot(_facingRight);
                
        } 
        else if (Input.GetButtonUp("Fire1")) 
        {
            _animation.Shot(false, false);
            _canMove = true;
        }

        if (_collision.isOnFloor && _rb.velocity.x < 0f)
        {
            GroundTouch();
        }
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

        if (_collision.isOnFloor)
        {
            _animation.Jump();
            _rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void Flip(float direction)
    {
        if ((direction > 0 && !_facingRight) || (direction < 0 && _facingRight))
        {
            _facingRight = !_facingRight;        
            transform.Rotate(0,180,0);        
        }
    }

    private void GroundTouch()
    {   
        _animation.Land(true);
    }

   

}
