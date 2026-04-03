using Godot;
using System;

public partial class CameraFollowMovement : Camera2D
{
	[Export]
	private float _allowedFreedom = 1;
	
	private Sprite2D _player;
	private Vector2 _lastPlayerPosition = Vector2.Zero;
	public override void _Ready()
	{
		_player = GetNode<Sprite2D>("../Player");
	}
	
	public override void _Process(double delta)
	{
		var positionDelta = _player.Position- Position;
		var playerSpeed = ( _lastPlayerPosition- _player.Position).Length()/delta;
		if (positionDelta.Length() > _allowedFreedom * 100)
		{
			GD.Print(playerSpeed);
			Position += positionDelta.Normalized() * (float)delta *  (float)playerSpeed;
		}
		_lastPlayerPosition = _player.Position;
	}
}
