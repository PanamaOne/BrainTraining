using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    QuestionManager questionManager;
    const int maxPushNum = 5;

    struct SpawnInfo
    {
        public int maxCoinNum;
        public int layer;
        public Vector3 pos;
        public SpawnInfo(int coinNum, int layerNum, Vector3 initPos)
        {
            maxCoinNum = coinNum;
            layer = layerNum;
            pos = initPos;
        }
    };

    // 硬貨の出現場所
    static SpawnInfo[] SpawnInfoArray = new[]
    {
        new SpawnInfo(1, 1, new Vector3(0, 500)),
        new SpawnInfo(5, 2, new Vector3(150, 550)),
        new SpawnInfo(5, 2, new Vector3(-150, 550)),
        new SpawnInfo(5, 2, new Vector3(50, 350)),
        new SpawnInfo(5, 2, new Vector3(-80, 340)),
        new SpawnInfo(10, 3, new Vector3(300, 400)),
        new SpawnInfo(10, 3, new Vector3(300, 600)),
        new SpawnInfo(10, 3, new Vector3(-300, 420)),
        new SpawnInfo(10, 3, new Vector3(-280, 610)),
        new SpawnInfo(10, 3, new Vector3(100, 310)),
        new SpawnInfo(15, 4, new Vector3(-340, 350)),
        new SpawnInfo(15, 4, new Vector3(340, 320)),
        new SpawnInfo(15, 4, new Vector3(330, 510)),
        new SpawnInfo(15, 4, new Vector3(-320, 500)),
        new SpawnInfo(15, 4, new Vector3(-10, 310)),
    };


    public enum MoneyType
    {
        MoneyType_1 = 0,
        MoneyType_5,
        MoneyType_10,
        MoneyType_50,
        MoneyType_100,
        MoneyType_500,
        MoneyType_1000,
        MoneyType_2000,
        MoneyType_5000,
        MoneyType_10000,
        MoneyType_1Png,
        MoneyType_5Png,
        MoneyType_10Png,
        MoneyType_50Png,
        MoneyType_100Png,
        MoneyType_500Png,
        MoneyType_1000Png,
        MoneyType_2000Png,
        MoneyType_5000Png,
        MoneyType_10000Png,

        MoneyType_Num
    }

    // プレハブオブジェクト
    // タッチ判定あり
    static public GameObject money1Obj;
    static public GameObject money5Obj;
    static public GameObject money10Obj;
    static public GameObject money50Obj;
    static public GameObject money100Obj;
    static public GameObject money500Obj;
    static public GameObject money1000Obj;
    static public GameObject money2000Obj;
    static public GameObject money5000Obj;
    static public GameObject money10000Obj;
    // タッチ判定無し
    static public GameObject money1PngObj;
    static public GameObject money5PngObj;
    static public GameObject money10PngObj;
    static public GameObject money50PngObj;
    static public GameObject money100PngObj;
    static public GameObject money500PngObj;
    static public GameObject money1000PngObj;
    static public GameObject money2000PngObj;
    static public GameObject money5000PngObj;
    static public GameObject money10000PngObj;

    // Start is called before the first frame update
    void Start()
    {
        GameObject questionObj = GameObject.Find("QuestionManager");
        questionManager = questionObj.GetComponent<QuestionManager>();
        LoadPrefabs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadPrefabs()
    {
        // プレハブの読み込み
        money1Obj = (GameObject)Resources.Load("Money1");
        money5Obj = (GameObject)Resources.Load("Money5");
        money10Obj = (GameObject)Resources.Load("Money10");
        money50Obj = (GameObject)Resources.Load("Money50");
        money100Obj = (GameObject)Resources.Load("Money100");
        money500Obj = (GameObject)Resources.Load("Money500");
        money1000Obj = (GameObject)Resources.Load("Money1000");
        money2000Obj = (GameObject)Resources.Load("Money2000");
        money5000Obj = (GameObject)Resources.Load("Money5000");
        money10000Obj = (GameObject)Resources.Load("Money10000");
        money1PngObj = (GameObject)Resources.Load("Money1Png");
        money5PngObj = (GameObject)Resources.Load("Money5Png");
        money10PngObj = (GameObject)Resources.Load("Money10Png");
        money50PngObj = (GameObject)Resources.Load("Money50Png");
        money100PngObj = (GameObject)Resources.Load("Money100Png");
        money500PngObj = (GameObject)Resources.Load("Money500Png");
        money1000PngObj = (GameObject)Resources.Load("Money1000Png");
        money2000PngObj = (GameObject)Resources.Load("Money2000Png");
        money5000PngObj = (GameObject)Resources.Load("Money5000Png");
        money10000PngObj = (GameObject)Resources.Load("Money10000Png");
    }

    public void OnTouch()
    {
        if (!questionManager.bIsActive)
        {
            return;
        }
        switch (gameObject.name)
        {
            case "Money1":
                if(questionManager.pushCount1 >= maxPushNum)
                {
                    break;
                }
                questionManager.currentPrice += 1;
                questionManager.pushCount1++;
                CreateMoney(MoneyType.MoneyType_1Png);
                questionManager.audioSource.PlayOneShot(questionManager.audioClipClick);
                break;
            case "Money5":
                if (questionManager.pushCount5 >= maxPushNum)
                {
                    break;
                }
                questionManager.currentPrice += 5;
                questionManager.pushCount5++;
                CreateMoney(MoneyType.MoneyType_5Png);
                questionManager.audioSource.PlayOneShot(questionManager.audioClipClick);
                break;
            case "Money10":
                if (questionManager.pushCount10 >= maxPushNum)
                {
                    break;
                }
                questionManager.currentPrice += 10;
                questionManager.pushCount10++;
                CreateMoney(MoneyType.MoneyType_10Png);
                questionManager.audioSource.PlayOneShot(questionManager.audioClipClick);
                break;
            case "Money50":
                if (questionManager.pushCount50 >= maxPushNum)
                {
                    break;
                }
                questionManager.currentPrice += 50;
                questionManager.pushCount50++;
                CreateMoney(MoneyType.MoneyType_50Png);
                questionManager.audioSource.PlayOneShot(questionManager.audioClipClick);
                break;
            case "Money100":
                if (questionManager.pushCount100 >= maxPushNum)
                {
                    break;
                }
                questionManager.currentPrice += 100;
                questionManager.pushCount100++;
                CreateMoney(MoneyType.MoneyType_100Png);
                questionManager.audioSource.PlayOneShot(questionManager.audioClipClick);
                break;
            case "Money500":
                if (questionManager.pushCount500 >= maxPushNum)
                {
                    break;
                }
                questionManager.currentPrice += 500;
                questionManager.pushCount500++;
                CreateMoney(MoneyType.MoneyType_500Png);
                questionManager.audioSource.PlayOneShot(questionManager.audioClipClick);
                break;
            case "Money1000":
                if (questionManager.pushCount1000 >= maxPushNum)
                {
                    break;
                }
                questionManager.currentPrice += 1000;
                questionManager.pushCount1000++;
                CreateMoney(MoneyType.MoneyType_1000Png);
                questionManager.audioSource.PlayOneShot(questionManager.audioClipClick);
                break;
            case "Money2000":
                if (questionManager.pushCount2000 >= maxPushNum)
                {
                    break;
                }
                questionManager.currentPrice += 2000;
                questionManager.pushCount2000++;
                CreateMoney(MoneyType.MoneyType_2000Png);
                questionManager.audioSource.PlayOneShot(questionManager.audioClipClick);
                break;
            case "Money5000":
                if (questionManager.pushCount5000 >= maxPushNum)
                {
                    break;
                }
                questionManager.currentPrice += 5000;
                questionManager.pushCount5000++;
                CreateMoney(MoneyType.MoneyType_5000Png);
                questionManager.audioSource.PlayOneShot(questionManager.audioClipClick);
                break;
            case "Money10000":
                if (questionManager.pushCount10000 >= maxPushNum)
                {
                    break;
                }
                questionManager.currentPrice += 10000;
                questionManager.pushCount10000++;
                CreateMoney(MoneyType.MoneyType_10000Png);
                questionManager.audioSource.PlayOneShot(questionManager.audioClipClick);
                break;
            case "Eraser":
                questionManager.currentPrice = 0;
                questionManager.ResetPushCount();
                questionManager.ClearCloneAnswerMoney();
                questionManager.audioSource.PlayOneShot(questionManager.audioClipClick);
                break;
            case "DecideButton":
                questionManager.bIsActive = false;
                questionManager.CheckResult();
                break;
            default:
                break;
        }
        Debug.Log(questionManager.currentPrice);
    }

    void CreateMoney(MoneyType type)
    {
        GameObject money;
        switch (type)
        {
            default:
                break;
            case MoneyType.MoneyType_1Png:
                money = Instantiate(money1PngObj, new Vector3(-Screen.width/2.0f + 100.0f + 20.0f * questionManager.pushCount1, Screen.height/4.0f - 370.0f, 0), Quaternion.identity);
                money.transform.SetParent(questionManager.canvas.transform, false);
                money.tag = "CloneAnswer";
                break;
            case MoneyType.MoneyType_5Png:
                money = Instantiate(money5PngObj, new Vector3(-Screen.width / 2.0f + 370.0f + 20.0f * questionManager.pushCount5, Screen.height / 4.0f - 370.0f, 0), Quaternion.identity);
                money.transform.SetParent(questionManager.canvas.transform, false);
                money.tag = "CloneAnswer";
                break;
            case MoneyType.MoneyType_10Png:
                money = Instantiate(money10PngObj, new Vector3(100.0f + 20.0f * questionManager.pushCount10, Screen.height / 4.0f - 370.0f, 0), Quaternion.identity);
                money.transform.SetParent(questionManager.canvas.transform, false);
                money.tag = "CloneAnswer";
                break;
            case MoneyType.MoneyType_50Png:
                money = Instantiate(money50PngObj, new Vector3(Screen.width / 2.0f - 200.0f + 20.0f * questionManager.pushCount50, Screen.height / 4.0f - 370.0f, 0), Quaternion.identity);
                money.transform.SetParent(questionManager.canvas.transform, false);
                money.tag = "CloneAnswer";
                break;
            case MoneyType.MoneyType_100Png:
                money = Instantiate(money100PngObj, new Vector3(-Screen.width / 2.0f + 200.0f + 20.0f * questionManager.pushCount100, Screen.height / 8.0f - 320.0f, 0), Quaternion.identity);
                money.transform.SetParent(questionManager.canvas.transform, false);
                money.tag = "CloneAnswer";
                break;
            case MoneyType.MoneyType_500Png:
                money = Instantiate(money500PngObj, new Vector3(-40.0f + 20.0f * questionManager.pushCount500, Screen.height / 8.0f - 320.0f, 0), Quaternion.identity);
                money.transform.SetParent(questionManager.canvas.transform, false);
                money.tag = "CloneAnswer";
                break;
            case MoneyType.MoneyType_1000Png:
                money = Instantiate(money1000PngObj, new Vector3(Screen.width / 2.0f - 250.0f + 20.0f * questionManager.pushCount1000, Screen.height / 8.0f - 320.0f, 0), Quaternion.identity);
                money.transform.SetParent(questionManager.canvas.transform, false);
                money.tag = "CloneAnswer";
                break;
            case MoneyType.MoneyType_2000Png:
                money = Instantiate(money2000PngObj, new Vector3(Screen.width / 2.0f - 250.0f + 20.0f * questionManager.pushCount2000, Screen.height / 8.0f - 130.0f, 0), Quaternion.identity);
                money.transform.SetParent(questionManager.canvas.transform, false);
                money.tag = "CloneAnswer";
                break;
            case MoneyType.MoneyType_5000Png:
                money = Instantiate(money5000PngObj, new Vector3(Screen.width / 2.0f - 250.0f + 20.0f * questionManager.pushCount5000, Screen.height / 8.0f - 130.0f, 0), Quaternion.identity);
                money.transform.SetParent(questionManager.canvas.transform, false);
                money.tag = "CloneAnswer";
                break;
            case MoneyType.MoneyType_10000Png:
                money = Instantiate(money10000PngObj, new Vector3(Screen.width / 2.0f - 250.0f + 20.0f * questionManager.pushCount10000, Screen.height / 8.0f - 130.0f, 0), Quaternion.identity);
                money.transform.SetParent(questionManager.canvas.transform, false);
                money.tag = "CloneAnswer";
                break;
        }
    }

    static public List<GameObject> CreateQuestionMoney(QuestionManager.QuestionData data, GameObject canvas)
    {
        int moneySum = data.Money1Num + data.Money5Num + data.Money10Num + data.Money50Num +
            data.Money100Num + data.Money500Num + data.Money1000Num + data.Money2000Num +
            data.Money5000Num + data.Money10000Num;
        int coinSum = data.Money1Num + data.Money5Num + data.Money10Num + data.Money50Num +
            data.Money100Num + data.Money500Num;
        int createCoinNum = 0;
        List<GameObject> list = new List<GameObject>();
        Vector3 trans = new Vector3();

        for (int index = 0; index < data.Money1000Num; ++index)
        {
            GameObject obj = Instantiate(money1000PngObj, new Vector3(0, 600), Quaternion.identity);
            obj.transform.localScale = new Vector3(7.0f, 3.5f);
            obj.transform.SetParent(canvas.transform, false);
            obj.tag = "CloneQuestion";
            list.Add(obj);
        }

        // ----------------------------------------------------------------------
        // 2000円から10000円は一旦無視
        for (int index = 0; index < data.Money2000Num; ++index)
        {
            GameObject obj = Instantiate(money2000PngObj, new Vector3(createCoinNum * 20, 500), Quaternion.identity);
            obj.transform.SetParent(canvas.transform, false);
            obj.tag = "CloneQuestion";
            list.Add(obj);
        }
        for (int index = 0; index < data.Money5000Num; ++index)
        {
            GameObject obj = Instantiate(money5000PngObj, new Vector3(createCoinNum * 20, 500), Quaternion.identity);
            obj.transform.SetParent(canvas.transform, false);
            obj.tag = "CloneQuestion";
            list.Add(obj);
        }
        for (int index = 0; index < data.Money10000Num; ++index)
        {
            GameObject obj = Instantiate(money10000PngObj, new Vector3(createCoinNum * 20, 500), Quaternion.identity);
            obj.transform.SetParent(canvas.transform, false);
            obj.tag = "CloneQuestion";
            list.Add(obj);
        }
        // -----------------------------------------------------------------------

        for (int index = 0; index < data.Money500Num; ++index)
        {
            GameObject obj = Instantiate(money500PngObj, SpawnInfoArray[createCoinNum].pos, Quaternion.identity);
            obj.transform.SetParent(canvas.transform, false);
            obj.transform.localScale = new Vector3(2.3f, 2.3f);
            obj.tag = "CloneQuestion";
            list.Add(obj);
            ++createCoinNum;
        }
        for (int index = 0; index < data.Money100Num; ++index)
        {
            GameObject obj = Instantiate(money100PngObj, SpawnInfoArray[createCoinNum].pos, Quaternion.identity);
            obj.transform.SetParent(canvas.transform, false);
            obj.transform.localScale = new Vector3(2.1f, 2.1f);
            obj.tag = "CloneQuestion";
            list.Add(obj);
            ++createCoinNum;
        }
        for (int index = 0;index < data.Money1Num; ++index)
        {
            GameObject obj = Instantiate(money1PngObj, SpawnInfoArray[createCoinNum].pos, Quaternion.identity);
            obj.transform.SetParent(canvas.transform, false);
            obj.transform.localScale = new Vector3(1.7f, 1.7f);
            obj.tag = "CloneQuestion";
            list.Add(obj);
            ++createCoinNum;
        }
        for (int index = 0; index < data.Money5Num; ++index)
        {
            GameObject obj = Instantiate(money5PngObj, SpawnInfoArray[createCoinNum].pos, Quaternion.identity);
            obj.transform.SetParent(canvas.transform, false);
            obj.transform.localScale = new Vector3(1.8f, 1.8f);
            obj.tag = "CloneQuestion";
            list.Add(obj);
            ++createCoinNum;
        }
        for (int index = 0; index < data.Money10Num; ++index)
        {
            GameObject obj = Instantiate(money10PngObj, SpawnInfoArray[createCoinNum].pos, Quaternion.identity);
            obj.transform.SetParent(canvas.transform, false);
            obj.transform.localScale = new Vector3(2.2f, 2.2f);
            obj.tag = "CloneQuestion";
            list.Add(obj);
            ++createCoinNum;
        }
        for (int index = 0; index < data.Money50Num; ++index)
        {
            GameObject obj = Instantiate(money50PngObj, SpawnInfoArray[createCoinNum].pos, Quaternion.identity);
            obj.transform.SetParent(canvas.transform, false);
            obj.transform.localScale = new Vector3(2.0f, 2.0f);
            obj.tag = "CloneQuestion";
            list.Add(obj);
            ++createCoinNum;
        }

        return list;
    }
}
