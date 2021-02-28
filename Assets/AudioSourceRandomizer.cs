using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceRandomizer : MonoBehaviour
{
    [MinMaxSlider(-3f, 3f)]
    public Vector2 pitchMinMax;
    public List<AudioClip> clips = new List<AudioClip>();

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        RandomizeClip();
    }

    private void RandomizeClip()
    {
        _audioSource.clip = clips.GetRandomElement();

        _audioSource.pitch = Random.Range(pitchMinMax.x, pitchMinMax.y);
    }
}
