using UnityEngine;

namespace Blocks
{
    public class BouncyBlock : BlockBase
    {
        public override void Start()
        {
            Rigidbody body = GetComponent<Rigidbody>();
            body.constraints = RigidbodyConstraints.FreezeAll;
        }
        public override void Bounce(Rigidbody body, ContactPoint point)
        {
            Vector3 velocity = Vector3.Reflect(body.velocity, point.normal);
            body.velocity = velocity.normalized * bouncySpeed; 
        }
        public override void OnCollisionEnter(Collision other)
        {
            if (!other.rigidbody) return;
            ContactPoint[] contactPoints = other.contacts;
            ContactPoint contactpoint = contactPoints[0];
            Bounce(other.rigidbody, contactpoint);
        }
    }
}