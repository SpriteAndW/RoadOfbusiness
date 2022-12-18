using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundSceneData_SO",menuName = "Sound/SoundSceneData_SO")]
public class SoundSceneData_SO : ScriptableObject
{
    public List<SoundSceneDetail> soundSceneList;

    public SoundSceneDetail GetSoundSceneDetail(string name)
    {
        return soundSceneList.Find(s => s.sceneName == name);
    }
}

[System.Serializable]
public class SoundSceneDetail
{
    public string sceneName;

    public SoundType BgMusic;
}
