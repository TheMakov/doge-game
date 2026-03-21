using Godot;
using System;

public partial class ThreatManager : Node
{
	[Export]
	private PackedScene _projectile;
	[Export]
	private float _spawnRatePerSecond = 1;
	
	private double _timer;
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_timer += delta;
		if (_timer >= (1/_spawnRatePerSecond))
		{
			var instance = _projectile.Instantiate<Area2D>();
			instance.Position = Vector2.Zero;
			AddChild(instance);
			_timer = 0;
		}
	}
}
