using UnityEngine;

public class MovementControllerBlue : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 30f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public GameManager GM;

    private void Start() {
        GM = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if(!GM.isGamePaused){
            if(Input.GetKey(KeyCode.LeftArrow)){
                horizontal = -1;
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow)){
                horizontal = 0;
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                horizontal = 1;
            }
            if(Input.GetKeyUp(KeyCode.RightArrow)){
                horizontal = 0;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}