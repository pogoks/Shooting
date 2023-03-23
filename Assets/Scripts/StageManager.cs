using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private int nowStage = 1;

    public static StageManager Value = null;

    private void Awake()
    {
        if(Value == null)
        {
            Value = this;
        }
    }

    public int Stage
    {
        get
        {
            return nowStage;
        }
        set
        {
            nowStage = value;
        }
    }
}
