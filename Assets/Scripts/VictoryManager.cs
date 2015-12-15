using UnityEngine;
using UnityEngine.SceneManagement;

/* Handles the win condition, checks if there are no more legos in the map that aren't attached to the player */
public class VictoryManager : MonoBehaviour
{
    public float restartTimer = 5f;
    public static bool winner = false;

    GameObject pickups;
    Animator anim;
    
    void Start()
    {
        pickups = GameObject.FindGameObjectWithTag("Pickupable");
        anim = GetComponent<Animator>();
    }

    // Check if win condition is met. If game is won then wait for the restart timer to restart the game. Also set the winner flag to enable awesome music!
    void Update()
    {
        LegoController[] children = pickups.GetComponentsInChildren<LegoController>();

        if(children.Length == 0)
        {
            anim.SetTrigger("Win");
            restartTimer -= Time.deltaTime;
            winner = true;

            if(restartTimer < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
