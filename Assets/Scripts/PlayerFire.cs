using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // public 을 주면 유니티 화면에 나타난다
    public GameObject bulletFactory;    // 총알 프리팹
    public GameObject firePosition;     // 발사 위치

    public int poolSize;

    // GameObject[] bulletObjectPool; 배열방식
    public List<GameObject> bulletObjectPool;       // 총알 오브젝트 풀 배열을 리스트 방식으로 함

    // Start is called before the first frame update
    void OnEnable()
    {
        poolSize = 2;

        // bulletObjectPool = new GameObject[poolSize];        // 오브젝트 풀 생성, 배열 방식
        bulletObjectPool = new List<GameObject>();          // 오브젝트 풀 생성, 리스트 방식
        for(int i = 0; i < poolSize; i++)       
        {
            GameObject bullet = Instantiate(bulletFactory);     // 오브젝트 풀에 등록할 총알 생성
            //bulletObjectPool[i] = bullet;       // 오브젝트 풀에 등록, 배열 방식
            bulletObjectPool.Add(bullet);       // 오브젝트 풀에 등록, 리스트 방식
            bullet.SetActive(false);            // 비활성화
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))    // 마우스 왼쪽 클릭 시
        {
            if(bulletObjectPool.Count > 0)      // 오브젝트 풀에 총알이 있다면
            {
                GameObject bullet = bulletObjectPool[0]; // 비활성화 된 총알을 하나 가져옴
                bulletObjectPool.Remove(bullet);    // 오브젝트 풀에서 제거한다.
                bullet.transform.position = firePosition.transform.position;     // 총알을 위치시킴
                bullet.SetActive(true);     // 활성화 시키고
            }


            /*
            for(int i = 0; i < poolSize; i++)
            {
                GameObject bullet = bulletObjectPool[i];
                if (bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = transform.position;
                    break;
                }
            }
            */


            // 기초적인 버전
            /*
            GameObject bullet = Instantiate(bulletFactory);     // 총알 생성
            bullet.transform.position = firePosition.transform.position;    // 총알 위치
            */
        }
    }
}
