using Godot;

[System.Serializable]
public partial class GameData : GodotObject {
	
    public int counter;

    // Default the values of the persistance-tracked objects
    // Default values used when there's no data to load
    public GameData() {
        counter = 0;
    }
    
}
