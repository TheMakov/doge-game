using Godot;
using System;

public partial class ProjectileMovement : Area2D
{
	[Export]
	private float _speed = 10f;

	[Export] 
	private int _damage = 1;
	
	
	private float _randomX;
	private float _randomY;
	private Vector2 _randomDir;
	public override void _Ready()
	{
		_randomX = (float)GD.RandRange(-1.0f, 1.0f);
		_randomY = (float)GD.RandRange(-1.0f, 1.0f);
		_randomDir = new Vector2(_randomX,_randomY).Normalized();
		GD.Print(_randomDir);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var deltaF = (float)delta;
		var deltaPos = _randomDir * deltaF * 100 * _speed;
		Position += deltaPos;
	}
}
