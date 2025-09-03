using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int Score;
    public GameObject Button;
    public GameObject MainBtn;
    [Header("게임 시작 시 보이는 패널")]
    public GameObject GamePanel;
    public GameObject GameTitle;
    [Header("게임 준비 시 보이는 패널")]
    public GameObject NormalPanel;
    public GameObject NormalTitle;
    [Header("결과창 패널")]
    public GameObject ResultPanel;
    public GameObject ResultTitle;
    [Header("시간 표시 UI")]
    public Text TimerText;
    public TMP_Text CountText;
    public TMP_Text GameOverText;

    public Text scoreText;
    public Text ResultText;
    public Text ResultTimeText;

    private bool isGameEnded = false;
    [HideInInspector]
    public string Rank;

    public void AddScore(int score)
    {
        this.Score += score;
        scoreText.text = Score.ToString();
    }
    public void ResetScore()
    {
        MainBtn.SetActive(false);
        Button.SetActive(true);

        ResultPanel.SetActive(false);
        ResultTitle.SetActive(false);

        NormalPanel.SetActive(true);
        NormalTitle.SetActive(true);

        Score = 0;
        Rank = "";
    }

    public void GameStart()
    {
        GamePanel.SetActive(true);
        GameTitle.SetActive(true);

        NormalPanel.SetActive(false);
        NormalTitle.SetActive(false);

        Button.SetActive(false);

        scoreText.text = "0";
        StartCoroutine(Timer());
    }

    public void GameEnd()
    {
        GamePanel.SetActive(false);
        GameTitle.SetActive(false);

        ResultPanel.SetActive(true);
        ResultTitle.SetActive(true);

        MainBtn.SetActive(true);
    }

    void Update()
    {
        if (Score >= 3000 && !isGameEnded)
        {
            isGameEnded = true;
        }
    }

    private IEnumerator Timer()
    {
        CountText.DOFade(1f, 0.5f);
        for (int i = 3; i > 0; i--)
        {
            CountText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        CountText.text = "GO!";
        CountText.DOFade(0f, 0.5f).OnComplete(() =>
        {
            CountText.text = "";
        });

        float ElapsedTime = 180f;

        while (ElapsedTime >= 0f && !isGameEnded)
        {
            ElapsedTime -= Time.deltaTime;
            TimerUI(ElapsedTime);
            yield return null;
        }

        if(Score >= 3000)
            GameOverText.text = "GAME CLEAR!";
        else
            GameOverText.text = "GAME OVER";


        yield return new WaitForSeconds(1f);

        GameOverText.text = "";

        Rank = Result(ElapsedTime);

        GameEnd();

        ResultText.text = Rank;
        ResultTimeText.text = ChangeTime(180f - ElapsedTime);
    }

    private void TimerUI(float currentTime)
    {
        TimerText.text = ChangeTime(currentTime);
    }

    private string ChangeTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        float seconds = time % 60;
        return $"{minutes:00}:{seconds:00.00}";
    }

    private string Result(float time)
    {
        if (time > 100) return "A";
        else if (time <= 100 && time > 50) return "B";
        else if (time >= 50 && time <= 0.01) return "C";
        else return "F";
    }
}
