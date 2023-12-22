using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private CharacterAnimator animator;
    private Vector2 input;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Transform groundPoint;
    [SerializeField] LayerMask groundMask;
    private bool isOnGround;


    // Start is called before the first frame update
    private void Awake()
    {
        //animator = GetComponent<CharacterAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");

        if (rb.velocity != Vector2.zero)
        {
            rb.velocity = new Vector2(input.x * moveSpeed, input.y);
        }
        
        //animator.MoveX = Mathf.Clamp(rb.velocity.x, -1f, 1f);
        //animator.MoveY = Mathf.Clamp(rb.velocity.y, -1f, 1f);
        //animator.IsMoving = true;

        // direction handle
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }

        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.1f, groundMask);

        // Se "jump" for pressionado e o player estiver no ch�o...
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }

        if (!isOnGround)
        {
            //animator.IsJumping = true;
        }
        else
        {
            //animator.IsJumping = false;
        }
    }
}
