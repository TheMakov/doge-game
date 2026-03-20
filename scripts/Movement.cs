using System;
using Godot;

namespace NewGameProject.scripts;

public partial class Movement : Godot.Sprite2D
{
	[ExportGroup("Movement Properties")]
	[Export]
	private float _maxSpeed = 10f;
	[Export]
	private float _deccelTime  = 1.0f;
	[Export]
	private float _accelTime = 1.0f;

	[Export] private float _minGlideSpeed = 0.2f;
	
	private Vector2 _velocity = Vector2.Zero;
		
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		var direction = Input.GetVector("move_left", "move_right", "move_up", "move_down").Normalized();
		var deltaF = (float)delta;
		Vector2 target = direction * _maxSpeed;
		float steeringForce;
		float similarity = _velocity.Normalized().Dot(direction);
		if (direction.Length() < 0.1f)
		{
			steeringForce = 1.0f / _deccelTime;
		}
		else if(similarity > 0.7f)
		{
			steeringForce = 1.0f / (_accelTime * 0.2f);
		}
		else
		{
			steeringForce = 1.0f /_accelTime;
		}
		_velocity = _velocity.Lerp(target, steeringForce * deltaF);
		GD.Print(_velocity.Length() * 100 *deltaF);
		if (_velocity.Length() * 100 *deltaF < _minGlideSpeed && direction.Length() < 0.1f)
		{
			GD.Print("to slow, stop the player");
			_velocity = Vector2.Zero;
		}
		
		Position += _velocity * 100* deltaF;
		
	}
}
