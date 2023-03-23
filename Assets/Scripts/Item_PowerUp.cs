using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_PowerUp : MonoBehaviour
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
        PlayerMove player = GameObject.Find("Player").GetComponent<PlayerMove>();
        player.speed = player.speed + 1.0f;

        if (player.speed > 6.0f)
        {
            player.speed = 6.0f;
        }

        Destroy(gameObject);
    }
}
