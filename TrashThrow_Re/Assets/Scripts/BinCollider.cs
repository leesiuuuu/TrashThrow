using UnityEngine;

public class BinCollider : MonoBehaviour
{
    public int BasicScore = 100;
    [SerializeField]
    private ScoreUI scoreUI;
    [SerializeField]
    private ParticleSystem particle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obj"))
        {
            TrashInfo info = other.GetComponent<TrashInfo>();
            TrashSO trashSO = info.trashSO;
            particle.Play();
            scoreUI.gameObject.SetActive(true);
            StartCoroutine(scoreUI.ShowScore(BasicScore * (3 - (int)trashSO.Size), 50 * Mathf.Abs(5 - info.CollideCount)));
            info.Respawn();
        }
    }
}
