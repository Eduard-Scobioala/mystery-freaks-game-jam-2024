using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 5f;
    public int scorePoints = 3;

    [SerializeField] private ScoreController scoreController;

    private void Start()
    {
        GameObject scoreObject = GameObject.Find("Score");
        scoreController = scoreObject.GetComponent<ScoreController>();
    }

    private void FixedUpdate()
    {
        if (health < 0)
        {
            scoreController.scoreValue += scorePoints;
            Destroy(gameObject);
        }
    }
}
