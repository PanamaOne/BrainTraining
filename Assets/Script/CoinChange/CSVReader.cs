using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    TextAsset csvFile;  // CSV�t�@�C��
    public List<string[]> csvDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g                                                  

    // Start is called before the first frame update
    void Start()
    {
        csvFile = Resources.Load("questionData") as TextAsset;  // Resources�ȉ���CSV�ǂݍ���
        StringReader reader = new StringReader(csvFile.text);

        // ,�ŕ�������s���ǂݍ���
        // ���X�g�Œǉ����Ă���
        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine();    // ��s���ǂݍ���
            csvDatas.Add(line.Split(','));      // ��؂�Ń��X�g�ɒǉ�
        }

        // �o��
        foreach(var tmp in csvDatas)
        {
            foreach(var i in tmp)
            {
                //Debug.Log(i);
            }
        }
    }
}
