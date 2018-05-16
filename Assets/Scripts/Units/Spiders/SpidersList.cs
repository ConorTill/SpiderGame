using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Units.Spiders
{
    public class SpidersList : MonoBehaviour
    {
        public List<BasicSpider> spidersList = new List<BasicSpider>();

        public void addSpider(BasicSpider spider)
        {
            spidersList.Add(spider);
        }

        public void deleteDead()
        {
            foreach(var spider in spidersList)
            {
                if (spider.isDead)
                {
                    spidersList.Remove(spider);
                }
            }
        }

        public bool contains(BasicSpider spider)
        {
            return spidersList.Contains(spider);
        }

        public void remove(BasicSpider spider)
        {
            spidersList.Remove(spider);
        }

        public void Update()
        {
            deleteDead();
        }
    }
}
