using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D characterBody;
    public float jumpForce;
    private float moveSpeed;
    private float moveHorizontal;
    private float moveVertical;
    private bool isJumping;

    // Called at the first running frame
    void Start()
    {
        characterBody = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 1.2f;
        jumpForce = 20f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            characterBody.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (moveVertical > 0.1f && !isJumping)
        {
            characterBody.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }

    // when the player touches the ground
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform"){
            isJumping = false;
        }
    }

    // when the player is jumping so out of the ground
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform"){
            isJumping = true;
        }
    }
}