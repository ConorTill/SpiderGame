using Assets.Scripts.Selection;
using Assets.Scripts.Units.Spiders;
using System;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class SelectCommand : Command
    {
        public override void Execute(Vector3 mousePos, SelectedUnits selectedUnits)
        {
            try
            {
                GameObject unitToSelect = new Raycast().Cast(mousePos, Vector2.zero);
                BasicSpider spider = (unitToSelect.GetComponent(typeof(BasicSpider)) as BasicSpider);
                if (selectedUnits.contains(spider))
                {
                    selectedUnits.remove(spider);
                    spider.selected = false;
                }
                else
                {
                    selectedUnits.add(spider);
                    spider.selected = true;
                }
            }
            catch(NullReferenceException e)
            {
                selectedUnits.deselectAll();
                return;
            }
        }
    }
}
