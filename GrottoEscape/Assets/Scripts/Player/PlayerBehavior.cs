using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerCollision coll;
    private PlayerAnimation anim;
    
    private Shot shot;
       
    private bool canMove = true;
    private bool canJump = false;
    private bool isFacingRight = true;
    public bool isJumping = false;
   // private bool isFalling = false;
    public bool isOnFloor = false;
    private int  direction = 0; // 1 = right, -1 = left, 0 = idle

    [SerializeField] private float knockBackForce = 20f;

    [Header("Jump Variables")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    
   
    // Start is called before the first frame update
    private void Awake()
    {        
        rb = GetComponent<Rigidbody2D>(); 
        coll = GetComponent<PlayerCollision>();
        anim = GetComponentInChildren<PlayerAnimation>();
        shot = GetComponent<Shot>();
        rb.velocity = Vector2.zero;
    }

    void Update()
    {
        Inputs();

        if (isJumping && isOnFloor)
            Land();

        GroundCheck();
    }

    private void FixedUpdate()
    {   
        Walk();

        if (canJump) 
            Jump();
    }

    private void Inputs()
    {
        direction = (int)Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isOnFloor)
            canJump = true;

        if (Input.GetButton("Fire1"))
            Shoot();

        if (Input.GetButtonUp("Fire1"))
            StopShooting();        
    }

    private void Shoot()
    {  
        canMove = !coll.isOnFloor;        
       

        anim.Shoot(true);

        if ((!coll.onRightWall && isFacingRight) || (!coll.onLeftWall && !isFacingRight))
        {
            if (shot.canShoot)
            {
                KnockBack();
                shot.InstantiateBullet();                
            }
        }

    }
    private void StopShooting()
    {   
        canMove = true;
        anim.Shoot(false);
    }

    private void Walk()
    {
        if (canMove)
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);

        Flip();
        anim.Walk(rb.velocity.x);
    }

    private void Jump()
    {       
        canJump = false;
        
        rb.velocity = Vector2.up * jumpForce;
        anim.Dust();
    }

    private void Land()
    {
        isJumping = false;
        anim.Dust();
    }

    private void Flip()
    {
        if ((direction > 0 && !isFacingRight) || (direction < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;        
            transform.Rotate(0,180,0);        
        }
    }

    private void GroundCheck()
    {   
        isOnFloor = coll.isOnFloor;

        if (!isOnFloor)
            isJumping = true;

        anim.Grounded(isOnFloor);
    }

    private void KnockBack()
    {

        Debug.Log("aqui");
        if (isFacingRight)
            rb.AddForce(new Vector2(-knockBackForce, 0f));
        else
            rb.AddForce(new Vector2(knockBackForce, 0f));

    }


}
