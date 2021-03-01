using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : OdinSerializedSingletonBehaviour<AudioManager>
{
    public AudioSource musicSource;
    public AudioClip menuMusic;
    public AudioClip levelMusic;
    public Sound sfxPrefab;

    protected override void Awake()
    {
        base.Awake();

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (FindObjectOfType<Level>())
        {
            GetComponent<AudioListener>().enabled = false;
            musicSource.clip = levelMusic;
            musicSource.Play();
        }
        else if (Index.Instance.SceneIndex.GameMenuSceneBuildIndex == scene.buildIndex)
        {
            GetComponent<AudioListener>().enabled = true;
            musicSource.clip = menuMusic;
            musicSource.Play();
        }
    }

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
