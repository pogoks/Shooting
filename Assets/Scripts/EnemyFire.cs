using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    private const float DISTANCE_RECOG = 7f;

    public GameObject EnemybulletFactory;
    public GameObject firePosition;

    private float makeTime = 2f;
    private float tickTime;

    void Update()
    {
        if (GameObject.Find("Player"))
        {
            PlayerMove player = GameObject.Find("Player").GetComponent<PlayerMove>();

            tickTime += Time.deltaTime;

            if (Mathf.Abs(transform.position.y - player.transform.position.y) < DISTANCE_RECOG)
            {
                if (tickTime >= makeTime)
                {
                    GameObject Enemybullet = Instantiate(EnemybulletFactory);
                    Enemybullet.transform.position = firePosition.transform.position;

                    tickTime = 0f;
                }
            }
        }
        else
        {
            
        }
    }
}
