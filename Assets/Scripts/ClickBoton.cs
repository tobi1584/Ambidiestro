using UnityEngine;

public class ClickBoton : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Obtén el componente AudioSource adjunto al GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        // Reproduce el sonido
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No se encontró un componente AudioSource en el GameObject.");
        }
    }
}
