﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public CircleController circleController;
    //public PlayerShooting playerShooting;

    //Queue untuk menyimpan list command
    Queue<Command> commands = new Queue<Command>();

    void FixedUpdate()
    {
        //Menghandle input movement
        Command moveCommand = InputMovementHandling();
        if (moveCommand != null)
        {
            commands.Enqueue(moveCommand);

            moveCommand.Execute();
        }
    }

    void Update()
    {
        
    }

    Command InputMovementHandling()
    {
        //Check jika movement sesuai dengan key nya
        if (Input.GetKey(KeyCode.D))
        {
            return new MoveCommand(circleController, 1, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            return new MoveCommand(circleController, -1, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            return new MoveCommand(circleController, 0, 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            return new MoveCommand(circleController, 0, -1);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            //Undo movement
            return Undo();
        }
        else
        {
            return new MoveCommand(circleController, 0, 0); ;
        }
    }

    Command Undo()
    {
        //Jika Queue command tidak kosong, lakukan perintah undo
        if (commands.Count > 0)
        {
            Command undoCommand = commands.Dequeue();
            undoCommand.UnExecute();
        }
        return null;
    }

    /*Command InputShootHandling()
    {
        //Jika menembak trigger shoot command
        if (Input.GetButtonDown("Fire1"))
        {
            return new ShootCommand(playerShooting);
        }
        else
        {
            return null;
        }
    }*/
}
