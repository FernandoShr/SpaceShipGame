using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaFundo;
    public AudioSource audioSourceSFX;
    public AudioClip[] musicasFundo;

    // Start is called before the first frame update
    void Start()
    {
        int indexMusica = Random.Range(0, musicasFundo.Length);
        AudioClip musicaFundoFase = musicasFundo[indexMusica];
        audioSourceMusicaFundo.clip = musicaFundoFase;
        audioSourceMusicaFundo.loop = true;
        audioSourceMusicaFundo.Play();
    }

    public void ToqueSFX(AudioClip clip)
    {
        audioSourceSFX.PlayOneShot(clip);
    }

    public void PauseToqueSFX()
    {
        audioSourceSFX.Pause();
    }
}
