using Command.Actions;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCommand :IUnitCommand
{
    private bool willHitTarget;

    public HealCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();

    }

    public override bool WillHitTarget() => true;

    public override void Execute()=>GameService.Instance.ActionService.GetActionByType(CommandType.Heal).PerformAction(actorUnit,targetUnit,willHitTarget);

    public override void Undo()
    {
        if (willHitTarget)
        {
            targetUnit.TakeDamage(actorUnit.CurrentPower);
            actorUnit.Owner.ResetCurrentActiveUnit();
        }
    }

}
