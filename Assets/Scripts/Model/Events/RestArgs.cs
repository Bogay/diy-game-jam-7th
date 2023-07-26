using System;
using RogueSharpTutorial.Model;

public class RestArgs : EventArgs
{
    public Actor Actor;
    // TODO: maybe it should be named `Buffable`? need to discuss API design.
    public AttackData Value;
}

public delegate void RestEventHandler(object sender, RestArgs args);
