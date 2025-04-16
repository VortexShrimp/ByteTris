using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MenuButtons : MonoBehaviour
    {
        public void OnPlayButtonClicked()
        {
            Debug.Log("Play button clicked.");
            SceneManager.LoadSceneAsync("Game");
        }

        public void OnOptionsButtonClicked()
        {
            // Load options menu.
            Debug.Log("Options button clicked.");
        }

        public void OnTutorialButtonClicked()
        {
            Debug.Log("Tutorial button clicked.");
        }

        public void OnExitButtonClicked()
        {
            Debug.Log("Exit button clicked.");
            Application.Quit();
        }
    }
}
