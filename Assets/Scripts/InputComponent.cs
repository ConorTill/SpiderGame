using UnityEngine;
using Assets.Scripts.Commands;
using Assets.Scripts.Factories;
using Assets.Scripts.Selection;
using Assets.Scripts;

public class InputComponent : MonoBehaviour {

    Command leftMouse;
    Command moveCommand;
    Command attackCommand;

    public SpiderFactory spiderFactory;
    public SelectedUnits selectedUnits;
    public BoxSelector boxSelector;

    Vector3 oldMousePos;

	void Awake () {
        selectedUnits = new SelectedUnits();
        leftMouse = new SelectCommand();
        moveCommand = new MoveCommand();
        attackCommand = new AttackCommand();
	}

    void Update () {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            oldMousePos = mousePos;
            boxSelector.boxStart = mousePos;
            leftMouse.Execute(mousePos, selectedUnits);
        }

        if (Input.GetMouseButton(0))
        {
            var difference = Vector3.Distance(oldMousePos, mousePos);
            if (difference > 0.05)
            {
                boxSelector.mousePos = mousePos;
                boxSelector.active = true;
                boxSelector.Select(ref selectedUnits);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            boxSelector.active = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject target = new Raycast().Cast(mousePos, Vector3.zero);

            if (target == null) {
                moveCommand.Execute(mousePos, selectedUnits);
            } else if (target)
            {
                attackCommand.Execute(target, selectedUnits);
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            spiderFactory.createSpider(mousePos);
        }
	}
}
