using Command.Actions;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeditateCommand : IUnitCommand
{
    private bool willHitTarget;
    private int previousMaxHealth;

    public MeditateCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();

    }

    public override bool WillHitTarget() => true;

    public override void Execute() {
        previousMaxHealth = targetUnit.CurrentMaxHealth;
        GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);
    } 
    public override void Undo()
    {
        if (willHitTarget)
        {
            var healthToReduce = targetUnit.CurrentMaxHealth - previousMaxHealth;
            targetUnit.CurrentMaxHealth = previousMaxHealth;
            targetUnit.TakeDamage(healthToReduce);
        }
        actorUnit.Owner.ResetCurrentActiveUnit();
    }
}

