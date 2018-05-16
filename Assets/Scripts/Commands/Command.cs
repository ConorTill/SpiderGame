using Assets.Scripts.Selection;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class Command
    {
        public virtual void Execute()
        {

        }

        public virtual void Execute(Vector3 mousePos, SelectedUnits selectedUnits)
        {

        }

        public virtual void Execute(GameObject target, SelectedUnits selectedUnits)
        {

        }

        public virtual void Execute(Vector3 boxStart, Vector3 mousePos, SelectedUnits selectedUnits)
        {

        }
    }
}
