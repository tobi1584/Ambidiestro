using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float jumpForce = 5f; // Fuerza del salto
    private bool isGrounded; // Verifica si el jugador est� en el suelo
    private Rigidbody2D rb;
    private bool moving;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody2D component found on " + gameObject.name);
        }

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("No Animator component found on " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            gameObject.transform.Translate(-3f * Time.deltaTime, 0, 0);
            animator.SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey("right"))
        {
            gameObject.transform.Translate(3f * Time.deltaTime, 0, 0);
            animator.SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (!Input.GetKey("left") && !Input.GetKey("right"))
        {
            moving = false; // Aqu� se corrige el error
            animator.SetBool("moving", false);
        }

        ManageJump();
    }

    void ManageJump()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded && rb != null)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Desactivar el estado de estar en el suelo al saltar
        }
    }

    // Detectar colisión con el suelo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}