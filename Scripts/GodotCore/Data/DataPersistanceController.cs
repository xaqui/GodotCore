using Godot;
using System.Collections.Generic;

namespace GodotCore {
    namespace Data {
        public partial class DataPersistanceController : Node
        {
            const string DATA_PATH = "user://Saves";
            const string SAVE_FILENAME = "ExampleSaveFile.sav";
            private bool useEncryption = false;

            [Export] private bool debug;
            private GameData gameData;

            private FileDataHandler fileDataHandler;

            // Singleton
            public static DataPersistanceController Instance;

            #region Godot Functions
            public override void _Ready(){
                Configure();
            }

            #endregion

            #region Public Functions

            public void NewGame() {
                this.gameData = new GameData();
                Log("Created New Game Data.");
                Log(gameData.counter.ToString());
            }

            public void LoadGame() {
                gameData = fileDataHandler.Load();
                // If not data can be loaded, initialize to new game
                if(gameData == null) {
                    LogWarning("No save data was found. Initializing to defaults.");
                    NewGame();
                }
                // Push the loaded data to the other scripts

                GetTree().CallGroup("data_persistance_objects", "LoadData", gameData);
                Log(gameData.counter.ToString());
                Log("Loaded Game Data.");
            }

            public void SaveGame() {
                // Pass the data to other scripts so they can update it
                GetTree().CallGroup("data_persistance_objects", "SaveData", gameData);
                fileDataHandler.Save(gameData);
                Log(gameData.counter.ToString());
                Log("Saved Game Data.");
            }
            #endregion

            #region Private Functions
            private void Configure() {
                if (Instance == null) {
                    Instance = this;
                }
                else {
                    QueueFree();
                }
                this.fileDataHandler = new FileDataHandler(DATA_PATH, SAVE_FILENAME, useEncryption);
            }

            private void Log(string _msg) {
                if (!debug) return;
                GD.Print("[DataPersistanceController]: " + _msg);
            }
            private void LogWarning(string _msg) {
                if (!debug) return;
                GD.PushWarning("[DataPersistanceController]: " + _msg);
            }
            #endregion
        }
    }
}
