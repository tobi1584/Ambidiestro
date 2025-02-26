using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        score = 0;
        scoreText.text = score + "/10";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Moneda")
        {
            score++;
            Debug.Log(score);
            scoreText.text = score +"/10";
        }
    }
}
