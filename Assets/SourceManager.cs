using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceManager : MonoBehaviour {

    public static SourceManager Instance { set; get; }
    public AudioClip[] listen;
    [SerializeField]
    private AudioClip start;
    //[SerializeField]
    //private AudioClip cpu;
    //[SerializeField]
    //private AudioClip zhuban;
    //[SerializeField]
    //private AudioClip neicuntiao;
    //[SerializeField]
    //private AudioClip xianka;
    //[SerializeField]
    //private AudioClip dianyuan;
    //[SerializeField]
    //private AudioClip yingpan;
    [SerializeField]
    private AudioClip yindaohuoqu;

    private void Awake()
    {
        Instance = this;
        PlayStart();
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
    /// <summary>
    /// 开始播放
    /// </summary>
    public void PlayStart()
    {
        StartCoroutine(WaitAndPlay(2.0f, start));
       // gameObject.GetComponent<AudioSource>().clip = start;
       // gameObject.GetComponent<AudioSource>().Play();
    }
    /// <summary>
    /// 播放clip
    /// </summary>
    /// <param name="clip"></param>
    public void PlayClip(AudioClip clip)
    {
        gameObject.GetComponent<AudioSource>().clip = clip;
        this.gameObject.GetComponent<AudioSource>().Play();
    }

    //public void PlayCPU()
    //{
    //    gameObject.GetComponent<AudioSource>().clip = cpu;
    //    this.gameObject.GetComponent<AudioSource>().Play();
    //}

    //public void PlayZhuban()
    //{
    //    gameObject.GetComponent<AudioSource>().clip = zhuban;
    //    this.gameObject.GetComponent<AudioSource>().Play();
    //}
    //public void PlayNeicuntiao()
    //{
    //    gameObject.GetComponent<AudioSource>().clip = neicuntiao;
    //    this.gameObject.GetComponent<AudioSource>().Play();
    //}
    //public void Playxianka()
    //{
    //    gameObject.GetComponent<AudioSource>().clip = xianka;
    //    this.gameObject.GetComponent<AudioSource>().Play();
    //}
    //public void Playdianyuan()
    //{
    //    gameObject.GetComponent<AudioSource>().clip = dianyuan;
    //    this.gameObject.GetComponent<AudioSource>().Play();
    //}
    //public void Playyingpan()
    //{
    //    gameObject.GetComponent<AudioSource>().clip = yingpan;
    //    this.gameObject.GetComponent<AudioSource>().Play();
    //}

    public void Playyindaochengxu()
    {
        gameObject.GetComponent<AudioSource>().clip = yindaohuoqu;
        this.gameObject.GetComponent<AudioSource>().Play();
    }



    IEnumerator WaitAndPlay(float waittime,AudioClip clip)
    {
        yield return new WaitForSeconds(waittime);
        gameObject.GetComponent<AudioSource>().clip = clip;
        gameObject.GetComponent<AudioSource>().Play();
    }

}
