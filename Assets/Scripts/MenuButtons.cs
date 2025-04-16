using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MenuButtons : MonoBehaviour
    {
        public void OnPlayButtonClicked()
        {
            SceneManager.LoadSceneAsync("Game");
        }

        public void OnOptionsButtonClicked()
        {
            // Load options menu.
        }

        public void OnTutorialButtonClicked()
        {
            // Load options menu.
        }

        public void OnExitButtonClicked()
        {
            Application.Quit();
        }
    }
}
