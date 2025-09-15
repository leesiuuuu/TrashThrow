using UnityEngine;

public class Speaker : MonoBehaviour
{
    public AudioClip[] Musics;
    public Transform[] transforms;
    public AudioSource audioSource;

    void Start()
    {
        MusicChange(0);
    }


    public void MusicChange(int n)
    {
        audioSource.clip = Musics[n];
        audioSource.Play();
        PosChange(n);
    }
    private void PosChange(int n)
    {
        transform.position = transforms[n].position;
        transform.rotation = transforms[n].rotation;
    }
}
