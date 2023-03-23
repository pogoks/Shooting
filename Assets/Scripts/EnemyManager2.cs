using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager2 : MonoBehaviour
{
    float currentTime;      // 시간을 재기 위한 현재 시간
    public float createTime;

    public GameObject enemyFactory;     // Enemy 프리팹

    public float minTime = 1;
    public float maxTime = 5;

    public int poolSize = 15;       //   Enemy 오브젝트 풀 사이즈

    // GameObject[] enemyObjectPool;   // Enemy 오브젝트 풀, 배열 방식

    public List<GameObject> enemyObjectPool;      //Enemy 오브젝트 풀, 리스트 방식
    public Transform[] spawnPoints; // SpawnPoint 들

    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(1.0f, 5.0f);
        // enemyObjectPool[i] = enemy; 
        enemyObjectPool = new List<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            //GameObject enemy = Instantiate(enemyFactory);        // enemy 오브젝트 풀에 에너미 생성
            // enemyObjectPool[i] = enemy;   배열 방식
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectPool.Add(enemy);     // 리스트 방식
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;     // 시간을 누적
        //print("현재시간 : " + currentTime + " 생성시간 : " + createTime);

        if (StageManager.Value.Stage >= 1 && StageManager.Value.Stage <= 3 && SpawnSetting.Value.Spawn == 0)
        {

            if (currentTime > createTime)
            {
                if (enemyObjectPool.Count > 0)   // 오브젝트 풀에 Enemy가 있다면
                {
                    GameObject enemy = enemyObjectPool[0];      // 오브젝트 풀에서 Enemy를 가져다 사용함.
                    enemyObjectPool.Remove(enemy);      // 오브젝트 풀에서 Enemy 제거

                    enemy.SetActive(true);                // Enemy 활성화
                    int index = Random.Range(0, spawnPoints.Length);    // 랜덤으로 인덱스 선택
                    enemy.transform.position = spawnPoints[index].position;     // Enemy 위치시키기
                }

                /*  // 오브젝트 풀을 배열로 사용할 때 코드입니다.
                for(int i = 0; i < poolSize; i++)
                {
                    GameObject enemy = enemyObjectPool[i];

                    if (enemy.activeSelf == false)       // 오브젝트 풀을 돌며 비활성화를 활성화로 바꿔줌
                    {
                        // enemy.transform.position = transform.position;      // Enemy 좌표 설정
                        enemy.SetActive(true);
                        int index = Random.Range(0, spawnPoints.Length);
                        enemy.transform.position = spawnPoints[index].position;
                        break;
                    }   
                }
                */

                currentTime = 0;        // 시간을 다시 0으로 초기화
                createTime = Random.Range(minTime, maxTime);

                // Debug.Log("랜덤한 시간 : " + createTime);
                //  print("랜덤한 시간 : " +  createTime);
            }
        }

        /*
        GameObject enemy = Instantiate(enemyFactory);        // Enemy 생성
        enemy.transform.position = transform.position;      // Enemy 좌표 설정
        currentTime = 0;        // 시간을 다시 0으로 초기화
        createTime = Random.Range(minTime, maxTime);
        */

    }
}