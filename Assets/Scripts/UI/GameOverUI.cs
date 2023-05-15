using AudioManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace UI {
    public class GameOverUI : MonoBehaviour {
        
        public UnityEvent exitWindowEvent;
        [SerializeField] private MusicEvent menuAmbient;
        [SerializeField] private AudioSource ambientSource;
        [SerializeField] private SfxEvent sfxUI;
        [SerializeField] private AudioSource audioSource;
        
        public void ActivateExitWindow() {
            exitWindowEvent.Invoke();
        }

        public void ContinueToMain() {
            SceneManager.LoadScene("Menu");
        }

        public void ExitGame() {
            Application.Quit();
        }

        private void PlayAmbient() {
            menuAmbient.Play(ambientSource);
        }
        
        public void PlayUISound() {
            sfxUI.Play(audioSource);
        }
        
        private void Start() {
            PlayAmbient();
        }
    }
}