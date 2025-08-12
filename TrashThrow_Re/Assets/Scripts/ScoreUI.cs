using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreUI : MonoBehaviour
{
    public ScoreManager scoreManager;
    [SerializeField]
    private TextMeshPro scoreText;
    [SerializeField]
    private TextMeshPro subText;

    private bool uIAppear = false;
    private void Start()
    {
        scoreText.color = new Color(1f, 1f, 1f, 0f);
        subText.color = new Color(1f, 1f, 1f, 0f);
        if (scoreManager == null)
            scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void ShowScore(int score, int subScore)
    {
        if (uIAppear) return;

        int finalScore = score + subScore;

        uIAppear = true;

        if (subScore != 0)
        {
            subText.text = "+" + subScore.ToString();
            subText.DOFade(1f, 0.5f).OnComplete(() =>
            {
                subText.DOFade(0f, 0.5f);
            });
        }

        scoreText.text = score.ToString();
        scoreText.DOFade(1f, 0.5f).OnComplete(() =>
        {
            scoreText.DOFade(0f, 0.5f).OnComplete(() =>
            {
                uIAppear = false;
            });
        });
        scoreManager.AddScore(finalScore);
    }
}
