using UnityEngine;

public class BinCollider : MonoBehaviour
{
    [SerializeField]
    private ScoreUI scoreUI;
    private void OnTriggerEnter(Collider other)
    {
        TrashSO trashSO = other.GetComponent<TrashInfo>().trashSO;
        scoreUI.gameObject.SetActive(true);
        scoreUI.ShowScore(100 * (3-(int)trashSO.size), other.GetComponent<TrashInfo>());
    }
}
