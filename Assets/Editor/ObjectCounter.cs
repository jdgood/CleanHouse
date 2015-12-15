using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/* Keeps a count of the objects in the scene can be extended to help with balancing if we expect a certain ratio of objects in the scene */
public class ObjectCounter : EditorWindow
{
    private Dictionary<string, int> sets = new Dictionary<string,int>();
    private Vector2 scrollPosition;

    [MenuItem("Tools/Object Counter")]
    public static void Launch()
    {
        EditorWindow window = GetWindow(typeof(ObjectCounter));
        window.Show();
    }

    //Counts the objects in the scene
    public void UpdateList()
    {
        Object[] objects;
        sets.Clear();
        objects = FindObjectsOfType(typeof(LegoController));

        foreach (Component component in objects)
        {
            string lego = component.gameObject.name;
            lego = lego.Split(' ')[0];
            if (!sets.ContainsKey(lego))
            {
                sets[lego] = 0;
            }
            sets[lego] = (int)sets[lego] + 1;
        }
    }

    //Update the gui
    public void OnGUI()
    {
        GUILayout.BeginHorizontal(GUI.skin.GetStyle("Box"));
        GUILayout.Label("Pickupable items in scene:");
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Refresh"))
        {
            UpdateList();
        }
        GUILayout.EndHorizontal();

        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        foreach (string type in sets.Keys)
        {
            GUILayout.Label(type + ":" + sets[type]);
        }
        GUILayout.EndScrollView();
    }
}