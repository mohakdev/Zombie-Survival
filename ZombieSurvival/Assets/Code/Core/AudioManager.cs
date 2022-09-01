using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantGames.ZombieSurvival
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        static AudioSource audioPlayer;
        [Header("List of sounds Audio Manager can control")]
        public AudioClip[] AudioList;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        private void Start()
        {
            audioPlayer = gameObject.transform.Find("EffectSource").GetComponent<AudioSource>();
        }
        /// <summary>
        /// Play a sound from sound list in AudioPlayer. Check AudioPlayer Inspector for more detail
        /// </summary>
        /// <param name="SoundIndex">The Index of the sound you want to play from the list. Check AudioPlayer Inspector for more detail</param>
        public static void PlaySound(AudioClip clip)
        {
              audioPlayer.PlayOneShot(clip);
        }
        public static void MasterVolume(int value)
        {
            AudioListener.volume = value;
        }
    }
}
