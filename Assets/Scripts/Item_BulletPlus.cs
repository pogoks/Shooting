using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_BulletPlus : MonoBehaviour
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
        PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
        GameObject bullet = Instantiate(player.bulletFactory);
        player.bulletObjectPool.Add(bullet);
        bullet.SetActive(false);

        Destroy(gameObject);
    }
}
