using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaDeFuego : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de la bola de fuego
    public bool haciaDerecha = true; // Direccion inicial (por defecto hacia la derecha)

    void Update()
    {
        // Si va hacia la derecha, mueve la bola a la derecha, si no, a la izquierda
        float direccion = haciaDerecha ? 1f : -1f;
        transform.Translate(Vector2.right * velocidad * direccion * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si la bola de fuego toca al jugador
        if (other.CompareTag("Player2") || other.CompareTag("Player"))
        {
            Debug.Log("🔥 El jugador ha sido eliminado por la bola de fuego!");

            // Destruir al jugador
            Destroy(other.gameObject); // Elimina al jugador del juego

            // Reiniciar la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Vuelve a cargar la escena actual
        }
    }

    void Start()
    {
        // Destruir la bola de fuego después de 5 segundos para evitar que se quede en memoria
        Destroy(gameObject, 5f);
    }
}