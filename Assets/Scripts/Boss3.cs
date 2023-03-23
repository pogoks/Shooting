using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    public float speed = 1.0f;
    Vector3 dir;        // 방향

    public Transform Target;

    public GameObject stageFactory;

    public GameObject explosionFactory;
    public GameObject itemFactory1;
    public GameObject itemFactory2;
    public GameObject itemFactory3;

    public int attackdamage;

    void OnEnable()     // 객체가 활성화 될 때마다 호출되는 함수    |    OnDisable = 비활성화 될 때
    {
        attackdamage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        int dropitem = Random.Range(1, 100);
        int random = Random.Range(1, 100);


        if (collision.gameObject.name.Equals("Bullet(Clone)"))        // 부딫힌게 Bullet 이라면
        {
            collision.gameObject.SetActive(false);

            attackdamage += 20;

            // PlayerFire.cs 의 총알 오브젝트 풀 리스트 객체를 사용하기 위해 PlayerFire 클래스를 얻어오고
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

            // 다시 총알 추가해줌
            player.bulletObjectPool.Add(collision.gameObject);
        }
        else if (collision.gameObject.name.Equals("Player"))
        {
            PlayerMove player2 = GameObject.Find("Player").GetComponent<PlayerMove>();

            player2.nowHP = player2.nowHP - 100;
            player2.nowHpBar.fillAmount = (float)player2.nowHP / (float)player2.maxHP;
            Debug.Log(player2.nowHP);

            if (player2.nowHP <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(player2.hpBar.gameObject);
            }

            // 플레이어
            //Destroy(collision.gameObject);
        }

        if (attackdamage >= 3500)
        {
            gameObject.SetActive(false);     // 자기 자신
            ScoreManager.Instance.Score = ScoreManager.Instance.Score + 50;
            Debug.Log(ScoreManager.Instance.Score);

            // Destroy(gameObject);          
            // gameObject.SetActive(false);     // 자기 자신

            if (dropitem <= 100)
            {
                GameObject bulletPlus = Instantiate(itemFactory1);
                bulletPlus.transform.position = transform.position;

                GameObject heal = Instantiate(itemFactory2);
                heal.transform.position = transform.position;

                GameObject fast = Instantiate(itemFactory3);
                fast.transform.position = transform.position;
            }

            SpawnSetting.Value.Spawn--;

            StageManager.Value.Stage++;
            Debug.Log(StageManager.Value.Stage);

            GameObject stageover = Instantiate(stageFactory);
            stageover.transform.position = stageFactory.transform.position;
        }
    }
}
