using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : OdinSerializedSingletonBehaviour<AudioManager>
{
    public AudioSource sfxPrefab;

    public void PlaySFX(AudioClip clip, Vector3 position)
    {
        if (!clip)
            return;

        var audioSource = Instantiate(sfxPrefab, position, Quaternion.identity);

        audioSource.clip = clip;
        audioSource.Play();

        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
