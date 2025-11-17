using Godot;
using System;

public partial class Ground : StaticBody2D
{
    [Export] int baseSpeed = 80;
    Vector2 velocity;
    public override void _Ready()
    {
        base._Ready();
        velocity = Vector2.Left * baseSpeed;
        
        
    }


    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        try
        {
        if (!Global.Instance.isGameOver)
        {
            MoveAndCollide(velocity * (float) delta);
        }  
        }
        catch (NullReferenceException)
        {
            GD.Print("Error");
        }

    }

}
