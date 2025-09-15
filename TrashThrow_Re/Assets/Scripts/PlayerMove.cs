using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    public Transform[] transforms;
    public Fader fader;
    private CharacterController controller;
    private ScoreManager scoreManager;

    private int CurrentRoom;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        scoreManager = FindObjectOfType<ScoreManager>();
        movePos(0);
    }

    public void MovePos(int n)
    {
        UnityEvent e = new UnityEvent();
        e.AddListener(() => { movePos(n); });
        fader.FadeIn(e);
        CurrentRoom = n;
    }
    private void movePos(int n)
    {
        transform.position = transforms[n].position;
        transform.rotation = transforms[n].rotation;
        scoreManager.ResetScore();
        fader.FadeOut(null);
    }
    public void GoGamePos()
    {
        UnityEvent e = new UnityEvent();
        e.AddListener(() =>
        {
            movePos(CurrentRoom);
            scoreManager.GameStart();
            MoveDisable();
        });
        fader.FadeIn(e);
    }

    public void MoveDisable()
    {
        controller.enabled = false;
    }
    public void MoveEnable()
    {
        controller.enabled = true;
    }

}
