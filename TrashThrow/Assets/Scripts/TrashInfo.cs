using UnityEngine;

public class TrashInfo : MonoBehaviour
{
    private Vector3 SpawnPos;
    private Quaternion SpawnRot;
    private Rigidbody rigidbody;
    public TrashSO trashSO;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        RigidSet();
        SpawnPos = transform.position;
        SpawnRot = transform.rotation;
    }
    public void Update()
    {
        if (transform.position.y < -15)
        {
            Respawn();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Respawn();
        }
    }
    public void Respawn()
    {
        transform.rotation = SpawnRot;
        transform.position = SpawnPos;
        rigidbody.velocity = Vector3.zero;
    }

    private void RigidSet()
    {
        rigidbody.mass = 3 * ((int)trashSO.weight + 1);
    }
}
