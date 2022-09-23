using UnityEngine;
using UnityEngine.Audio;

namespace AudioManager {
	
	[CreateAssetMenu(fileName = "New SfxEvent", menuName = "SoundEvent/SfxEvent", order = 1)]
	public class SfxEvent : SoundEvent {
		
		[SerializeField] private AudioMixerGroup mixerGroup;
		[SerializeField] private RangedFloat volume;
		[SerializeField] private RangedFloat pitch;

		public override void Play(AudioSource source) {
			source.clip = clip;
			source.outputAudioMixerGroup = mixerGroup;
			source.volume = Random.Range(volume.minValue, volume.maxValue);
			source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
			source.Play();
		}
	}
}