using UnityEngine;
using System.Collections;

public class SpawnerBolas : MonoBehaviour
{
    public GameObject bolaDeFuegoPrefab; // Prefab de la bola de fuego
    public float intervalo = 3f; // Cada cuánto tiempo aparece una nueva bola

    void Start()
    {
        // Empezar la creación de bolas de fuego repetidamente
        StartCoroutine(GenerarBolas());
    }

    IEnumerator GenerarBolas()
    {
        while (true)
        {
            // Instanciar una nueva bola de fuego en la posición del Spawner
            GameObject bolaDeFuego = Instantiate(bolaDeFuegoPrefab, transform.position, Quaternion.identity);

            // Cambiar la dirección de la bola de fuego dependiendo de la posición del spawner
            BolaDeFuego bolaScript = bolaDeFuego.GetComponent<BolaDeFuego>();

            // Cambiar la dirección si el spawner está en la parte derecha o izquierda
            if (transform.position.x < 0)
            {
                bolaScript.haciaDerecha = true; // Mueve la bola a la derecha
            }
            else
            {
                bolaScript.haciaDerecha = false; // Mueve la bola a la izquierda
            }

            // Esperar el intervalo antes de crear otra bola
            yield return new WaitForSeconds(intervalo);
        }
    }
}