using Godot;
using System;

public partial class HealthManager : Node
{
	[Export]
	private int _health = 3;
	
	[Signal]
	public delegate void HealthChangedEventHandler(int oldHealth, int newHealth);
	
	private void _takeDamage(int damage){
		_health -= damage;
		if(_health <= 0){
			GD.Print("game over");
		}
	}
}
