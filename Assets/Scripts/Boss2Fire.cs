using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Fire : MonoBehaviour
{
    private const float DISTANCE_RECOG = 10f;

    public GameObject EnemybulletFactory;
    public GameObject firePosition1;
    public GameObject firePosition2;
    public GameObject firePosition3;
    public GameObject firePosition4;
    public GameObject firePosition5;

    private float makeTime = 0.5f;
    private float tickTime;

    void Update()
    {
        if (GameObject.Find("Player"))
        {
            int random = Random.Range(0, 5);

            PlayerMove player = GameObject.Find("Player").GetComponent<PlayerMove>();

            tickTime += Time.deltaTime;

            if (Mathf.Abs(transform.position.y - player.transform.position.y) < DISTANCE_RECOG)
            {
                if (tickTime >= makeTime)
                {
                    GameObject Enemybullet = Instantiate(EnemybulletFactory);

                    if (random == 0)
                    {
                        Enemybullet.transform.position = firePosition1.transform.position;
                    }
                    else if(random == 1)
                    {
                        Enemybullet.transform.position = firePosition2.transform.position;
                    }
                    else if(random == 2)
                    {
                        Enemybullet.transform.position = firePosition3.transform.position;
                    }
                    else if (random == 3)
                    {
                        Enemybullet.transform.position = firePosition4.transform.position;
                    }
                    else if (random == 4)
                    {
                        Enemybullet.transform.position = firePosition5.transform.position;
                    }

                    tickTime = 0f;
                }
            }
        }
        else
        {

        }
    }
}
