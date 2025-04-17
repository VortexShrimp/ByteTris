using System;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This data is saved to a .json file.
    /// </summary>
    [Serializable]
    public struct SaveData
    {
        public SaveData(int highScore)
        {
            this.highScore = highScore;
        }

        public int highScore;
    }

    /// <summary>
    /// Persistent global object to hold shared data.
    /// Gets created on an empty GameObject apon first use.
    /// </summary>
    public class PersistentGameManger : MonoBehaviour
    {
        static PersistentGameManger _instance;

        public static PersistentGameManger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<PersistentGameManger>();

                    if (_instance == null)
                    {
                        var singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<PersistentGameManger>();
                        singletonObject.name = typeof(PersistentGameManger).ToString();
                    }
                }

                return _instance;
            }
        }

        const string FILE_NAME = "SaveData.json";
        string _filePath;

        //
        // Global variables.
        //

        public bool isPaused;
        public int highScore;

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
            highScore = 0;

            LoadSaveData();
        }

        void LoadSaveData()
        {
            // Create the desired file path.
            _filePath = Path.Combine(Application.dataPath, FILE_NAME);

            if (File.Exists(_filePath) == true)
            {
                // Parse the JSON dialogues into memory.
                string fileData = File.ReadAllText(_filePath);
                var saveData = JsonUtility.FromJson<SaveData>(fileData);

                highScore = saveData.highScore;
            }
            // If the file does not exist, create it.
            else
            {
                // Use this to create the fields in the json file.
                var data = new SaveData(999);
                var json = JsonUtility.ToJson(data);

                File.WriteAllText(_filePath, json);
            }
        }
    }
}
