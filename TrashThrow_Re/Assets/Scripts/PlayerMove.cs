using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class PlayerMove : MonoBehaviour
{
    public Transform[] transforms;
    public Fader fader;
    private CharacterController controller;

    private int CurrentRoom;

    void Start()
    {
        controller = GetComponent<CharacterController>();
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
        FindObjectOfType<ScoreManager>().ResetScore();
        fader.FadeOut(null);
    }
    public void GoGamePos()
    {
        UnityEvent e = new UnityEvent();
        e.AddListener(() =>
        {
            movePos(CurrentRoom);
            FindObjectOfType<ScoreManager>().GameStart();
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
