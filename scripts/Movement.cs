using Godot;

namespace NewGameProject.scripts;

public partial class Movement : Godot.Sprite2D
{
	[Export]
	private float _speed = 10f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var direction = Input.GetVector("move_left", "move_right", "move_up", "move_down").Normalized();
		if (direction.Length()> 0.2)
		{
			this.Position += direction * _speed * (float)delta;
		}
		
	}
}
