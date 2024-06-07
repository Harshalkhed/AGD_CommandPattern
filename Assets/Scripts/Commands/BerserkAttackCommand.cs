using Command.Actions;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkAttackCommand : IUnitCommand
{
    private bool willHitTarget;
    private const float hitChance = 0.66f;

    public BerserkAttackCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();

    }

    public override bool WillHitTarget() => Random.Range(0f, 1f) < hitChance;

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);
    public override void Undo()
    {
        if (willHitTarget)
        {
            if (!targetUnit.IsAlive())
                targetUnit.Revive();

            targetUnit.RestoreHealth(actorUnit.CurrentPower * 2);
        }
        else
        {
            if (!actorUnit.IsAlive())
                actorUnit.Revive();

            actorUnit.RestoreHealth(actorUnit.CurrentPower * 2);
        }
        actorUnit.Owner.ResetCurrentActiveUnit();
    }
}
