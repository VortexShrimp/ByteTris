using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Persistent global object to hold shared data.
    /// Gets created on an empty GameObject apon first use.
    /// 
    /// TODO: Rename this to GlobalGameManager or something...
    /// </summary>
    public class GameManagerSingleton : MonoBehaviour
    {
        static GameManagerSingleton _instance;

        public static GameManagerSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<GameManagerSingleton>();

                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<GameManagerSingleton>();
                        singletonObject.name = typeof(GameManagerSingleton).ToString();
                    }
                }

                return _instance;
            }
        }

        public bool isPaused;

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;

            // Make this object persist between scenes.
            DontDestroyOnLoad(gameObject);

            // Because this object gets created when first referenced,
            // make sure to initialize all your global variables...

            isPaused = false;
        }
    }
}
