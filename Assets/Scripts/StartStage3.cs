using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStage3 : MonoBehaviour
{
    public bool Started = false;
    public GUISkin mySkin;

    void Awake()
    {
        Time.timeScale = 0f;
    }


    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, 640, 960));

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();

        GUI.skin = mySkin;

        GUILayout.Label("STAGE 3");

        GUILayout.Space(20);

        //GUILayout.Label("PRESS Start");

        if (GUILayout.Button("START"))
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
    }
}
