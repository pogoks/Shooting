using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class StartStage1 : MonoBehaviour
{
    public bool Started = false;
    public GUISkin mySkin;

    public GameObject player;

    void Awake()
    {
        Time.timeScale = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
    }


    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, 640, 960));

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();

        GUI.skin = mySkin;

        GUILayout.Label("STAGE 1");

        GUILayout.Space(20);

        if(GUILayout.Button("START"))
        {
            Started = true;
            StartGame();

            Destroy(this);
        }

        GUILayout.EndVertical();
        GUILayout.FlexibleSpace();

        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();

        GUILayout.EndArea();
    }

    void StartGame()
    {
        Time.timeScale = 1f;

        player.SetActive(true);
    }
}
