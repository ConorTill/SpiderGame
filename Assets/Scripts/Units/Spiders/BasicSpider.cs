using UnityEngine;

namespace Assets.Scripts.Units.Spiders
{
    public class BasicSpider : Unit
    {
        public void Start()
        {
            isDead = false;
            selected = false;
            pos = transform.position;
            range = 0.5f;
            attackTimer = 0;
            health = 20;
            weaponDamage = 2;
        }

        public GameObject Spider { get; set; }

        public bool isDead;
        private Vector3 destination;
        public bool destinationReached;
        private GameObject target;
        private float range;
        private int attackTimer;
        private int weaponDamage;
        public bool attacking;

        public void moveTo()
        {
            if (!destinationReached)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, 0.1f);
                if (destination == pos)
                    destinationReached = true;
            }
        }

        public void attackTarget()
        {
            var distance = Vector2.Distance(target.transform.position, transform.position);
            if (distance > range)
            {
                setDestination(target.transform.position);
                moveTo();
            } else if (attackTimer <= 0)
            {
                target.GetComponent<BasicSpider>().takeDamage(weaponDamage);
                attackTimer = 50;
            }
        }

        public void takeDamage(int damage)
        {
            if (health <= 0)
                return;
            health -= damage;
            if (health <= 0)
                isDead = true;
        }

        public void setDestination(Vector3 destination)
        {
            destination.z = 0;
            this.destination = destination;
            destinationReached = false;
        }

        public void setTarget(GameObject target)
        {
            this.target = target;
            attacking = true;
        }

        public void FixedUpdate()
        {
            pos = transform.position;
            if (attackTimer > 0)
            {
                attackTimer--;
            }
            if (attacking)
            {
                if (target)
                {
                    attackTarget();
                }
            }
            else
            {
                moveTo();
            }
        }

        public void Update()
        {
            if (transform.childCount != 0)
            {
                if (selected)
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
}
