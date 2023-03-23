using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Fire : MonoBehaviour
{
    private const float DISTANCE_RECOG = 10f;

    public GameObject EnemybulletFactory1;
    public GameObject EnemybulletFactory2;
    public GameObject EnemybulletFactory3;
    public GameObject firePosition1;
    public GameObject firePosition2;
    public GameObject firePosition3;

    private float makeTime = 1.5f;
    private float tickTime;

    void Update()
    {
        if (GameObject.Find("Player"))
        {
            int random = Random.Range(0, 3);

            PlayerMove player = GameObject.Find("Player").GetComponent<PlayerMove>();

            tickTime += Time.deltaTime;

            if (Mathf.Abs(transform.position.y - player.transform.position.y) < DISTANCE_RECOG)
            {
                if (tickTime >= makeTime)
                {
                    GameObject Enemybullet1 = Instantiate(EnemybulletFactory1);
                    GameObject Enemybullet2 = Instantiate(EnemybulletFactory2);
                    GameObject Enemybullet3 = Instantiate(EnemybulletFactory3);
                    Enemybullet1.transform.position = firePosition1.transform.position;
                    Enemybullet2.transform.position = firePosition2.transform.position;
                    Enemybullet3.transform.position = firePosition3.transform.position;
                    tickTime = 0f;
                }
            }
        }
        else
        {

        }
    }
}
