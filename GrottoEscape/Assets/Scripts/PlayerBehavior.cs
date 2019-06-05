using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerCollision _collision;
    private PlayerAnimation _animation;         
    private bool _canMove = true;
    private bool _isOnFloor = false;
    private bool _facingRight = true;

    [Header("Stats")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 10f;

     [Header("Action")]
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireRate = 0.2f;
    private bool _canShoot = true;

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
            _canMove = false;
            _animation.Shot(true);
            Shoot();
        } 
        else if (Input.GetButtonUp("Fire1")) 
        {
            _animation.Shot(false);
            _canMove = true;
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

        if ( _collision.isOnFloor)
            _rb.velocity = Vector2.up * jumpForce;
    }

    private void Flip(float direction)
    {
        if ((direction > 0 && !_facingRight) || (direction < 0 && _facingRight)){
            _facingRight = !_facingRight;        
            transform.Rotate(0, 180, 0);        
        }
    }

    private void Shoot()
    {        
        if (_bullet != null && _firePoint != null) {
            _canShoot = false;
            Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
            Invoke("NextShot", _fireRate);
        }
    }

    void NextShot() {
        _canShoot = true;
    }

   

}
