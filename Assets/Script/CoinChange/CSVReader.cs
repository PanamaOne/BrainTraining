using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    TextAsset csvFile;  // CSVファイル
    public List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト                                                  

    // Start is called before the first frame update
    void Start()
    {
        csvFile = Resources.Load("questionData") as TextAsset;  // Resources以下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        // ,で分割しつつ一行ずつ読み込み
        // リストで追加していく
        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine();    // 一行ずつ読み込み
            csvDatas.Add(line.Split(','));      // 区切りでリストに追加
        }

        // 出力
        foreach(var tmp in csvDatas)
        {
            foreach(var i in tmp)
            {
                //Debug.Log(i);
            }
        }
    }
}
