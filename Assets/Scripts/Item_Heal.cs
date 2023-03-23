using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Heal : MonoBehaviour
{
    public float speed = 1.0f;
    Vector3 dir;

    // Start is called before the first frame update
    void OnEnable()
    {
        dir = Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerMove player2 = GameObject.Find("Player").GetComponent<PlayerMove>();
        player2.nowHP = player2.nowHP + 25;

        if(player2.nowHP > player2.maxHP)
        {
            player2.nowHP = 100;
        }

        player2.nowHpBar.fillAmount = (float)player2.nowHP / (float)player2.maxHP;
        Debug.Log(player2.nowHP);

        Destroy(gameObject);
    }
}
