using Godot;

namespace GodotCore {
	namespace Menu {
		public partial class TestMenu : Node{

			[Export] public PageController pageController;

            #region Godot Functions

            public override void _UnhandledInput(InputEvent @event) {
				if(@event is InputEventKey eventKey) {
					if(eventKey.Pressed) {
						if(eventKey.Keycode == Key.U) {
                            pageController.TurnPageOn(PageType.Loading);
                        }
                        else if (eventKey.Keycode == Key.J) {
                            pageController.TurnPageOff(PageType.Loading);
                        }
                        else if (eventKey.Keycode == Key.M) {
                            pageController.TurnPageOff(PageType.Loading, PageType.Menu); // Crossfade
                        }
                        else if (eventKey.Keycode == Key.I) {
                            pageController.TurnPageOff(PageType.Loading, PageType.Menu, true); 
                        }
                        else if (eventKey.Keycode == Key.K) {
                            pageController.TurnPageOff(PageType.Loading, PageType.Test, false); // Turn off the first completely, then turn on the other
                        }
                        else if (eventKey.Keycode == Key.Comma) {
                            pageController.TurnPageOff(PageType.Loading, PageType.Test, true);  // Crossfade
                        }
                    }
				}
			}

			#endregion

		}
	}
}
