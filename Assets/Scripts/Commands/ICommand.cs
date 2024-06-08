using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    // This method defines the contract for executing a command.
    public void Execute();

    public void Undo();
}
