using Godot;
using System;
using System.Dynamic;

public partial class Global : Node
{
    public static Global Instance {get; private set;}
    public bool isGameOver = false;
    
    public Global(){
        Instance = this;
    }

}
