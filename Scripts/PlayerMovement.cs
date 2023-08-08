using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed
    public int score = 0; // Score counter

    private bool isNearMailbox = false; // Whether the player is near the mailbox

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Left stick horizontal axis
        float verticalInput = Input.GetAxis("Vertical"); // Left stick vertical axis

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0.0f);
        
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        
        //Debug.Log("Score: " + score);
        // If the player is near the mailbox and presses the A button, increment the score
        if (isNearMailbox && Input.GetButtonDown("Jump"))
        {
            score++;
            Debug.Log("Score: " + score);
        }
    }

    // This function is called when the player enters a collider with a trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("In");
        if (other.gameObject.CompareTag("Mailbox"))
        {
            isNearMailbox = true;
        }
    }

    // This function is called when the player exits a collider with a trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Out");
        if (other.gameObject.CompareTag("Mailbox"))
        {
            isNearMailbox = false;
        }
    }
}
