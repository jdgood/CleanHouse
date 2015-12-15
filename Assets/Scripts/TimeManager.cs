using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimeManager : MonoBehaviour {
    public float gameTime = 10f;
    public float restartTimer = 5f;
    public Animator anim;

    Text text;
    

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        gameTime -= Time.deltaTime;
        text.text = "Time Remaining: " + ((int)gameTime);

        if(gameTime < 0)
        {
            anim.SetTrigger("Lose");
            restartTimer -= Time.deltaTime;

            if(restartTimer < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
