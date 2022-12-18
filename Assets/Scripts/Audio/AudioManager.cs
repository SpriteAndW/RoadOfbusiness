using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;

public class AudioManager : MonoSingleton<AudioManager>
{
    public SoundDetailData_SO soundDetailData;
    public SoundSceneData_SO soundSceneData;
    public GameObject effectSourcePrefab;

    [Header("组件获取")] public AudioSource bgMusicSource;
    public AudioSource effectSource;

    public AudioMixer audioMixer;
    
    public AudioMixerSnapshot normalSnapshot;
    public AudioMixerSnapshot effectSnapshot;
    public AudioMixerSnapshot muteSnapshot;

    private Coroutine soundRoutine;
    private float musicTransitionSecond = 5f;


    private void OnEnable()
    {
        EventHandler.AfterSceneLoadeEvent += OnAfterSceneLoadeEvent;
        EventHandler.PlayEffectEvent += OnPlayEffectEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadeEvent -= OnAfterSceneLoadeEvent;
        EventHandler.PlayEffectEvent -= OnPlayEffectEvent;
    }


    private void Start()
    {
        //刚开始先执行一次
        // EventHandler.CallAfterSceneLoadeEvent("BeginScene");
        OnAfterSceneLoadeEvent("BeginScene");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //每点击鼠标左键一次播放一次
            EventHandler.CallPlayEffectEvent(SoundType.CleckNone);
        }
    }

    private void OnAfterSceneLoadeEvent(string sceneName)
    {
        SoundSceneDetail sceneSound = soundSceneData.GetSoundSceneDetail(sceneName);
        if (sceneSound == null)
        {
            return;
        }

        SoundDetail bgMusic = soundDetailData.GetSoundDetail(sceneSound.BgMusic);

        if (soundRoutine != null)
        {
            StopCoroutine(soundRoutine);
        }

        soundRoutine = StartCoroutine(PlaySoundRoutine(bgMusic));
    }


    private void OnPlayEffectEvent(SoundType soundType)
    {
        SoundDetail soundDetail = soundDetailData.GetSoundDetail(soundType);

        var soundPre = ObjectPool.Instance.CreateObject(soundDetail.SoundType.ToString(), effectSourcePrefab,
            Vector3.zero, quaternion.identity);
        soundPre.transform.SetParent(transform);
        soundPre.GetComponent<Sound>().SetSound(soundDetail);
    }

    /// <summary>
    /// 缓慢增大背景音乐音量
    /// </summary>
    /// <param name="bgMusic"></param>
    /// <returns></returns>
    private IEnumerator PlaySoundRoutine(SoundDetail bgMusic)
    {
        if (bgMusic != null)
        {
            //播放切换场景音效
            PlayEffectOnly(soundDetailData.soundDetailList[2], 1);

            //延迟1秒开始缓慢提高播放背景音乐
            yield return new WaitForSeconds(1f);
            PlayBgMusicClip(bgMusic, musicTransitionSecond);
        }
    }


    private void PlayEffectOnly(SoundDetail soundDetail, float transitionTime)
    {
        audioMixer.SetFloat("TranseVolume", ConertSoundVolume(soundDetail.soundVolume));
        effectSource.clip = soundDetail.soundClip;

        //当BgMusic是启用状态或播放状态
        if (effectSource.isActiveAndEnabled)
        {
            effectSource.Play();
        }

        // normalSnapshot.TransitionTo(transitionTime);
        effectSnapshot.TransitionTo(transitionTime); //在指定的时间间隔内对此快照执行插值转换
    }


    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="soundDetail">声音详细</param>
    private void PlayBgMusicClip(SoundDetail soundDetail, float transitionTime)
    {
        audioMixer.SetFloat("BgMusicVolume", ConertSoundVolume(soundDetail.soundVolume));
        bgMusicSource.clip = soundDetail.soundClip;

        //当BgMusic是启用状态或播放状态
        if (bgMusicSource.isActiveAndEnabled)
        {
            bgMusicSource.Play();
        }

        // normalSnapshot.TransitionTo(transitionTime);
        normalSnapshot.TransitionTo(transitionTime); //在指定的时间间隔内对此快照执行插值转换
    }

    /// <summary>
    /// 将声音Volue转换
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    private float ConertSoundVolume(float amount)
    {
        return (amount * 100 - 80);
    }
    
    /// <summary>
    /// 总音量调节
    /// </summary>
    /// <param name="value"></param>
    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", ConertSoundVolume(value));
    }

    /// <summary>
    /// 背景音乐调节
    /// </summary>
    /// <param name="value"></param>
    public void SetBGMusicVolume(float value)
    {
        audioMixer.SetFloat("BgMasterVolume", ConertSoundVolume(value));
    }

    /// <summary>
    /// 音效调节
    /// </summary>
    /// <param name="value"></param>
    public void SetEffectVolume(float value)
    {
        audioMixer.SetFloat("EffectVolume", ConertSoundVolume(value));
    }
}