using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{

    // A stack to keep track of executed commands.
    private Stack<ICommand> commandRegistry=new Stack<ICommand>();

    /// Process a command, which involves both executing it and registering it.
    public void ProcessCommand(ICommand commandToProcess)
    {
        ExecuteCommand(commandToProcess);
        RegisterCommand(commandToProcess);
    }
    /// Execute a command, invoking its associated action.
    
    public void ExecuteCommand(ICommand commandToExecute)=>commandToExecute.Execute();

    /// Register a command by adding it to the command registry stack.By using Push 
    
   
    public void RegisterCommand(ICommand commandToRegister)=>commandRegistry.Push(commandToRegister);

    

    public void Undo()
    {
        if (!RegistryEmpty() && CommandBelongsToActivePlayer())
            commandRegistry.Pop().Undo();
    }
    private bool RegistryEmpty() => commandRegistry.Count == 0;

    private bool CommandBelongsToActivePlayer() => (commandRegistry.Peek() as IUnitCommand).commandData.ActorPlayerID == GameService.Instance.PlayerService.ActivePlayerID;


}