using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 moveDirection;

    [Header("Stats")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float movementX;
    [SerializeField] float movementY;
    private bool isFacingLeft;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Player Movement
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");
        
        moveDirection = new Vector3(movementX, movementY);

        // Animations
        if(movementX != 0f || movementY != 0f)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);

        // Handling if needs to rotate player left/right
        if (movementX < 0f && !isFacingLeft)
        {
            isFacingLeft = true;
            FlipPlayer();
        }
        else if(movementX > 0f && isFacingLeft)
        {
            isFacingLeft = false;
            FlipPlayer();
        }
    }

    private void FlipPlayer()
    {
        // Rotate around y axis
        transform.Rotate(0f, 180f, 0f);
    }

    private void FixedUpdate()
    {
        // Adds velocity to rigidbody decide how to move
        rb.velocity = moveDirection * moveSpeed;
    }
}
