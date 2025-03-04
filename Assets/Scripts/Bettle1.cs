using UnityEngine;
using UnityEngine.SceneManagement;

public class Bettle1 : MonoBehaviour
{
    public float velocidad = 2f;
    public float distancia = 1f;
    private Vector3 posicionInicial;
    private int direccion = 1;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Mueve el enemigo horizontalmente
        transform.position += Vector3.right * direccion * velocidad * Time.deltaTime;

        // Cambia de dirección si llega al límite
        if (Mathf.Abs(transform.position.x - posicionInicial.x) >= distancia)
        {
            direccion *= -1;
        }
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

}
