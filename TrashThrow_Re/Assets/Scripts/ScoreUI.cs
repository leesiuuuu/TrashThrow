using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro scoreText;

    private bool uIAppear = false;
    private void Start()
    {
        scoreText.color = new Color(1f, 1f, 1f, 0f);
    }
    
    public void ShowScore(int score)
    {
        if (uIAppear) return;
        uIAppear = true;

        scoreText.color = Color.white;
        scoreText.text = score.ToString();
        scoreText.DOFade(1f, 0.5f).OnComplete(() =>
        {
            scoreText.DOFade(0f, 0.5f).OnComplete(() =>
            {
                gameObject.SetActive(false);
                uIAppear = false;
            });
        });
    }
}
