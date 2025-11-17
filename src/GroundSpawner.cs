using Godot;
using System;
public partial class GroundSpawner : Node2D
{
    PackedScene groundScene;
    Vector2 groundSize;
    Vector2 halfGroundSize;
    Vector2 spawnGroundPosition; 
    public override void _Ready()
    {
        groundScene = GD.Load<PackedScene>("res://src/Ground.tscn");
        groundSize = GD.Load<Texture2D>("res://assets/sprites/base.png").GetSize();
        halfGroundSize = groundSize/2; 
        var bottom = GetViewport().GetWindow().Size;
        spawnGroundPosition = new Vector2(groundSize.X + halfGroundSize.X, bottom.Y - halfGroundSize.Y);
        SpawnGround(new Vector2(halfGroundSize.X, bottom.Y - halfGroundSize.Y));
        SpawnGround(spawnGroundPosition);
    }
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        foreach(var child in GetChildren())
        {
            if (child is StaticBody2D ground)
            {
                var groundRight = ground.Position.X + halfGroundSize.X;
                if(groundRight <= 2) 
                // ^ i'd like to know why there's a gap between them if i set this to 0 instead of 2
                {
                    ground.QueueFree();
                    SpawnGround(spawnGroundPosition);
                }
                // GD.Print(ground.Name + ground.Position);    
            }
        }
    }


    void SpawnGround(Vector2 position)
    {
        var instance = (StaticBody2D) groundScene.Instantiate();
        AddChild(instance);
        instance.GlobalPosition = position;
    }
}


