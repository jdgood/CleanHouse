using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class VictoryManager : MonoBehaviour
{
    public float restartTimer = 5f;
    public static bool winner = false;

    GameObject pickups;
    Animator anim;
    Text text;

    // Use this for initialization
    void Start()
    {
        pickups = GameObject.FindGameObjectWithTag("Pickupable");
        text = GetComponent<Text>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LegoController[] children = pickups.GetComponentsInChildren<LegoController>();

        if (children.Length == 0)
        {
            anim.SetTrigger("Win");
            restartTimer -= Time.deltaTime;
            winner = true;

            if (restartTimer < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
