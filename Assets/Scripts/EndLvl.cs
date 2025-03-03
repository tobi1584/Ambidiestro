using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena

public class EndLvl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player2"))
        {

            if (Score.score >= 10)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Debug.Log("No se cumplen las condiciones para reiniciar.");
            }
        }
    }

}
