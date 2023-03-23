using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //   Destroy(other.gameObject);
        if (other.gameObject.name.Equals("Bullet(Clone)") || other.gameObject.name.Equals("Enemy(Clone)") 
            || other.gameObject.name.Equals("Enemy2(Clone)") || other.gameObject.name.Equals("Enemy3(Clone)") 
            || other.gameObject.name.Equals("Enemy4_Attack(Clone)") || other.gameObject.name.Equals("Enemy5(Clone)"))        // 총알이나 적이랑 충돌 시
        {
            other.gameObject.SetActive(false);      // 비활성화

            if (other.gameObject.name.Equals("Bullet(Clone)"))        // 부딫힌게 총알이라면
            {
                // PlayerFire.cs 의 총알 오브젝트 풀 리스트 객체를 사용하기 위해 PlayerFire 클래스를 얻어오고
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
                // 다시 총알 추가해줌
                player.bulletObjectPool.Add(other.gameObject);
            }
            else if (other.gameObject.name.Equals("Enemy(Clone)")) 
            {
                GameObject emObject = GameObject.Find("EnemyManager1");
                EnemyManager1 manager = emObject.GetComponent<EnemyManager1>();       // EnemyManager 클래스 얻어오기
                manager.enemyObjectPool.Add(other.gameObject);      // 리스트에 enemy 삽입
            }
            else if (other.gameObject.name.Equals("Enemy2(Clone)"))
            {
                GameObject emObject = GameObject.Find("EnemyManager2");
                EnemyManager2 manager = emObject.GetComponent<EnemyManager2>();       // EnemyManager 클래스 얻어오기
                manager.enemyObjectPool.Add(other.gameObject);      // 리스트에 enemy 삽입
            }
            else if (other.gameObject.name.Equals("Enemy3(Clone)"))
            {
                GameObject emObject = GameObject.Find("EnemyManager3");
                EnemyManager3 manager = emObject.GetComponent<EnemyManager3>();       // EnemyManager 클래스 얻어오기
                manager.enemyObjectPool.Add(other.gameObject);      // 리스트에 enemy 삽입
            }
            else if (other.gameObject.name.Equals("Enemy4_Attack(Clone)"))
            {
                GameObject emObject = GameObject.Find("EnemyManager4");
                EnemyManager4 manager = emObject.GetComponent<EnemyManager4>();       // EnemyManager 클래스 얻어오기
                manager.enemyObjectPool.Add(other.gameObject);      // 리스트에 enemy 삽입
            }
            else if (other.gameObject.name.Equals("Enemy5(Clone)"))
            {
                GameObject emObject = GameObject.Find("EnemyManager5");
                EnemyManager5 manager = emObject.GetComponent<EnemyManager5>();       // EnemyManager 클래스 얻어오기
                manager.enemyObjectPool.Add(other.gameObject);      // 리스트에 enemy 삽입
            }
        }

        if (other.gameObject.name.Contains("Item") || other.gameObject.name.Contains("meAttack"))
        {
            Destroy(other.gameObject);
        }
    }
}