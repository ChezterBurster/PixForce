using UnityEngine;

namespace AudioManager {
    
    public abstract class SoundEvent : ScriptableObject  {

        public AudioClip clip;
    
        public virtual void Play(AudioSource source) {
            source.clip = clip;
            source.Play();
        }
    
    }
}
