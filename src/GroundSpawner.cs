using Godot;
using System;

public partial class GroundSpawner : Node2D
{
    PackedScene groundScene;
    Vector2 groundSize;
    public override void _Ready()
    {
        groundScene = GD.Load<PackedScene>("res://src/Ground.tscn");
        groundSize = GD.Load<Texture2D>("res://assets/sprites/base.png").GetSize();
        var halfGroundSize = groundSize/2;
        var bottom = GetViewport().GetWindow().Size;
        SpawnGround(new Vector2(halfGroundSize.X, bottom.Y - halfGroundSize.Y));
        SpawnGround(new Vector2(groundSize.X + halfGroundSize.X, bottom.Y - halfGroundSize.Y));
    }
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        foreach(var child in GetChildren())
        {
            if (child is StaticBody2D ground)
            {
                // GD.Print(ground.Name + ground.Position);    
            }
        }
    }


    void SpawnGround(Vector2 position)
    {
        var instance = (StaticBody2D) groundScene.Instantiate();
        AddChild(instance);
        instance.Position = position;
    }
}


