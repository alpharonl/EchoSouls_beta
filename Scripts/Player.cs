using Godot;
using System;

public partial class Player : CharacterBody2D
{
	/*
		TODO:
		1- fazer com que o player receba dano enquanto estiver na are de >ATAQUE< de qualquer bixo do grupo inimigo
		2- adionar novos elementos da UI
	*/
	float speed = 100f;
	public int lifeP = 100;
	private bool takingdamage = false;
	private float damageTimer = 0f;
	private float damageInterval = 0.5f;
	AnimatedSprite2D anim;
	Area2D hitbox;
	Label LifeUI;
	public override void _Ready()
	{
		anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		hitbox = GetNode<Area2D>("HitBox");
		LifeUI = GetNode<Label>("/root/Main/CanvasLayer/Label");
		hitbox.AreaEntered += OnHitBoxEntered;
		hitbox.AreaExited += OnHitBoxExited;
		LifeUI.Text = $"{lifeP}";
	}
	private void OnHitBoxEntered(Area2D area)
	{
		if (area.IsInGroup("Enemy"))
		{
			takingdamage = true;
		}
	}
	private void OnHitBoxExited(Area2D area)
	{
		if (area.IsInGroup("Enemy"))
		{
			takingdamage = false;
		}
	}
	public void TakeDamage(int damage)
	{
		lifeP -= damage;
		if (lifeP <= 0)
		{
			lifeP = 0;
		}
		LifeUI.Text = $"{lifeP}";
	}
	public override void _PhysicsProcess(double delta)
	{
		//atualiza o dano que o player recebe a cada tick que o phisics processa
		if (takingdamage)
		{
			damageTimer += (float)delta;
			if (damageTimer >= damageInterval)
			{
				TakeDamage(10);
				damageTimer = 0f;
			}
			else
			{
				damageTimer = 0f;
			}
		}

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
		if(!mov)
		{	
			anim.Play("Parado");
		}
		Position = pos;
	}
}
