using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TrashInfo : MonoBehaviour
{
    private Vector3 SpawnPos;
    private Quaternion SpawnRot;
    private Rigidbody rigidbody;
    private Material material;

    private bool isRespawn = false;
    private bool isOff = false;

    public TrashSO trashSO;
    public float dissolveSpeed = 2f;

    public float stillDuration = 0.5f;
    public float stillVelocityThreshold = 0.05f;

    public int CollideCount = 0;

    public AudioClip BoopSFX;

    private XRGrabInteractable xRGrabInteractable;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        RigidSet();
        SpawnPos = transform.position;
        SpawnRot = transform.rotation;

        material = GetComponent<MeshRenderer>().material;
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
    }

    public void Update()
    {
        if (transform.position.y < -15 && !isRespawn)
        {
            Respawn();
        }
        if (isOff)
        {
            xRGrabInteractable.enabled = false;
        }
        else
        {
            xRGrabInteractable.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isRespawn)
        {
            string tag = collision.gameObject.tag;
            //SoundManager.Instance.SFXPlay("boop", BoopSFX);
            if (tag == "Table" || tag == "Obj") return;

            CollideCount++;

            StartCoroutine(CheckStillBeforeRespawn());
        }
    }


    private IEnumerator CheckStillBeforeRespawn()
    {
        float stillTime = 0f;
        isOff = true;

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
        yield return new WaitForSeconds(Random.Range(0.3f, 1f));

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

        isOff = false;

        ElapsedTime = 0f;
        while (ElapsedTime < dissolveSpeed)
        {
            float noiseStrength = Mathf.MoveTowards(material.GetFloat("_NoiseStrength"), -0.5f, dissolveSpeed * Time.deltaTime);
            material.SetFloat("_NoiseStrength", noiseStrength);

            ElapsedTime += Time.deltaTime;
            yield return null;
        }

        isRespawn = false;
        CollideCount = 0;
    }

    private void RigidSet()
    {
        rigidbody.mass = 2 * ((int)trashSO.Weight + 1);
    }
}
