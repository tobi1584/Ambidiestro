using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement; // Necesario para reiniciar el nivel

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // Referencia al texto en la UI
    public int startTime = 15; // Tiempo inicial en segundos
    private int currentTime;

    private void Start()
    {
        currentTime = startTime;
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (currentTime > 0)
        {
            countdownText.text = "Tiempo: " + currentTime; // Actualiza el texto
            yield return new WaitForSeconds(1); // Espera 1 segundo
            currentTime--;
        }

        countdownText.text = "¡Tiempo agotado!";
        yield return new WaitForSeconds(1); // Pequeña pausa antes de reiniciar
        ReiniciarNivel(); // Llamar a la función para reiniciar el nivel
    }

    private void ReiniciarNivel()
    {
        Debug.Log("Tiempo agotado. Reiniciando nivel...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
    }
}