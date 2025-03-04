using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // Arrastra el Panel del menú de pausa en el Inspector.
    private bool isPaused = false;

    void Update()
    {
        // Detecta si se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true); // Muestra el menú de pausa
        Time.timeScale = 0f; // Detiene el tiempo del juego
    }

    public void ResumeGame()
    {
        Debug.Log("RESUMEGAME PULSADO");
        isPaused = false;
        pauseMenu.SetActive(false); // Oculta el menú de pausa
        Time.timeScale = 1f; // Reanuda el juego
    }

    public void QuitToMainMenu()
    {
        Debug.Log("QUITTOMAINMENU PULSADO");
        Time.timeScale = 1f; // Asegura que el tiempo se reanude antes de salir
        SceneManager.LoadScene("Menu_Inicio"); // Cambia a la escena del menú principal (ajusta el nombre)
    }
}
