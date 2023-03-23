using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;     // 현재 점수 Text 오브젝트
    private float currentScore;        // 현재 점수 score

    public Text bestScoreUI;        // 최고 점수 Text 오브젝트
    private float bestScore;           // 최고 점수 score

    // 자기 자신을 인스턴스로 정적변수로 만든다. 
    public static ScoreManager Instance = null;     // 싱글톤 

    public void Awake()
    {
        if(Instance == null)        // 싱글톤 객체 값이 없으면
        {
            Instance = this;        // 자기 자신을 할당
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetFloat("Best Score", 0);        // 뒤의 0은 불러들이는 값이 없다면 0으로 초기화한다 라는 의미이다.
        bestScoreUI.text = "최고점수 : " + bestScore;
    }

    public float Score        // 프로퍼티
    {
        get 
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            currentScoreUI.text = "현재점수 : " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "최고점수 : " + bestScore;
                PlayerPrefs.SetFloat("Best Score", bestScore);
            }
        }
    }


    // 프로퍼티 사용 전
    /*
    public void SetScore(int value)
    {
        currentScore = value;
        currentScoreUI.text = "현재점수 : " + currentScore;

        if(currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "최고점수 : " + bestScore;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }

    public int GetScore()
    {
        return currentScore;
    }
    */
}
