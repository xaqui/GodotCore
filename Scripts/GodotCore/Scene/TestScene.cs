using Godot;
using GodotCore.Menu;
using System;


namespace GodotCore {
	namespace Scene {
		public partial class TestScene : Node
		{
            [Export] public SceneController sceneController;

            #region Godot Functions

            public override void _UnhandledInput(InputEvent @event) {
                if (@event is InputEventKey eventKey) {
                    if (eventKey.Pressed) {
                        if (eventKey.Keycode == Key.M) {
                            /*sceneController.Load(SceneType.Menu, (_scene) => {
                                Debug.Log("Scene [" + _scene + "] loaded from Test script!");
                            }, false, PageType.Loading);*/
                        }
                        else if (eventKey.Keycode == Key.G) {
                            //sceneController.Load(SceneType.Game);
                        }
                       
                    }
                }
            }

            #endregion

        }
    }
}
