using Command.Actions;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanseCommand : IUnitCommand
{
    private bool willHitTarget;
    private const float hitChance = 0.2f;
    private int previousPower;

    public CleanseCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();

    }

    public override bool WillHitTarget() => Random.Range(0f, 1f) < hitChance;

    public override void Execute()
    {
        previousPower = targetUnit.CurrentPower;
        GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
    public override void Undo()
    {
        if (willHitTarget)
            targetUnit.CurrentPower = previousPower;

        actorUnit.Owner.ResetCurrentActiveUnit();
    }
}

