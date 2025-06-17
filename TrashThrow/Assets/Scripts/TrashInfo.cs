using UnityEngine;

public class TrashInfo : MonoBehaviour
{
    private Vector3 SpawnPos;
    public TrashSO trashSO;
    private void Start()
    {
        SpawnPos = transform.position;
    }
    public void Respawn()
    {
        transform.rotation = Quaternion.identity;
        transform.position = SpawnPos;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Respawn();
        }
    }
}
