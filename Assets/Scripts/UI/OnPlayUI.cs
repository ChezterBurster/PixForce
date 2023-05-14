using AudioManager;
using UnityEngine;
using UnityEngine.Events;

namespace UI {
    public class OnPlayUI : MonoBehaviour {

        [SerializeField] private SfxEvent sfxUI;
        [SerializeField] private AudioSource audioSource;
        public UnityEvent pauseMenuEvent;
        private bool _pauseMenuSet;
        public UnityEvent settingsMenuEvent;
        private bool _settingsMenuSet;
        public UnityEvent exitWindowEvent;
        public UnityEvent returnEvent;
    
        public void ActivatePauseMenu() {
            if (_pauseMenuSet)
                return;
            Time.timeScale = 0f;
            pauseMenuEvent.Invoke();
            _pauseMenuSet = true;
            _settingsMenuSet = false;
        }

        public void PlayUISound() {
            sfxUI.Play(audioSource);
        }

        public void PauseSetBool() {
            _pauseMenuSet = false;
        }

        public void ActivateSettingsMenu() {
            if (_settingsMenuSet)
                return;
            settingsMenuEvent.Invoke();
            _settingsMenuSet = true;
        }

        public void ExitGame() {
            Application.Quit();
            Debug.Log("Salido");
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape) && !_pauseMenuSet) {
                ActivatePauseMenu();
            }
        }

        public void ActivateExitWindow() {
            exitWindowEvent.Invoke();
        }

        public void ReturnToGame() {
            returnEvent.Invoke();
            Time.timeScale = 1f;
        }
        
    }
}
