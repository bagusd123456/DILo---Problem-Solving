using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : Command
{
    CircleController circleController;
    float h, v;

    public ShootCommand(CircleController _playerShooting, float _h, float _v)
    {
        circleController = _playerShooting;
        this.h = _h;
        this.v = _v;
    }

    public override void Execute()
    {
        //Player menembak
        circleController.MoveMouse(h, v);
    }

    public override void UnExecute()
    {
        circleController.MoveMouse(-h, -v);
    }
}
