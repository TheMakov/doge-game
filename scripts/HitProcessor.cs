using Godot;

namespace NewGameProject.scripts;

public partial class HitProcessor : Area2D
{
	private HealthManager _healthManager;
	public override void _Ready()
	{
		_healthManager = GetNode<HealthManager>("../HealthManager");
	}
	private void _on_area_entered(Area2D area){
		if(area is ProjectileMovement projectile)
		{
			_healthManager.EmitSignal(HealthManager.SignalName.DamageTaken, projectile.Damage);
		}
	}
}
