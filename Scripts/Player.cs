using Godot;
using System;

public partial class Player : CharacterBody2D
{
	float speed = 200f;
	AnimatedSprite2D anim;
	public override void _Ready()
	{
		anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	public override void _PhysicsProcess(double delta)
	{
		Godot.Vector2 pos = Position;
		if (Godot.Input.IsKeyPressed(Key.W))
		{
			pos.Y -= speed * (float)delta;
			anim.Play("Tras");
		}
		if (Godot.Input.IsKeyPressed(Key.S))
		{
			pos.Y += speed * (float)delta;
			anim.Play("Frente");
		}
		if (Godot.Input.IsKeyPressed(Key.A))
		{
			pos.X -= speed * (float)delta;
			anim.Play("Esquerda");
		}
		if (Godot.Input.IsKeyPressed(Key.D))
		{
			pos.X += speed * (float)delta;
			anim.Play("Direita");
		}
		else
		{
			anim.Play("Parado");
		}
		Position = pos;
	}
}
