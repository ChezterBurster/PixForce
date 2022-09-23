using UnityEngine;
using UnityEngine.Audio;

namespace AudioManager {
	
	[CreateAssetMenu(fileName = "New MusicEvent", menuName = "SoundEvent/MusicEvent", order = 0)]
	public class MusicEvent : SoundEvent {
		
		[SerializeField] private AudioMixerGroup mixerGroup;
		[SerializeField] [Range(0f, 1f)] private float volume;
		[SerializeField] [Range(0.1f, 3f)] private float pitch;
		
		public override void Play(AudioSource source) {
			source.clip = clip;
			source.outputAudioMixerGroup = mixerGroup;
			source.volume = volume;
			source.pitch = pitch;
			source.Play();
		}
	}
}