using UnityEngine;

namespace Assets.Scripts
{
    public class GameUIController : MonoBehaviour
    {
        [SerializeField]
        GameObject _pauseMenuPanel;

        void Awake()
        {
            // Just in-case the panel is left active in the editor.
            _pauseMenuPanel.SetActive(false);
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

        // TODO: Track paused state through a "GameManager" singleton?
        void ToggleGamePaused()
        {
            // Toggle the pause menu panel.
            bool isActive = !_pauseMenuPanel.activeSelf;
            _pauseMenuPanel.SetActive(isActive);

            Time.timeScale = isActive == true ? 0 : 1;
        }

        void OnResumeButtonClicked()
        {
            ToggleGamePaused();
        }
    }
}
