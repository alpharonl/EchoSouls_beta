using Godot;
using System;

public partial class Clown : CharacterBody2D
{
	public double speed = 100f;

	public override void _Ready()
	{
		Area2D attackArea = GetNode<Area2D>("AttackArea");
		attackArea.AreaEntered += OnAttackAreaEntered;
	}
	private void OnAttackAreaEntered(Area2D area)
	{
		if (area.Owner is Player player)
		{
			player.TakeDamage(10);
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		Godot.Vector2 pos = Position;
		
	}
}
