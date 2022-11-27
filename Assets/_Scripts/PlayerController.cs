using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;   // Create speed variable 
    public float jumpForce; // Create jump variable 
    public Rigidbody2D _rb; // Create variable RB 2D
    private bool isGrounded; // Create variable which checks if Player on ground
    public Transform groundCheckPoint;
    public LayerMask layerMask;
    private bool doubleJump; // Double Jump check

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), _rb.velocity.y);
        
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, layerMask);

        if(isGrounded){
            doubleJump = true;
        }
        
        if (Input.GetButtonDown("Jump")) {
            
            if (isGrounded){

            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            
            }
            
            else{

                if(doubleJump){
                
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);

                doubleJump = false;

                }
            }
        }   
    }
}
