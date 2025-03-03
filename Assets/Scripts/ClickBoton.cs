using UnityEngine;

public class ClickBoton : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Obt�n el componente AudioSource adjunto al GameObject
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
            Debug.LogWarning("No se encontr� un componente AudioSource en el GameObject.");
        }
    }
}
