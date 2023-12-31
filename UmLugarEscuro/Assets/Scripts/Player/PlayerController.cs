using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isJumping;
    private bool doubleJump;
    private bool flipX;

    private bool isWallSliding;
    private float walllSlindingSpeed = 2.5f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.3f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.5f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);


    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 42f;
    private float dashingTime = 0.15f;
    private float dashingCooldown = 1f;

    private Animator anim;
    
    public AudioSource somWalk;
    public AudioSource somDash;
    public AudioSource somJump;

    public bool isGrounded;
    
    [SerializeField] private float coyoteTime = 0.3f;
    [SerializeField] float coyoteTimeCounter;
    private bool canCoyouteTime;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        
        Jump();
        ActiveDash();
        WallSlide();
        WallJump();
        Coyote();
        JumpBuffer();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        
        Move();
    }
    private void SomWalk()
    {
        if (!somWalk.isPlaying)
        {
            somWalk.Play();    
        }
        
    }
    private void SomWalk2()
    {
        somWalk.Stop();
    }
    
    //Movimentação horizontal do jogador
    private void Move()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");

        if (!isWallJumping)
        {
            rig.velocity = new Vector2(horizontal * speed, rig.velocity.y);
            
            if (horizontal != 0 && rig.velocity.y < 1 && !isWallSliding && isGrounded)
            {
                anim.Play("Run_Luca");
            }
            else if (horizontal == 0 && rig.velocity.y ==0 && !isWallSliding)
            {
                anim.Play("Idle_Luca");
            }
            
        }
        
        
        if (flipX == true && horizontal > 0)
        {
            if (!isWallJumping)
            {
                Flip();
            }
            
        }

        if (flipX == false && horizontal < 0)
        {

            if (!isWallJumping)
            {
                Flip();
            }
            
        }
    }

    //Pulo do personagem
    private void Jump()
    {
        if (isGrounded && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (jumpBufferCounter > 0 && !isWallJumping)
        {
            if (isGrounded || doubleJump || coyoteTimeCounter > 0f)
            {
                rig.velocity = new Vector2(rig.velocity.x, jumpingPower);

                jumpBufferCounter = 0f;
                
                anim.Play("Jump_Luca");
                somJump.Play();

                doubleJump = !doubleJump;
            }
        }

        if (Input.GetButtonUp("Jump") && rig.velocity.y > 0f)
        {
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
    }

    //Aplica o CoyoteTime
    private void Coyote()
    {
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            //canCoyouteTime = true;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    //Buffering de pulo do player
    private void JumpBuffer()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }
    
    
    //Realizar pulo na parede
    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;
            
            CancelInvoke(nameof(StopWallJumping));
        }
        
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            anim.Play("Jump_Luca");
            somJump.Play();
            isWallJumping = true;
            rig.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;
            
            if (transform.localScale.x != wallJumpingDirection)
            {
                flipX = !flipX;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1;
                transform.localScale = localScale;
            }
            
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
            
    }
    
    
    //Parar pulo na parede
    private void StopWallJumping()
    {
        isWallJumping = false;
    }
    
    
    //Rotacionar o personagem
    private void Flip()
    {
        flipX = !flipX;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    
    //Verifica se o personagem está colidindo com uma parede
    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    
    //Permite o jogador deslizar na parede
    private void WallSlide()
    {
        if (IsWalled() && !isGrounded && horizontal != 0f)
        {
            isWallSliding = true;
            rig.velocity = new Vector2(rig.velocity.x, math.clamp(rig.velocity.y, -walllSlindingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            anim.Play("WallSlide_Luca");
        }
    }

    
    //Ativa o dash do jogador
    private void ActiveDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    
    //Verifica se o jogador entrou em contato com o chão
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    
    //Verifica se o jogador saiu do contato como chão
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    
    //Lógica do Dash do jogador
    private IEnumerator Dash()
    {
        somDash.Play();
        canDash = false;
        isDashing = true;
        float originalGravity = rig.gravityScale;
        rig.gravityScale = 0f;
        rig.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rig.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}

