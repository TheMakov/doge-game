using Godot;

namespace NewGameProject.scripts;

public partial class HealthManager : Node
{
	[Export]
	private int _health = 3;
	
	[Signal]
	public delegate void DamageTakenEventHandler(int damage);
	
	

	public override void _Ready()
	{
		DamageTaken += _takeDamage; 
	}
	
	protected void _takeDamage(int damage){
		GD.Print("damage taken");
		_health -= damage;
		if(_health <= 0){
			GD.Print("game over");
		}
	}
}
