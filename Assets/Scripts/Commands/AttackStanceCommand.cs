using Command.Actions;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStanceCommand : IUnitCommand
{
    private bool willHitTarget;

    public AttackStanceCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();

    }

    public override bool WillHitTarget() => true;

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance).PerformAction(actorUnit, targetUnit, willHitTarget);
    public override void Undo()
    {
        if (willHitTarget)
        {
            targetUnit.CurrentPower -= (int)(targetUnit.CurrentPower * 0.2f);
            actorUnit.Owner.ResetCurrentActiveUnit();
        }
    }
}
