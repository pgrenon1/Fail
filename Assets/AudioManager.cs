using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : OdinSerializedSingletonBehaviour<AudioManager>
{
    public Sound sfxPrefab;

    public void PlaySFX(AudioClip clip, Vector3 position)
    {
        if (!clip)
            return;

        Sound sound = Instantiate(sfxPrefab, position, Quaternion.identity);

        sound.AudioSource.clip = clip;
        sound.Play();

        Destroy(sound.gameObject, clip.length);
    }
}
