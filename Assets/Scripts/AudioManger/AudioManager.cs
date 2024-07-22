using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXsource;



    [Header("---------- Audio Source---------")]
    public AudioClip background;
    public AudioClip death;
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }
}