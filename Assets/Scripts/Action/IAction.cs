using Command.Input;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    /// <summary>
    /// An interface indicating a unit action.
    /// </summary>
    public interface IAction
    {
        public TargetType TargetType { get; }

        public void PerformAction(UnitController actorUnit, UnitController targetUnit,bool isSuccesful);

        //public bool IsSuccessful();

        public Vector3 CalculateMovePosition(UnitController targetUnit);
    }
    /*
    public enum TargetType
    {
        Friendly,
        Enemy,
        Self
    }
    public enum ActionType
    {
        None,
        Attack,
        Heal,
        AttackStance,
        Cleanse,
        Meditate,
        BerserkAttack,
        ThirdEye
    }
    */
}