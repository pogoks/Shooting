using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 4.0f;

    public GameObject explosionFactory;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.down;   // Vector3(0, 1, 0)
        transform.position = transform.position + dir * speed * Time.deltaTime;;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;

            PlayerMove player2 = GameObject.Find("Player").GetComponent<PlayerMove>();

            player2.nowHP = player2.nowHP - 40;
            player2.nowHpBar.fillAmount = (float)player2.nowHP / (float)player2.maxHP;
            Debug.Log(player2.nowHP);

            if (player2.nowHP <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(player2.hpBar.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
