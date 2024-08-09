using Command.Actions;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Command.Commands
{
    public class ThirdEyeCommand : UnitCommand
    {
        private bool willHitTarget;

        public ThirdEyeCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.ThirdEye).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override bool WillHitTarget() => true;

        public override void Undo()
        {
            if (willHitTarget)
            {
                int healthToConvert = (int)(targetUnit.CurrentHealth * 0.25f);
                targetUnit.RestoreHealth(healthToConvert);
                targetUnit.CurrentPower -= healthToConvert;
            }
        }
    }
}
