using AudioManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using ShmupBoss;

namespace UI {
    public class UIController : MonoBehaviour {

        public UnityEvent mainMenuEvent;
        private bool _mainMenuSet;
        public UnityEvent playerMenuEvent;
        private bool _playerMenuSet;
        public UnityEvent settingsMenuEvent;
        [SerializeField]
        private RectTransform[] avatarCanvases;
        private bool _settingsMenuSet;
        public UnityEvent exitWindowEvent;

        private int _avatarIndex = 0;
        [SerializeField] private SfxEvent sfxUI;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private MusicEvent menuAmbient;
        [SerializeField] private AudioSource ambientSource;
    
        public void ActivateMainMenu() {
            if (_mainMenuSet)
                return;
            mainMenuEvent.Invoke();
            _mainMenuSet = true;
            _settingsMenuSet = false;
            _playerMenuSet = false;
        }
        
        public void PlayUISound() {
            sfxUI.Play(audioSource);
        }

        public void SelectedPlayer() {
            GameManager.Instance.AssignSelectedPlayer(_avatarIndex);
            Debug.Log("se ha seleccionado la nave" + _avatarIndex);
            SceneManager.LoadScene("UI Complete Scene");
        }

        private void PlayAmbient() {
            menuAmbient.Play(ambientSource);
        }

        public void MainSetBool() {
            _mainMenuSet = false;
        }

        public void ActivateSettingsMenu() {
            if (_settingsMenuSet)
                return;
            settingsMenuEvent.Invoke();
            _settingsMenuSet = true;
        }

        public void ActivatePlayerMenu() {
            if (_playerMenuSet)
                return;
            playerMenuEvent.Invoke();
            _playerMenuSet = true;
            EnableAvatarCanvas(_avatarIndex);
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

        private void Start() {
            PlayAmbient();
        }

        public void ActivateExitWindow() {
            exitWindowEvent.Invoke();
        }
        
        private void EnableAvatarCanvas(int index) {
            avatarCanvases[index].gameObject.SetActive(true);
        }
        private void DisableAllAvatarCanvases() {
            foreach (RectTransform avatarCanvas in avatarCanvases) {
                avatarCanvas.gameObject.SetActive(false);
            }
        }
        public void NextAvatar() {
            if (_avatarIndex + 1 > avatarCanvases.Length - 1)
                return;
            _avatarIndex++;
            DisableAllAvatarCanvases();
            EnableAvatarCanvas(_avatarIndex);
        }

        public void PreviousAvatar() {
            if (_avatarIndex - 1 < 0) 
                return;
            _avatarIndex--;
            DisableAllAvatarCanvases();
            EnableAvatarCanvas(_avatarIndex);
        }
    }
}
