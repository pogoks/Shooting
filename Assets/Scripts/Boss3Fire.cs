using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Fire : MonoBehaviour
{
    private const float DISTANCE_RECOG = 10f;

    public GameObject EnemybulletFactory1;
    public GameObject EnemybulletFactory2;
    public GameObject EnemybulletFactory3;
    public GameObject EnemybulletFactory4;
    public GameObject EnemybulletFactory5;
    public GameObject EnemybulletFactory6;
    public GameObject EnemybulletFactory7;
    public GameObject firePosition1;
    public GameObject firePosition2;
    public GameObject firePosition3;
    public GameObject firePosition4;
    public GameObject firePosition5;
    public GameObject firePosition6;
    public GameObject firePosition7;

    private float makeTime = 1.0f;
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
                    GameObject Enemybullet4 = Instantiate(EnemybulletFactory4);
                    GameObject Enemybullet5 = Instantiate(EnemybulletFactory5);
                    GameObject Enemybullet6 = Instantiate(EnemybulletFactory6);
                    GameObject Enemybullet7 = Instantiate(EnemybulletFactory7);
                    Enemybullet1.transform.position = firePosition1.transform.position;
                    Enemybullet2.transform.position = firePosition2.transform.position;
                    Enemybullet3.transform.position = firePosition3.transform.position;
                    Enemybullet4.transform.position = firePosition4.transform.position;
                    Enemybullet5.transform.position = firePosition5.transform.position;
                    Enemybullet6.transform.position = firePosition6.transform.position;
                    Enemybullet7.transform.position = firePosition7.transform.position;
                    tickTime = 0f;
                }
            }
        }
        else
        {

        }
    }
}
