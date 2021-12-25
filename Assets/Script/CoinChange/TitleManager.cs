using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    AudioManager audioManager;
    AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        GameObject audioObj = GameObject.Find("AudioManager");
        audioManager = audioObj.GetComponent<AudioManager>();

        clip = Resources.Load<AudioClip>("Decide");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTouchStartBtn()
    {
        audioManager.PlayClip(clip);
        SceneManager.LoadScene("CoinChange");
    }
}
