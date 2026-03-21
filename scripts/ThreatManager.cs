using Godot;
using System;
using NewGameProject.scripts;

public partial class ThreatManager : Node
{
	[Export]
	private PackedScene _projectile;
	[Export]
	private float _spawnRatePerSecond = 1;

	[Export] private float _playerRandomRange = 1;
	[Export] private float _spawnRandomRange = 10;
	
	private double _timer;
	private Sprite2D _player;

	public override void _Ready()
	{
		_player = GetNode<Sprite2D>("../Player");
	}
	
	
	public override void _Process(double delta)
	{
		_timer += delta;
		if (_timer >= (1/_spawnRatePerSecond))
		{
			var instance = _projectile.Instantiate<ProjectileMovement>();
			
			//sets where the projectile should be created
			instance.Position = _get_random_position_around_point(Vector2.Zero,_spawnRandomRange);
			var position = _get_random_position_around_point(_player.Position, _playerRandomRange); 
			instance.SetProjectileDir(position - instance.Position);
			AddChild(instance);
			_timer = 0;
		}
	}

	private Vector2 _get_random_position_around_point(Vector2 point, float distance)
	{
		var positionDelta = new Vector2((float)GD.RandRange(-1.0f,  1.0f), (float)GD.RandRange(-1.0f, 1.0f)).Normalized() * 100 *  distance;
		point += positionDelta;
		return point;
	}
	
}
