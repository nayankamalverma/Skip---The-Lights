using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private Transform runner;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private LayerMask groundLayerMask; // for raycast check
    [SerializeField]
    private Transform feet; //to check in raycast player feet touching ground
    [SerializeField]
    private float groundDistance = 0.25f; // radius of feet overlap circle
    [SerializeField]
    private float jumpTime = 0.3f;
    [SerializeField]
    private float crouchHeight = 0.5f;

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private void OnEnable()
    {
        jumpTimer = 0;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feet.position, groundDistance, groundLayerMask);

        #region jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rigidBody.velocity = Vector2.up * jumpForce ;
        }
        
        if(isJumping && Input.GetButton("Jump"))
        {
            if(jumpTimer < jumpTime)
            {
                rigidBody.velocity = Vector2.up * jumpForce ;
                jumpTimer += Time.deltaTime;
            }else
            {
                isJumping=false;
            }

        }
        if (Input.GetButtonUp("Jump")){
            isJumping = false;
            jumpTimer = 0;
        }
        #endregion

        #region Crouching
        if(isGrounded && Input.GetButton("Crouch"))
        {
            runner.localScale = new Vector3(runner.localScale.x, crouchHeight , runner.localScale.y);
        }
        if(isJumping)
        {
            runner.localScale = new Vector3(runner.localScale.x, 0.7f , runner.localScale.y);
        }
        if (Input.GetButtonUp("Crouch"))
        {
            runner.localScale = new Vector3(runner.localScale.x, 0.7f, runner.localScale.y);
        }
        #endregion


    }



}