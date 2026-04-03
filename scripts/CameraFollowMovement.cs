using Godot;
using System;
using NewGameProject.scripts;

public partial class CameraFollowMovement : Camera2D
{
	[Export]
	private float _allowedFreedom = 1;
	[Export]
	private float _cameraSpeed = 4f;

	[Export] 
	private float _maxPlayerCameraDistance = 2f;
	
	private Movement _player;
	private Vector2 _lastPlayerPosition = Vector2.Zero;
	public override void _Ready()
	{
		_player = GetNode<Movement>("../Player");
	}
	
	public override void _Process(double delta)
	{
		_MoveCameraPlayerInBack(delta);
	}

	private void _MoveCameraPlayerInBack(double delta)
	{
		var inputDirection = Input.GetVector("move_left", "move_right", "move_up", "move_down").Normalized();
		var targetLocation = _player.Position + inputDirection * _maxPlayerCameraDistance * 100f;
		var cameraMoveDirection = targetLocation - Position;
		var distance = cameraMoveDirection.Length();
		var factor = distance / (_maxPlayerCameraDistance * 100f);
		GD.Print(factor+" "+factor*_cameraSpeed * 10 +" "+ _player.GetVelocity()*1.2f);
		var speed = Math.Max(factor*_cameraSpeed * 4, _player.GetVelocity()*2f); 
		Position += cameraMoveDirection.Normalized()  * speed * (float)delta * 100f;
		
		_lastPlayerPosition = _player.Position;
	}
	private void _MoveCameraPlayerInFront(double delta)
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
