using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSetting : MonoBehaviour
{
    private int spawnSetting = 0;
    public static SpawnSetting Value = null;

    private void Awake()
    {
        if(Value == null)
        {
            Value = this;
        }
    }

    public int Spawn
    {
        get
        {
            return spawnSetting;
        }
        set
        {
            spawnSetting = value;
        }
    }
}
