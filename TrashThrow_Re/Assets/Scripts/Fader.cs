using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Image Panel;
    public float FadeInDuration;
    public float FadeOutDuration;

    public void Start()
    {
        FadeOut(null);
    }

    public void FadeIn(UnityEvent e)
    {
        Panel.DOFade(1f, FadeInDuration).OnComplete(() => e?.Invoke());
    }
    public void FadeOut(UnityEvent e)
    {
        Panel.DOFade(0f, FadeOutDuration).OnComplete(() => e?.Invoke());
    }
}
