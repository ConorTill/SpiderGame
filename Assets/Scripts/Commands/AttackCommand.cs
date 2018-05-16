using Assets.Scripts.Selection;
using Assets.Scripts.Units.Spiders;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class AttackCommand : Command
    {
        public override void Execute(GameObject target, SelectedUnits selectedUnits)
        {
            foreach (BasicSpider spider in selectedUnits.selectedUnits)
            {
                spider.setTarget(target);
            }
        }
    }
}
