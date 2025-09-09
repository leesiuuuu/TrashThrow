using UnityEngine;

public class BinCollider : MonoBehaviour
{
    public int BasicScore = 100;
    [SerializeField]
    private ScoreUI scoreUI;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private int ComboScore = 10;

    private float ComboTime = 0f;
    private int ComboStack = -1;
    private float ComboDuration = 2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obj"))
        {
            TrashInfo info = other.GetComponent<TrashInfo>();
            TrashSO trashSO = info.trashSO;
            particle.Play();
            scoreUI.gameObject.SetActive(true);
            ++ComboStack;
            Debug.Log(ComboStack);
        StartCoroutine(scoreUI.ShowScore(
                BasicScore * (3 - (int)trashSO.Size),
                (50 * Mathf.Abs(5 - info.CollideCount)) +
                ComboScore * ComboStack,
                ComboStack));
            info.Respawn();
        }
    }

    private void Update()
    {
        if (ComboStack > -1 && ComboTime <= ComboDuration)
        {
            ComboTime += Time.deltaTime;
        }
        else
        {
            ComboTime = 0f;
            ComboStack = -1;
        }
    }
}
