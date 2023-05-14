using UnityEngine;
using UnityEngine.Events;

namespace UI {
    public class UIController : MonoBehaviour {

        public UnityEvent mainMenuEvent;
        private bool _mainMenuSet;
        public UnityEvent settingsMenuEvent;
        private bool _settingsMenuSet;
        public UnityEvent exitWindowEvent;
    
        public void ActivateMainMenu() {
            if (_mainMenuSet)
                return;
            mainMenuEvent.Invoke();
            _mainMenuSet = true;
            _settingsMenuSet = false;
        }

        public void ActivateSettingsMenu() {
            if (_settingsMenuSet)
                return;
            settingsMenuEvent.Invoke();
            _settingsMenuSet = true;
            _mainMenuSet = false;
        }

        public void ExitGame() {
            Application.Quit();
            Debug.Log("Salido");
        }

        private void Update() {
            if (Input.anyKeyDown && !_mainMenuSet) {
                ActivateMainMenu();
            }
        
            if (Input.GetKeyDown(KeyCode.Escape)) {
                ActivateExitWindow();
            }
        }

        public void ActivateExitWindow() {
            exitWindowEvent.Invoke();
        }

        public void PlayEvent() {
            //Go to play scene
        }
    }
}
