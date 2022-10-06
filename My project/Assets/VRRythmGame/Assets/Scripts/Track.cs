using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public SongData song;
    public AudioSource audioSource;

    void Start ()
    {
        transform.position = Vector3.forward * (song.speed * GameManager.instance.startTime);
        Invoke("StartSong", GameManager.instance.startTime - song.startTime);
    }

    // called when we want the song to start playing
    void StartSong ()
    {
        audioSource.PlayOneShot(song.song);
        Invoke("SongIsOver", song.song.length);
    }

    void Update ()
    {
        transform.position += Vector3.back * song.speed * Time.deltaTime;
    }

    // called when the song ends
    void SongIsOver ()
    {
        GameManager.instance.WinGame();
    }

    void OnDrawGizmos ()
    {
        for(int i = 0; i < 100; i++)
        {
            float beatLength = 60.0f / (float)song.bpm;
            float beatDist = beatLength * song.speed;

            Gizmos.DrawLine(transform.position + new Vector3(-1, 0, i * beatDist), transform.position + new Vector3(1, 0, i * beatDist));
        }
    }
}