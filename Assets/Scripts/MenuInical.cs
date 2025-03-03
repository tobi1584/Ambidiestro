using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInical : MonoBehaviour
{
    public void Jugar()
    {
        TrancisionEscena.Instance.BloqueoSalida(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
}

