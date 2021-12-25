using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;

    const int MaxQuestionNum = 10;
    int currentQuestionNum = 0;
    public int currentPrice = 0;
    public bool bIsActive = false;  // false:操作不可
    public int missCount = 0;  // 間違った問題数
    public float currentTime = 0.0f;
    float maxTime = 3600.0f;
    [SerializeField] public GameObject canvas;
    [SerializeField] public CSVReader csvReader;
    public AudioSource audioSource;
    AudioClip audioClipSeikai;
    AudioClip audioClipBatsu;
    public AudioClip audioClipClick;
    AudioClip audioClipFinish;
    AudioClip audioClipCancel;
    public int pushCount1 = 0;
    public int pushCount5 = 0;
    public int pushCount10 = 0;
    public int pushCount50 = 0;
    public int pushCount100 = 0;
    public int pushCount500 = 0;
    public int pushCount1000 = 0;
    public int pushCount2000 = 0;
    public int pushCount5000 = 0;
    public int pushCount10000 = 0;

    public struct QuestionData
    {
        public int questionNum;
        public int Price;
        public int Money1Num;
        public int Money5Num;
        public int Money10Num;
        public int Money50Num;
        public int Money100Num;
        public int Money500Num;
        public int Money1000Num;
        public int Money2000Num;
        public int Money5000Num;
        public int Money10000Num;
        public int Answer;
    };

    // 後でマスターデータ化する
    QuestionData[] questionData;

    // Start is called before the first frame update
    void Start()
    {
        //if(instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}

        GameObject audioObj = GameObject.Find("AudioManager");
        audioSource = audioObj.GetComponent<AudioSource>();

        LoadSoundData();
        InitQuestion();
        DispQuestion(0);

        GameObject titleObj = GameObject.Find("TitleManager");
        Destroy(titleObj);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
        }
    }

    void LoadSoundData()
    {
        audioClipSeikai = Resources.Load<AudioClip>("Seikai");
        audioClipBatsu = Resources.Load<AudioClip>("Batsu");
        audioClipClick = Resources.Load<AudioClip>("Click");
        audioClipFinish = Resources.Load<AudioClip>("Finish");
        audioClipCancel = Resources.Load<AudioClip>("Cancel");
    }

    void InitQuestion()
    {
        questionData = new QuestionData[MaxQuestionNum];

        for(int index = 0;index < MaxQuestionNum; ++index)
        {
            List<string[]> candidates = csvReader.csvDatas.FindAll(n => n[0] == index.ToString());
            UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
            int rand = UnityEngine.Random.Range(0, candidates.Count);
            questionData[index].questionNum = index;
            questionData[index].Price = Int32.Parse(candidates[rand][1]);
            questionData[index].Money1Num = Int32.Parse(candidates[rand][2]);
            questionData[index].Money5Num = Int32.Parse(candidates[rand][3]);
            questionData[index].Money10Num = Int32.Parse(candidates[rand][4]);
            questionData[index].Money50Num = Int32.Parse(candidates[rand][5]);
            questionData[index].Money100Num = Int32.Parse(candidates[rand][6]);
            questionData[index].Money500Num = Int32.Parse(candidates[rand][7]);
            questionData[index].Money1000Num = Int32.Parse(candidates[rand][8]);
            questionData[index].Money2000Num = Int32.Parse(candidates[rand][9]);
            questionData[index].Money5000Num = Int32.Parse(candidates[rand][10]);
            questionData[index].Money10000Num = Int32.Parse(candidates[rand][11]);
            questionData[index].Answer = Int32.Parse(candidates[rand][12]);
        }
    }

    void DispQuestion(int questionNum)
    {
        CoinManager.CreateQuestionMoney(questionData[questionNum], canvas);
        GameObject questionText = GameObject.Find("QuestionPriceText");
        Text text = questionText.GetComponent<Text>();
        text.text = "￥";
        text.text += questionData[questionNum].Price.ToString();
        bIsActive = true;
    }

    public void ResetPushCount()
    {
        pushCount1 = 0;
        pushCount5 = 0;
        pushCount10 = 0;
        pushCount50 = 0;
        pushCount100 = 0;
        pushCount500 = 0;
        pushCount1000 = 0;
        pushCount2000 = 0;
        pushCount5000 = 0;
        pushCount10000 = 0;
    }

    public void ClearCloneAnswerMoney()
    {
        var money = GameObject.FindGameObjectsWithTag("CloneAnswer");
        foreach(var clone in money)
        {
            Destroy(clone);
        }
    }

    void ClearCloneQuestionMoney()
    {
        var money = GameObject.FindGameObjectsWithTag("CloneQuestion");
        foreach(var clone in money)
        {
            Destroy(clone);
        }
    }

    public bool CheckResult()
    {
        bool result;
        if(currentPrice == questionData[currentQuestionNum].Answer)
        {
            audioSource.PlayOneShot(audioClipSeikai);
            result = true;
        }
        else
        {
            audioSource.PlayOneShot(audioClipBatsu);
            result = false;
            missCount++;
        }
        StartCoroutine(NextProc());
        return result;
    }

    IEnumerator NextProc()
    {
        yield return new WaitForSeconds(1.5f);
        currentQuestionNum++;
        if(currentQuestionNum >= MaxQuestionNum)
        {
            // リザルト画面へ遷移
            DontDestroyOnLoad(this);
            StartCoroutine(StopToResult());
        }
        else
        {
            currentPrice = 0;
            ResetPushCount();
            ClearCloneAnswerMoney();
            ClearCloneQuestionMoney();
            bIsActive = true;
            DispQuestion(currentQuestionNum);
        }
    }

    IEnumerator StopToResult()
    {
        yield return new WaitForSeconds(1.0f);
        audioSource.PlayOneShot(audioClipFinish);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("CoinChangeResult");
    }

    public void OnClickCancel()
    {
        if (!bIsActive)
        {
            return;
        }
        StartCoroutine(CancelGame());
    }

    IEnumerator CancelGame()
    {
        audioSource.PlayOneShot(audioClipCancel);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Title");
    }
}
