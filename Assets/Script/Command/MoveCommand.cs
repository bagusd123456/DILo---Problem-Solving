using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    CircleController circleController;
    float h, v;

    public MoveCommand(CircleController _circleController, float _h, float _v)
    {
        this.circleController = _circleController;
        this.h = _h;
        this.v = _v;
    }

    //Trigger perintah movement
    public override void Execute()
    {
        circleController.Move(h, v);
        //Menganimasikan player
        //playerMovement.Animating(h, v);
    }

    public override void UnExecute()
    {
        //Invers arah dari movement player
        circleController.Move(-h, -v);
        //Menganimasikan player
        //playerMovement.Animating(h, v);
    }
}
