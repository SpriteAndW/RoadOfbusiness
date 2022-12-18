using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using  UnityEngine.Audio;
using Random = UnityEngine.Random;

public class Sound : MonoBehaviour
{
   [SerializeField] private AudioSource audioSource;

   

   public void SetSound(SoundDetail soundDetail)
   {
      audioSource.clip = soundDetail.soundClip;
      audioSource.volume = soundDetail.soundVolume;
      audioSource.pitch = Random.Range(soundDetail.soundPitchMax, soundDetail.soundPitchMin);
      
      ObjectPool.Instance.CollectObject(this.gameObject,soundDetail.soundClip.length);

   }


   
}
