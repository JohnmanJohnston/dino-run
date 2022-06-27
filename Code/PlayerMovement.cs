using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float JumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float GroundCheckRadius;
    private Rigidbody2D PhysicsBody;

    private void Start() {
        PhysicsBody = GetComponent<Rigidbody2D>();
        isGrounded = false;
    }

    private void Jump() => PhysicsBody.AddForce(new Vector2(0f, JumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
    private void HandleGroundCheck() => isGrounded = Physics2D.OverlapCircle(transform.position, (GroundCheckRadius + (transform.position.y / 2f)) + .1f, LayerMask.GetMask("Ground"));

    private void Update() {
        HandleGroundCheck();

        if (Input.GetKey(KeyCode.Space)) {
            if (isGrounded) {
                if (GameManager.GameHasEnded)
                    return;
                    
                Jump();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
            StartCoroutine(GameManager.OnLose());
        }
    }
}
