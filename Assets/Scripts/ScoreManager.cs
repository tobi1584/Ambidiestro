using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private Puntaje puntajeUI;

    private void Start()
    {
        GameObject uiManager = GameObject.Find("UIManager"); // Asegúrate de que el objeto con Puntaje se llama así
        if (uiManager != null)
        {
            puntajeUI = uiManager.GetComponent<Puntaje>();
        }
        else
        {
            Debug.LogError("No se encontró 'UIManager' en la escena.");
        }
    }

    public void RaiseScore(int s)
    {
        score += s;
        Debug.Log("Puntuación actual: " + score);

        if (puntajeUI != null)
        {
            puntajeUI.UpdateUI();
        }
    }

    public int GetScore()
    {
        return score;
    }
}