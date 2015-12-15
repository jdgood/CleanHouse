using UnityEngine;
using UnityEngine.UI;

/* Updates the UI based on the spheres current size */ 
public class SizeTextUpdater : MonoBehaviour
{
    public PlayerLogic playerLogic;

    Text text;
    
	void Start()
    {
        text = GetComponent<Text>();
	}
	
	void Update()
    {
        text.text = "Size: " + playerLogic.size;
	}
}
