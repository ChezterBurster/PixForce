using UnityEngine;
//Namespace de codigo relacionado al audio, a este si quieres no le muevas
namespace AudioManager {
    //Esta clase es la base del sistema para lo eventos de sonido
    public abstract class SoundEvent : ScriptableObject  {
        //referencia al archivo de audio
        public AudioClip clip;
        //metodo para reproducir el audio
        public virtual void Play(AudioSource source) {
            source.clip = clip;
            source.Play();
        }
    
    }
}
