using Assets.Scripts.Units;
using Assets.Scripts.Units.Spiders;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Selection
{
    public class BoxSelector : MonoBehaviour
    {
        public Image image;
        public bool active;
        public Vector3 boxStart;
        public Vector3 mousePos;
        public SpidersList allSpiders;
        private Rect rect;

        public void Select(ref SelectedUnits selectedUnits)
        {
            foreach(BasicSpider spider in allSpiders.spidersList)
            {
                if (rect.Contains(spider.transform.position))
                {
                    selectedUnits.add(spider);
                } else
                {
                    selectedUnits.remove(spider);
                }
            }
        }

        private void OnGUI()
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            boxStart.z = 0;
            mousePos.z = 0;
            rect = new Rect();

            if (mousePos.x < boxStart.x)
            {
                rect.xMin = mousePos.x;
                rect.xMax = boxStart.x;
            }
            else
            {
                rect.xMin = boxStart.x;
                rect.xMax = mousePos.x;
            }

            if(mousePos.y < boxStart.y)
            {
                rect.yMin = mousePos.y;
                rect.yMax = boxStart.y;
            }
            else
            {
                rect.yMin = boxStart.y;
                rect.yMax = mousePos.y;
            }

            image.rectTransform.offsetMin = rect.min;
            image.rectTransform.offsetMax = rect.max;
            image.gameObject.SetActive(active);
        }
    }
}
