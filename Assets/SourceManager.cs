using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceManager : MonoBehaviour {

    public static SourceManager Instance { set; get; }
    public AudioClip[] listen;


    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// 播放正确选项
    /// </summary>
	public void PlayTrue()
    {
        gameObject.GetComponent<AudioSource>().clip = listen[0];
        this.gameObject.GetComponent<AudioSource>().Play();
    }
    /// <summary>
    /// 完成
    /// </summary>
    public void PlayFinish()
    {
        gameObject.GetComponent<AudioSource>().clip = listen[1];
        this.gameObject.GetComponent<AudioSource>().Play();
    }
    /// <summary>
    /// play error
    /// </summary>

    public void PlayError()
    {
        gameObject.GetComponent<AudioSource>().clip = listen[2];
        this.gameObject.GetComponent<AudioSource>().Play();
    }

}
