using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public float movementSpeed = 0.01f;
    private Animator animator;
    private bool isSitting = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if the cat is sitting
        if (isSitting)
        {
            // Set the animator bool for sitting animation
            animator.SetBool("IsSitting", true);
            return; // Exit the update loop to prevent movement
        }
        else
        {
            // Reset the animator bool for sitting animation
            animator.SetBool("IsSitting", false);
        }

        // Get horizontal and vertical input values
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Check if there is any movement input
        if (movementDirection.magnitude > 0)
        {
            // Set the animator bool for walk animation
            animator.SetBool("IsWalking", true);

            // Calculate the target rotation based on the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);

            // Smoothly rotate the cat towards the target rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

            // Move the cat in the movement direction
            transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            // Reset the animator bools for walk and idle animations
            animator.SetBool("IsWalking", false);
        }

        // Check if the player pressed the "Space" key for meowing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Set the animator trigger for meow animation
            animator.SetBool("Meow",true);
        }
    }

    public void SetSitting(bool sitting)
    {
        isSitting = sitting;
    }
}
