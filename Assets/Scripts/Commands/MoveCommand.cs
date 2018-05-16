using Assets.Scripts.Selection;
using Assets.Scripts.Units.Spiders;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class MoveCommand : Command
    {
        public override void Execute(Vector3 destination, SelectedUnits selectedUnits)
        {
            foreach(BasicSpider spider in selectedUnits.selectedUnits)
            {
                spider.setDestination(destination);
                spider.attacking = false;
            }
        }
    }
}
