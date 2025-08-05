using System.Collections;
using DG.Tweening;
using UnityEngine;

public class TrashInfo : MonoBehaviour
{
    private Vector3 SpawnPos;
    private Quaternion SpawnRot;
    private Rigidbody rigidbody;
    private Material material;

    private bool isRespawn = false;

    public TrashSO trashSO;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        RigidSet();
        SpawnPos = transform.position;
        SpawnRot = transform.rotation;

        material = GetComponent<MeshRenderer>().material;
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
        if (collision.gameObject.CompareTag("Ground") && !isRespawn)
        {
            Respawn();
        }
    }
    public void Respawn()
    {
        isRespawn = true;

        material.DOFloat(1f, "_value", 0.5f).OnComplete(() =>
        {
            rigidbody.isKinematic = true;
            transform.rotation = SpawnRot;
            transform.position = SpawnPos;
            rigidbody.velocity = Vector3.zero;
            rigidbody.isKinematic = false;
            material.DOFloat(0f, "_value", 0.5f);
            isRespawn = false;
        });
    }

    private void RigidSet()
    {
        rigidbody.mass = 3 * ((int)trashSO.weight + 1);
    }
}
