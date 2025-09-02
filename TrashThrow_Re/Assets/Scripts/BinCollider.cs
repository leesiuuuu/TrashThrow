using UnityEngine;

public class BinCollider : MonoBehaviour
{
    [SerializeField]
    private ScoreUI scoreUI;
    [SerializeField]
    private ParticleSystem particle;
    private void OnTriggerEnter(Collider other)
    {
        TrashInfo info = other.GetComponent<TrashInfo>();
        TrashSO trashSO = info.trashSO;
        particle.Play();
        scoreUI.gameObject.SetActive(true);
        scoreUI.ShowScore(100 * (3 - (int)trashSO.Size), 50 * Mathf.Abs(5 - info.CollideCount));
        info.Respawn();
    }
}
