using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager1 : MonoBehaviour
{
    public GameObject bossFactory;

    public Transform Target;
    public float speed = 1.0f;

    public float minTime = 1;
    public float maxTime = 5;

    public int spawnCount;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (StageManager.Value.Stage == 1 && ScoreManager.Instance.Score == 30) // 50
        {
            spawnCount++;

            if (spawnCount == 1)
            {
                SpawnSetting.Value.Spawn++;

                GameObject boss = Instantiate(bossFactory);
                boss.transform.position = bossFactory.transform.position;
            }
        }
    }
}
