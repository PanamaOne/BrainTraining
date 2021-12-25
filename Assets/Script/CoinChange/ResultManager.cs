using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    float time = 0.0f;
    int missCount = 0;
    const int penaltyTime = 30;
    AudioClip toTitleSE;

    // Start is called before the first frame update
    void Start()
    {
        GameObject questionObj = GameObject.Find("QuestionManager");
        if(questionObj != null)
        {
            QuestionManager inst = questionObj.GetComponent<QuestionManager>();
            time = inst.currentTime;
            missCount = inst.missCount;
            Destroy(questionObj);
            ShowResult();
        }
        else
        {
            // ‚±‚±‚É—ˆ‚½‚ç‚¨‚©‚µ‚¢
        }

        toTitleSE = Resources.Load<AudioClip>("Click");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowResult()
    {
        GameObject timeTextObj = GameObject.Find("TimeText");
        Text timeText = timeTextObj.GetComponent<Text>();
        timeText.text = "Time : " + time.ToString();
        GameObject missCountObj = GameObject.Find("MissText");
        Text missCountText = missCountObj.GetComponent<Text>();
        missCountText.text = "Miss : " + missCount.ToString();
        GameObject FinalResultObj = GameObject.Find("FinalResultText");
        Text FinalResult = FinalResultObj.GetComponent<Text>();
        float resultNum = time + missCount * penaltyTime;
        FinalResult.text = resultNum.ToString();
    }

    public void BatckToTitle()
    {
        SceneManager.LoadScene("Title");
        GameObject audioObj = GameObject.Find("AudioManager");
        AudioManager audioSource = audioObj.GetComponent<AudioManager>();
        audioSource.PlayClip(toTitleSE);
    }
}
