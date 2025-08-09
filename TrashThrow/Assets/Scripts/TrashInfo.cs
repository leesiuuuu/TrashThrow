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
    public float dissolveSpeed = 2f;

    public float stillDuration = 0.5f;
    public float stillVelocityThreshold = 0.05f;

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
        if (transform.position.y < -15 && !isRespawn)
        {
            Respawn();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isRespawn)
        {
            StartCoroutine(CheckStillBeforeRespawn());
        }
    }

    private IEnumerator CheckStillBeforeRespawn()
    {
        float stillTime = 0f;

        while (stillTime < stillDuration)
        {
            if (rigidbody.velocity.magnitude < stillVelocityThreshold)
            {
                stillTime += Time.deltaTime;
            }
            else
            {
                stillTime = 0f;
            }

            yield return null;
        }

        Respawn();
    }

    public void Respawn()
    {
        if (isRespawn) return;

        isRespawn = true;
        StartCoroutine(RespawnCoroutine());
    }

    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));

        float ElapsedTime = 0f;
        while (ElapsedTime < dissolveSpeed)
        {
            float noiseStrength = Mathf.MoveTowards(material.GetFloat("_NoiseStrength"), 1.25f, dissolveSpeed * Time.deltaTime);
            material.SetFloat("_NoiseStrength", noiseStrength);

            ElapsedTime += Time.deltaTime;
            yield return null;
        }

        rigidbody.isKinematic = true;

        transform.rotation = SpawnRot;
        transform.position = SpawnPos;

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        yield return null;
        rigidbody.isKinematic = false;

        ElapsedTime = 0f;
        while (ElapsedTime < dissolveSpeed)
        {
            float noiseStrength = Mathf.MoveTowards(material.GetFloat("_NoiseStrength"), -0.5f, dissolveSpeed * Time.deltaTime);
            material.SetFloat("_NoiseStrength", noiseStrength);

            ElapsedTime += Time.deltaTime;
            yield return null;
        }

        isRespawn = false;
    }

    private void RigidSet()
    {
        rigidbody.mass = 3 * ((int)trashSO.weight + 1);
    }
}
