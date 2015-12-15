using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SizeTextUpdater : MonoBehaviour {
    public PlayerLogic playerLogic;

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Size: " + playerLogic.size;
	}
}
