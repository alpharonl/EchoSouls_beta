using Godot;
using System;

public partial class Player : CharacterBody2D
{
	float speed = 200f;
	public int vidaP = 100;
	AnimatedSprite2D anim;
	Area2D hitbox;
	public override void _Ready()
	{
		anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		hitbox = GetNode<Area2D>("HitBox");
		hitbox.AreaEntered += OnHitBoxEntered;
	}
	private void OnHitBoxEntered(Area2D area)
	{
		if (area.IsInGroup(""))
		{
			TakeDamage(10);

		}
	}
	public void TakeDamage(int damage)
	{
		vidaP -= damage;
		if (vidaP <= 0)
		{
			print("echo morreu XDDDDD");
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		bool mov = false;
		Godot.Vector2 pos = Position;
		if (Godot.Input.IsKeyPressed(Key.W))
		{
			pos.Y -= speed * (float)delta;
			anim.Play("Tras");
			mov = true;
		}
		if (Godot.Input.IsKeyPressed(Key.S))
		{
			pos.Y += speed * (float)delta;
			anim.Play("Frente");
			mov = true;
		}
		if (Godot.Input.IsKeyPressed(Key.A))
		{
			pos.X -= speed * (float)delta;
			anim.Play("Esquerda");
			mov = true;
		}
		if (Godot.Input.IsKeyPressed(Key.D))
		{
			pos.X += speed * (float)delta;
			anim.Play("Direita");
			mov = true;
		}
		else
		{
			anim.Play("Parado");
		}
		Position = pos;
	}
}
