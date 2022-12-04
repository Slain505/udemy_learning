using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;   // Create speed variable 
    public float jumpForce; // Create jump variable 
    public Rigidbody2D _rb; // Create variable RB 2D
    private bool isGrounded; // Create variable which checks if Player on ground
    private bool isFalling;  // Falling check
    public Transform groundCheckPoint;
    public LayerMask layerMask;
    private bool doubleJump; // Double Jump check
    private Animator anim; // Animator
    private SpriteRenderer spriteRR;
    [SerializeField] private float knockBackCount, knockBackDuration, knockBackForce;
    [SerializeField] public PlayerController pc;

    private void Awake() 
    {
        pc = this;
    }

    // Start is called before the first frame update
    void Start()
        {
        anim = GetComponent<Animator>();
        spriteRR = GetComponent<SpriteRenderer>();
        }
    
  
        // Update is called once per frame
        void Update()
        {
            if(knockBackCount <= 0)
            {
                _rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), _rb.velocity.y);

                isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, layerMask);
        
                // public bool isFalling()    // Falling check
                // {
                // if(_rb.velocity.y < 0 && !isGrounded){
                //         return true;
                //     }
                // }     
                isFalling = false;

                if(_rb.velocity.y < 0 && !isGrounded)
                {
                    isFalling = true;
                }
        
                // Player rotation
                if(_rb.velocity.x < 0)
                {
                    spriteRR.flipX = true;
                } 
                else if(_rb.velocity.x > 0)
                {
                   spriteRR.flipX = false;
                }

                if(isGrounded)
                {
                    doubleJump = true;
                }
        
                if (Input.GetButtonDown("Jump")) 
                {
            
                    if (isGrounded)
                    {

                    _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            
                    }
            
                else
                {

                    if(doubleJump)
                    {
                        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);

                        doubleJump = false;

                    }
                }
            }
        }
            else
            {
                knockBackCount -= Time.deltaTime;
            }
            anim.SetBool("isGrounded", isGrounded);
            anim.SetFloat("moveSpeed", Mathf.Abs(_rb.velocity.x));
            anim.SetBool("isFalling", isFalling);
           // anim.SetBool("doubleJump", doubleJump);      
    }
    
    public void KnockBack() 
    {
      knockBackCount = knockBackDuration;  
    }
}




