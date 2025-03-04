using UnityEngine;

public class Coins : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            audioSource.Play();
            // Retrasar la destrucción del objeto para permitir que el sonido se reproduzca
            Destroy(this.gameObject, audioSource.clip.length -0.3f);
        }
    }
}
