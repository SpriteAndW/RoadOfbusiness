using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundDetailData_SO",menuName = "Sound/SoundDetailData_SO")]
public class SoundDetailData_SO : ScriptableObject
{
    public List<SoundDetail> soundDetailList;

    public SoundDetail GetSoundDetail(SoundType name)
    {
        return soundDetailList.Find(s => s.SoundType == name);
    }
}


[System.Serializable]
public class SoundDetail
{
    public SoundType SoundType;
    public AudioClip soundClip;

    [Range(0.1f, 1.5f)] public float soundPitchMin;
    [Range(0.1f, 1.5f)] public float soundPitchMax;
    [Range(0.1f, 1f)] public float soundVolume;
}

public enum SoundType
{
    none,CleckNone,CleckButton,
    TranseScene,
    beginScene,MainScene,Scene2,Scene4,Scene5,Scene6,Scene7,Scene8,
}