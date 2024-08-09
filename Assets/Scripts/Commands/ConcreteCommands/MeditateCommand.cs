using Command.Actions;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Commands
{
    public class MeditateCommand : UnitCommand
    {
        private bool willHitTarget;

        public MeditateCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override bool WillHitTarget() => true;

        public override void Undo()
        {
            if (willHitTarget)
            {
                var healthToIncrease = (int)(targetUnit.CurrentMaxHealth * 0.2f);
                targetUnit.CurrentMaxHealth -= healthToIncrease;
                targetUnit.TakeDamage(healthToIncrease);
            }
        }
    }
}
