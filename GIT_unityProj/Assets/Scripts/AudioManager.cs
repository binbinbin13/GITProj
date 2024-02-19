using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioBgm;
    public AudioClip gameBgm;
    public AudioClip pointSfx;
    public AudioClip contactedSfx;
    public AudioClip uncontactedSfx;
    public AudioClip doorSfx;
    public AudioClip errorSfx;
    public AudioClip gameWinSfx;
    public AudioClip gameLoseSfx;
    public AudioClip healthSfx;
    public AudioClip DamageSfx;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) 
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();

        //audioSource.clip = gameBgm;
        //audioSource.Play();
        audioBgm.Play();
    }

    public void PlayBGM() 
    {
        //audioSource.Play();
        audioBgm.Play();
    }

    public void StopBGM()
    {
        //audioSource.clip = null;
        //audioSource.Pause();
        audioBgm.Pause();
    }

    public void PlayPointSfx() 
    {
        audioSource.PlayOneShot(pointSfx);
    }

    public void PlayGameWinSfx()
    {
        audioSource.PlayOneShot(gameWinSfx);
    }

    public void PlayGameLoseSfx()
    {
        audioSource.PlayOneShot(gameLoseSfx);
    }

    public void PlayDoorSfx()
    {
        audioSource.PlayOneShot(doorSfx);
    }

    public void PlayErrorSfx()
    {
        audioSource.PlayOneShot(errorSfx);
    }

    public void PlayHealthSfx()
    {
        audioSource.PlayOneShot(healthSfx);
    }

    public void PlayContactedSfx() 
    {
        audioSource.PlayOneShot(contactedSfx);
    }

    public void PlayUnContactedSfx()
    {
        audioSource.PlayOneShot(uncontactedSfx);
    }

    public void PlayDamageSfx() 
    {
        if(!audioSource.isPlaying)
            audioSource.PlayOneShot(DamageSfx);
    }
}
