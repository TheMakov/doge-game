using System;
using Godot;

namespace NewGameProject.scripts;

public partial class Movement : Godot.Sprite2D
{
	[Export]
	private float _maxSpeed = 10f;
	[Export] 
	private Curve _accelerationCurve; // The graph slot
	[Export] 
	public float AccelTime = 1.0f; 
	[Export] 
	private Curve _deccelerationCurve; // The graph slot
	[Export]
	public float DeccelTime  = 1.0f;
	
	private float _currentAccelTime = 0f;
	private Vector2 _lastDirVector = Vector2.Zero;
	
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var direction = Input.GetVector("move_left", "move_right", "move_up", "move_down").Normalized();
		var deltaF = (float)delta;
		if (direction.Length() > 0.2)
		{
			_lastDirVector = direction;
			_currentAccelTime = Mathf.Min(_currentAccelTime + deltaF / AccelTime, 1.0f);
			var deltaPos = 100 *direction * _maxSpeed * deltaF * _accelerationCurve?.Sample(_currentAccelTime) ?? Vector2.Zero;
			Position += deltaPos ;
		}
		else
		{
			_currentAccelTime = Math.Max(_currentAccelTime - deltaF / DeccelTime, 0f);
			var deltaPos =  100 * _maxSpeed * deltaF* _lastDirVector * _deccelerationCurve?.Sample(1-_currentAccelTime) ?? Vector2.Zero;
			Position += deltaPos ;
		}
	}
}
