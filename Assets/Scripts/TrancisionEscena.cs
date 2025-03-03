using UnityEngine;
using UnityEngine.SceneManagement;

public class TrancisionEscena : MonoBehaviour
{
    public static TrancisionEscena Instance; // Cambiado a 'Instance' con mayúscula
    [Header("Disolver")]
    public CanvasGroup disolverCanvasGroup;
    public float tiempoDisolverEntrada;
    public float tiempoDisolverSalida;

    [Header("Bloqueo")]
    public RectTransform bloqueObject;
    public float tiempoBloqueoEntrada;
    public float tiempoBloqueoSalida;
    public LeanTweenType bloqueoEaseEntrada;
    public LeanTweenType bloqueoEaseSalida;
    public float posicionFinalEntrada;
    public float posicionFinalSalida;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        BloqueoEntrada();
    }

    private void DisolverEntrada()
    {
        LeanTween.alphaCanvas(disolverCanvasGroup, 0f, tiempoDisolverEntrada).setOnComplete(() =>
        {
            disolverCanvasGroup.blocksRaycasts = false;
            disolverCanvasGroup.interactable = false;
        });
    }

    public void DisolverSalida(int indexEscena)
    {
        disolverCanvasGroup.blocksRaycasts = true;
        disolverCanvasGroup.interactable = true;
        LeanTween.alphaCanvas(disolverCanvasGroup, 1f, tiempoDisolverEntrada).setOnComplete(() =>
        {
            SceneManager.LoadScene(indexEscena);
        });
    }

    private void BloqueoEntrada()
    {
        LeanTween.moveX(bloqueObject, posicionFinalEntrada, tiempoBloqueoEntrada).setEase(bloqueoEaseEntrada).setOnComplete(() =>
        {
            bloqueObject.gameObject.SetActive(false);
        });
    }

    public void BloqueoSalida(int indexEscena)
    {
        bloqueObject.gameObject.SetActive(true);
        LeanTween.moveX(bloqueObject, 0f, tiempoBloqueoSalida).setEase(bloqueoEaseSalida).setOnComplete(() =>
        {
            SceneManager.LoadScene(indexEscena);
        });
    }
}

