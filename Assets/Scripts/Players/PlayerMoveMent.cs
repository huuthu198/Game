using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    PlayerController controls;
    float direction = 0;
    public float speed = 200;
    public bool isFacing = true;

    public Animator animator;
    public Rigidbody2D playerRB;

    int doubleJump = 0; 
    public float jumpForce = 6;
    bool isGroundCheck;
    public Transform GroundCheck;
    public LayerMask groundLayer;

    private void Awake()
    {
        controls = new PlayerController();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
        controls.Land.Jump.performed += ctx => Jump();
        
    }


  
    // Update is called once per frame
    void FixedUpdate()
    {
        isGroundCheck = Physics2D.OverlapCircle(GroundCheck.position, 0.1f,groundLayer);
        animator.SetBool("isGroundCheck",isGroundCheck);
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));
        if(isFacing && direction <0 || !isFacing && direction > 0)


        Flip();

    }
    void Flip ()
    {
        isFacing =  !isFacing;
        transform.localScale =new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    void Jump()
    {
        if(isGroundCheck)
        {
            doubleJump = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            doubleJump++;
            AudioManager.instance.Play("Jump");
        }else
        {
            if(doubleJump == 1)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                doubleJump++;
                AudioManager.instance.Play("DbJump");
            }    
        }    
    }   

}
