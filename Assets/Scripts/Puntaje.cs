using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    
    public TextMeshProUGUI puntajeText; // Referencia al texto en la UI
    private ScoreManager scoreManager;

    private void Start()
    {
        GameObject scripter = GameObject.Find("Scripter");
        if (scripter != null)
        {
            scoreManager = scripter.GetComponent<ScoreManager>();
        }
        else
        {
            Debug.LogError("No se encontró el objeto 'Scripter' en la escena.");
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        if (puntajeText != null && scoreManager != null)
        {
            puntajeText.text = "Puntaje: " + scoreManager.GetScore();
        }
        else
        {
            Debug.LogError("No se ha asignado el TextMeshProUGUI o ScoreManager.");
        }
    }
}