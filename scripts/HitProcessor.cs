using Godot;
using System;

public partial class HitProcessor : Area2D
{
	private void _on_area_entered(Area2D area){
		GD.Print(area.Name);
		if(area is ProjectileMovement script)
		{
			GD.Print("player has been hit");
		}
	}
}
