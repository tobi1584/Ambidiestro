using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float velocidadNormal = 3f; // Velocidad normal del jugador
    public float velocidadReducida = 1.5f; // Velocidad reducida en arena movediza
    private float velocidadActual; // Velocidad actual del jugador
    public float jumpForce = 5f; // Fuerza del salto
    private bool isGrounded; // Verifica si el jugador está en el suelo
    private bool enArenaMovediza; // Verifica si está en arena movediza
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogError("No Rigidbody2D component found on " + gameObject.name);

        animator = GetComponent<Animator>();
        if (animator == null) Debug.LogError("No Animator component found on " + gameObject.name);

        velocidadActual = velocidadNormal; // Iniciar con velocidad normal
        enArenaMovediza = false; // Al inicio, no está en arena movediza
    }

    void Update()
    {
        float movimiento = 0f;

        // Movimiento a la izquierda con flecha ←
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movimiento = -velocidadActual * Time.deltaTime;
            animator.SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        // Movimiento a la derecha con flecha →
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movimiento = velocidadActual * Time.deltaTime;
            animator.SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        // Aplicar movimiento
        transform.Translate(movimiento, 0, 0);

        // Si no se presionan las flechas, el jugador deja de moverse
        if (movimiento == 0f)
        {
            animator.SetBool("moving", false);
        }

        ManageJump();
    }

    void ManageJump()
    {
        // Evita el salto si está en la arena movediza
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded && rb != null && !enArenaMovediza)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Desactivar el estado de estar en el suelo al saltar
        }
    }

    // Detectar colisión con el suelo y arena movediza
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // Si el jugador pisa la arena movediza, reduce la velocidad y bloquea el salto
        if (collision.gameObject.CompareTag("ArenaMovediza"))
        {
            velocidadActual = velocidadReducida;
            enArenaMovediza = true; // Marca que está en arena movediza
        }
    }

    // Detectar si el jugador sale de la arena movediza
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ArenaMovediza"))
        {
            velocidadActual = velocidadNormal; // Restaurar velocidad normal
            enArenaMovediza = false; // Puede volver a saltar
        }
    }
}
