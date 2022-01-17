using UnityEngine;

namespace Blocks
{
    [RequireComponent(typeof(Rigidbody))]
    public class BlockBase : MonoBehaviour
    {
        public int health = default;
        public int damage = default;
        public int points = default;
        public float bouncySpeed = default;

        public virtual void Start()
        {
            //stuff here
        }

        public virtual void TakeDamage(int x)
        {
            //Take damage here
        }

        public virtual void Die()
        {
            //Die
        }

        public virtual void OnCollisionEnter(Collision other)
        {
            //use this to perform checks when the ball hits 
        }

        public virtual void Bounce(Rigidbody body, ContactPoint point)
        {
            //Bounce here
        }
    }
}