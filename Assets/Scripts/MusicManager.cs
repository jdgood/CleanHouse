using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
    public AudioSource bonus;

    AudioSource music;

    // Use this for initialization
    void Start () {
        music = GetComponent<AudioSource>();
        if (VictoryManager.winner)
        {
            bonus.Play();
        }
        else
        {
            music.time = 9;
            music.Play();
        }

        
	}
	
	// Update is called once per frame
	void Update () {
	    if(!VictoryManager.winner && music.time > 80)
        {
            music.Stop();
            music.time = 9;
            music.Play();
        }
	}
}
