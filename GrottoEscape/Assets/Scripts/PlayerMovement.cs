using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    PlayerCollision _collision;
    bool _canMove = true;

    [Header("Stats")]
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _jumpForce = 12f;

    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); 
        _collision = GetComponent<PlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Walk(horizontal);

        if (Input.GetButtonDown("Jump"))
            Jump(_jumpForce);
    }

    private void Walk(float direction) {
        _rb.velocity = new Vector2(direction * _speed, _rb.velocity.y);
    }

    private void Jump(float jumpForce) {

        if ( _collision.isOnFloor)
            _rb.velocity = Vector2.up * jumpForce;
    }
}
