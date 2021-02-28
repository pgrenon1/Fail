using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [MinMaxSlider(-3f, 3f)]
    public Vector2 pitchMinMax = new Vector2(1f, 1f);
    public List<AudioClip> clips = new List<AudioClip>();

    public AudioSource AudioSource { get; set; }

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void Play(bool randomPitch = false, bool randomClip = false)
    {
        if (randomPitch)
            RandomizePitch();

        if (randomClip)
            AudioSource.clip = clips.GetRandomElement();

        AudioSource.Play();
    }

    private void RandomizePitch()
    {
        AudioSource.pitch = Random.Range(pitchMinMax.x, pitchMinMax.y);
    }
}
