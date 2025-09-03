using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Collections;

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
        if (scoreManager == null)
            scoreManager = FindObjectOfType<ScoreManager>();
    }

    public IEnumerator ShowScore(int score, int subScore)
    {
        if (uIAppear) yield return null;

        int finalScore = score + subScore;

        uIAppear = true;


        scoreText.text = score.ToString();
        scoreText.DOFade(1f, 0.5f).OnComplete(() =>
        {
            scoreText.DOFade(0f, 0.5f).OnComplete(() =>
            {
                uIAppear = false;
            });
        });

        if (subScore != 0)
        {
            subText.rectTransform.localScale = Vector3.zero;
            subText.color = Color.white;
            subText.text = "+" + subScore.ToString();
            subText.rectTransform.DOScale(1f, 0.5f).OnComplete(() =>
            {
                subText.DOFade(0f, 0.5f);
            }).SetDelay(0.3f).SetEase(Ease.OutCubic);
        }
        scoreManager.AddScore(finalScore);
    }
}
