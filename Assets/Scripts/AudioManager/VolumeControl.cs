using UnityEngine;
using UnityEngine.Audio;

namespace AudioManager {
    public class VolumeControl : MonoBehaviour {

        [SerializeField] private AudioMixer mixer;

        public void SetMasterLevel(float sliderValue) {
            mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20f);
        }

        public void SetMusicLevel(float sliderValue) {
            mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20f);
        }
    
        public void SetSFXLevel(float sliderValue) {
            mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20f);
        }
    }
}
