using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Updates the timer in the UI and will fire off the lose condition if time runs out. */
public class TimeManager : MonoBehaviour
{
    public float gameTime = 10f;
    public float restartTimer = 5f;
    public Animator anim;

    Text text;
    
	void Start()
    {
        text = GetComponent<Text>();
	}
	
	// Update timer and check if game is lost. If game is lost then wait for the restart timer to restart the game
	void Update()
    {
        gameTime -= Time.deltaTime;
        text.text = "Time Remaining: " + ((int)gameTime);

        if(gameTime < 0)
        {
            anim.SetTrigger("Lose");
            restartTimer -= Time.deltaTime;

            if(restartTimer < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
