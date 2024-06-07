using Command.Actions;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkAttackCommand : IUnitCommand
{
    private bool willHitTarget;

    public BerserkAttackCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();

    }

    public override bool WillHitTarget() => true;

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);

}
