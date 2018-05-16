using Assets.Scripts.Units;
using Assets.Scripts.Units.Spiders;
using System.Collections.Generic;

namespace Assets.Scripts.Selection
{
    public class SelectedUnits
    {
        public List<BasicSpider> selectedUnits;

        public SelectedUnits()
        {
            selectedUnits = new List<BasicSpider>();
        }

        public void add(BasicSpider selectedUnit)
        {
            if (selectedUnits.Contains(selectedUnit))
                return;
            selectedUnits.Add(selectedUnit);
            selectedUnit.selected = true;
        }

        public void remove(BasicSpider spider)
        {
            if (selectedUnits.Contains(spider))
            {
                selectedUnits.Remove(spider);
                spider.selected = false;
            }
        }

        public bool contains(BasicSpider spider)
        {
            return selectedUnits.Contains(spider);
        }

        public void deselectAll()
        {
            foreach(var spider in selectedUnits)
            {
                spider.selected = false;
            }
            selectedUnits.Clear();
        }
    }
}
