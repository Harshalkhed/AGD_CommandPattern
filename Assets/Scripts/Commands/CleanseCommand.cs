using Command.Actions;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanseCommand : IUnitCommand
{
    private bool willHitTarget;

    public CleanseCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();

    }

    public override bool WillHitTarget() => true;

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);

}

