using UnityEngine;
using UnityEngine.Audio;
//Namespace de codigo relacionado al audio, a este si quieres no le muevas
namespace AudioManager {
	
	//Clase que controla eventos de musica, se crea desde el inspector
	[CreateAssetMenu(fileName = "New MusicEvent", menuName = "SoundEvent/MusicEvent", order = 0)]
	public class MusicEvent : SoundEvent {
		//referencias y atributos del evento de musica
		[SerializeField] private AudioMixerGroup mixerGroup;//controla el canal al que se va el audio
		[SerializeField] [Range(0f, 1f)] private float volume;//controlla el volumen
		[SerializeField] [Range(0.1f, 3f)] private float pitch;//controla el tono
		
		//metodo para reproducir la musica
		public override void Play(AudioSource source) {
			source.clip = clip;
			source.outputAudioMixerGroup = mixerGroup;
			source.volume = volume;
			source.pitch = pitch;
			source.Play();
		}
	}
}