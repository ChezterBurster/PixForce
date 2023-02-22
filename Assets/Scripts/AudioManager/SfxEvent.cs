using UnityEngine;
using UnityEngine.Audio;
//Namespace de codigo relacionado al audio, a este si quieres no le muevas
namespace AudioManager {
	//Clase para eventos de efectos de sonido, se crea desde el inspector
	[CreateAssetMenu(fileName = "New SfxEvent", menuName = "SoundEvent/SfxEvent", order = 1)]
	public class SfxEvent : SoundEvent {
		//atributos y referencias de utilidad
		[SerializeField] private AudioMixerGroup mixerGroup;//tiene que ver con el mixing de audio
		[SerializeField] private RangedFloat volume;//control de volumen
		[SerializeField] private RangedFloat pitch;//control de tono
		
		//metodo para reproducción de efectos
		public override void Play(AudioSource source) {
			source.clip = clip;
			source.outputAudioMixerGroup = mixerGroup;
			//se usan valores random de un rango para añadir variacion a los efectos
			source.volume = Random.Range(volume.minValue, volume.maxValue);
			source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
			source.Play();
		}
	}
}