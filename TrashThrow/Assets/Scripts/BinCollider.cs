using UnityEngine;

public class BinCollider : MonoBehaviour
{
    [SerializeField]
    private ScoreUI scoreUI;
    private void OnTriggerEnter(Collider other)
    {
        TrashInfo info = other.GetComponent<TrashInfo>();
        TrashSO trashSO = info.trashSO;
        scoreUI.gameObject.SetActive(true);
        scoreUI.ShowScore(100 * (3 - (int)trashSO.size));
        info.Respawn();
    }
}
