using Assets.Scripts.Units.Spiders;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class SpiderFactory : MonoBehaviour
    {
        public GameObject prefab;
        public SpidersList spidersList;

        public void createSpider(Vector3 pos)
        {
            GameObject spiderParent = Instantiate(prefab) as GameObject;
            BasicSpider spider = spiderParent.GetComponent("BasicSpider") as BasicSpider;
            pos.z = 0;
            spiderParent.transform.position = pos;
            spider.setDestination(pos);
            spidersList.addSpider(spider);
        }
    }
}
