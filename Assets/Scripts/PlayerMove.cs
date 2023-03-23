using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject prfHpBar;
    public GameObject canvas;

    public RectTransform hpBar;

    public int maxHP;
    public int nowHP;

    public Image nowHpBar;

    private void Start()
    {
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();

        maxHP = 100;
        nowHP = 100;

        nowHpBar = hpBar.transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraLimit();
        HPbar();

        //nowHpBar.fillAmount = (float)nowHP / (float)maxHP;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // print("h의 값 : " + h + " v의 값 : " + v);

        // Vector3 dir = Vector3.right * h + Vector3.up * v;
        Vector3 dir = new Vector3(h, v, 0);
        // transform.Translate(dir * speed * Time.deltaTime);

        // P = P0 + vt (미래위치 = 현재위치 + 속도 x 시간)
        transform.position = transform.position + dir * speed * Time.deltaTime;
    }

    
    // 메인화면 밖으로 나가지 못하게 하는 함수
    void CameraLimit()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }


    // 체력 바
    void HPbar()
    {
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + -0.8f, 0));
        hpBar.position = _hpBarPos;

        // m_hp.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -0.6f, 0));
    }
}
