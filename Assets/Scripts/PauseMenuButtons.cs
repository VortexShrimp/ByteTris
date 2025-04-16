using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PauseMenuButtons : MonoBehaviour
    {
        public delegate void OnResumeButtonClicked();
        public static OnResumeButtonClicked onResumeButtonClicked;

        public void OnResumeButtonClick()
        {
            // Broadcast the event to the GameUIController to un-pause the game.
            onResumeButtonClicked?.Invoke();
        }

        public void OnOptionsButtonClick()
        {
            // TODO: Add game options.
        }

        public void OnExitButtonClick()
        {
            SceneManager.LoadSceneAsync("Menu");
        }
    }
}
