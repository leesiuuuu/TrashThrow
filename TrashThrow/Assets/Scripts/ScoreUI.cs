using UnityEngine;
using DG.Tweening;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro scoreText;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    
    public void ShowScore(int score, TrashInfo obj)
    {
        scoreText.color = Color.white;
        scoreText.text = score.ToString();
        scoreText.rectTransform.anchoredPosition = new Vector2(-2.54f, 15);
        scoreText.rectTransform.DOAnchorPosY(25, 0.5f).SetEase(Ease.OutQuint).OnComplete(() =>
        {

            scoreText.DOColor(new Color(1f, 1f, 1f, 0), 0.5f).OnComplete(() =>
            {
                obj.Respawn();
                gameObject.SetActive(false);
            });
        });
    }
}
