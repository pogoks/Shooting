using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    public float speed = 2.0f;
    Vector3 dir;        // 방향
    public GameObject explosionFactory;
    public GameObject itemFactory1;
    public GameObject itemFactory2;
    public GameObject itemFactory3;

    public Image nowHpBar;
    public string enemyName;

    public int attackdamage;

    void OnEnable()     // 객체가 활성화 될 때마다 호출되는 함수    |    OnDisable = 비활성화 될 때
    {
        attackdamage = 0;

        int randValue = Random.Range(0, 10);        // 0~9까지 10개의 값 중 랜덤한 값
        if(randValue < 3)                           // 0, 1, 2 값이 나오면
        {
            //GameObject target = GameObject.Find("Player");      // 다른 프리팹의 정보를 찾아 가져옴
            // GameObject target = GameObject.FindGameObjectWithTag("Player");  이 방법을 더 많이 씀
            //dir = target.transform.position - transform.position;       // 타겟의 방향을 구한 후
            //dir.Normalize();        // 정규화

            dir = new Vector3(Random.Range(-2.59f, 2.5f), -6f, 0f);
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 dir = Vector3.down;
        transform.position += dir * speed * Time.deltaTime;
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

            attackdamage += 20;         // 총알 데미지

            // PlayerFire.cs 의 총알 오브젝트 풀 리스트 객체를 사용하기 위해 PlayerFire 클래스를 얻어오고
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

            // 다시 총알 추가해줌
            player.bulletObjectPool.Add(collision.gameObject);
        }
        else if (collision.gameObject.name.Equals("Player"))
        {
            PlayerMove player2 = GameObject.Find("Player").GetComponent<PlayerMove>();

            player2.nowHP = player2.nowHP - 50;
            player2.nowHpBar.fillAmount = (float)player2.nowHP / (float)player2.maxHP;
            Debug.Log(player2.nowHP);

            if(player2.nowHP <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(player2.hpBar.gameObject);
            }

            gameObject.SetActive(false);


            // 플레이어
            //Destroy(collision.gameObject);
        }

        if (attackdamage >= 100)
        {
            gameObject.SetActive(false);     // 자기 자신
            ScoreManager.Instance.Score++;

            // Destroy(gameObject);          
            // gameObject.SetActive(false);     // 자기 자신

            GameObject emObject = GameObject.Find("EnemyManager2");
            EnemyManager2 manager = emObject.GetComponent<EnemyManager2>();       // EnemyManager 클래스 얻어오기
            manager.enemyObjectPool.Add(gameObject);      // 리스트에 enemy 삽입

            if (dropitem <= 35)
            {
                if (random >= 0 && random <= 20)
                {
                    GameObject bulletPlus = Instantiate(itemFactory1);
                    bulletPlus.transform.position = transform.position;
                }
                else if (random >= 20 && random <= 90)
                {
                    GameObject heal = Instantiate(itemFactory2);
                    heal.transform.position = transform.position;
                }
                else if (random >= 90 && random <= 100)
                {
                    GameObject fast = Instantiate(itemFactory3);
                    fast.transform.position = transform.position;
                }
            }
        }

        // 1번 방식 (직관적)
        /*
        GameObject smObject = GameObject.Find("ScoreManager");      // Hierarchy 안에 있는 오브젝트를 찾는다.
        ScoreManager sm = smObject.GetComponent<ScoreManager>();    // 오브젝트에 있는 컴포넌트를 찾는다, 즉 스크립트를 찾음

        sm.SetScore(sm.GetScore() + 1);
        */


        // 2번 방식 (싱글톤)
        /*
        ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);
        // Instance가 싱글톤 객체임.
        */


        // 3번 방식 (프로퍼티)
        // ScoreManager.Instance.Score++;      // 싱글톤 객체의 Score 프로퍼티 호출
                                            // 값을 바꿀 용도로 사용했기 때문에 set을 사용
    }
}
