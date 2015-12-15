using UnityEngine;

/* Handles the music in the game */
public class MusicManager : MonoBehaviour
{
    public AudioSource bonus;

    AudioSource music;

    //Starts the party
    void Start()
    {
        music = GetComponent<AudioSource>();
        //Easter egg song if you complete the game
        if(VictoryManager.winner)
        {
            bonus.Play();
        }
        else
        {
            //Start song at 8 seconds due to some silence and lack of audio editing software
            music.time = 9;
            music.Play();
        }

        
	}

    //Forcing a loop after 80 seconds due to silence at end of song and lack of audio editing software 
    void Update()
    {
	    if(!VictoryManager.winner && music.time > 80)
        {
            music.Stop();
            music.time = 9;
            music.Play();
        }
	}
}
