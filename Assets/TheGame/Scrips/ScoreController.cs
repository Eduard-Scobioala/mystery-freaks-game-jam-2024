using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public PlayerHealthController playerHealthController;
    public int scoreValue = 0;
    public int scoreIncrement = 1;

    private void Start()
    {
        SetText(scoreValue.ToString());
        StartCoroutine(ScoreIncrease());
    }

    private void FixedUpdate()
    {
        SetText(scoreValue.ToString());
    }

    public void SetText(string text)
    {
        scoreText.text = text;
    }

    private IEnumerator ScoreIncrease()
    {
        WaitForSeconds wait = new(scoreIncrement);

        while (playerHealthController.isPlayerAlive)
        {
            yield return wait;

            scoreValue += scoreIncrement;
        }
    }
}
