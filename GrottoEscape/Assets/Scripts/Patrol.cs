using UnityEngine;
using System.Collections;

public class Patrol : Enemy
{
    [SerializeField] private LayerMask _layerCollision;
    [SerializeField] private Transform _collisonDetector;
       
    private bool _facingRight = true;
    private bool _canMove = true;
    // Use this for initialization
    

    // Update is called once per frame
    void Update()
    {
        bool wallHit = Physics2D.Raycast(_collisonDetector.position, Vector2.right, 1f, _layerCollision);
        bool groundHit = Physics2D.Raycast(_collisonDetector.position, Vector2.down, 1f, _layerCollision);

        if (_canMove)
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);


        if (wallHit || !groundHit)
            Flip();
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _speed = -_speed;
    }

    public void Move()
    {
        _canMove = true;
    }

    public void Stop()
    {
        _canMove = false;
    }
}
