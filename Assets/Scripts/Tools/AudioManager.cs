using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip stackSound;

    public AudioClip perfectlyStackSound;

    public AudioClip growCubeSound;

    public AudioClip newRecordSound;

    [SerializeField] AudioSource audioSource;


    public void playSoundEffect(AudioClip clip)
    {
        audioSource.clip = clip;

        audioSource.Play();
    }

}
