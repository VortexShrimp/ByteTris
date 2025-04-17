using UnityEngine;

namespace Assets.Scripts
{
    public class GameUIController : MonoBehaviour
    {
        /// <summary>
        /// Panel that needs to be toggled to show the pause menu.
        /// </summary>
        [SerializeField]
        GameObject _pausePanel;

        [SerializeField]
        GameObject _optionsPanel;

        void Awake()
        {
            // Just in-case the panel is left active in the editor.
            _pausePanel.SetActive(false);
            PersistentGameManger.Instance.isPaused = false;
        }

        void OnEnable()
        {
            PauseMenuButtons.onResumeButtonClicked += OnResumeButtonClicked;
        }

        void OnDisable()
        {
            PauseMenuButtons.onResumeButtonClicked -= OnResumeButtonClicked;
        }

        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape) == true)
            {
                ToggleGamePaused();
            }
        }

        void ToggleGamePaused()
        {
            // Toggle the pause menu panel.
            bool isActive = !_pausePanel.activeSelf;
            _pausePanel.SetActive(isActive);

            // Update the state in the game manager.
            PersistentGameManger.Instance.isPaused = isActive;

            Time.timeScale = isActive == true ? 0 : 1;
        }

        void OnResumeButtonClicked()
        {
            ToggleGamePaused();
        }
    }
}
