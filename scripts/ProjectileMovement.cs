using Godot;

namespace NewGameProject.scripts;

public partial class ProjectileMovement : Area2D
{
	[Export]
	private float _speed = 10f;

	[Export] 
	public int Damage = 1;
	
	[Export]
	public float Lifetime = 10f;
	
	
	
	private float _randomX;
	private float _randomY;
	private Vector2 _projectileDir;
	public override void _Ready()
	{
		_randomX = (float)GD.RandRange(-1.0f, 1.0f);
		_randomY = (float)GD.RandRange(-1.0f, 1.0f);
		//_projectileDir = new Vector2(_randomX,_randomY).Normalized(); 
		_startProjectileLife();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var deltaF = (float)delta;
		var deltaPos = _projectileDir * deltaF * 100 * _speed;
		Position += deltaPos;
	}
	
	public void SetProjectileDir(Vector2 dir)
	{
		_projectileDir = dir.Normalized();
	}
	
	private async void _startProjectileLife()
	{
		await ToSignal(GetTree().CreateTimer(Lifetime), SceneTreeTimer.SignalName.Timeout);
		QueueFree();
	}
	
	private void _on_area_entered(Area2D area){
		if (area.GetParent().Name == "Player")
		{
			QueueFree();
		}
	}
}
