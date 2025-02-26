using UnityEngine;

public class CoinController : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        // Buscar el ScoreManager una sola vez al inicio
        GameObject scripter = GameObject.Find("Scripter");

        if (scripter != null)
        {
            scoreManager = scripter.GetComponent<ScoreManager>();
        }
        else
        {
            Debug.LogError("No se encontró el objeto 'Scripter' en la escena.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (scoreManager != null)
        {
            scoreManager.RaiseScore(1);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("ScoreManager no está asignado en CoinController.");
        }
    }
}