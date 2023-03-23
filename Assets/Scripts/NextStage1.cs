using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage1 : MonoBehaviour
{
    public int attackdamage;

    public GameObject stageFactory;

    void OnEnable()
    {
        attackdamage = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Bullet(Clone)"))        // 부딫힌게 Bullet 이라면
        {
            collision.gameObject.SetActive(false);

            attackdamage += 20;

            // PlayerFire.cs 의 총알 오브젝트 풀 리스트 객체를 사용하기 위해 PlayerFire 클래스를 얻어오고
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

            // 다시 총알 추가해줌
            player.bulletObjectPool.Add(collision.gameObject);
        }

        if (attackdamage >= 100)
        {
            gameObject.SetActive(false);

            StageManager.Value.Stage++;
            Debug.Log(StageManager.Value.Stage);

            GameObject stage2 = Instantiate(stageFactory);
            stage2.transform.position = stageFactory.transform.position;
        }
    }
}
