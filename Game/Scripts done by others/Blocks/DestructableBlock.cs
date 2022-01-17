using System;
using System.Collections;
using UnityEngine;

namespace Blocks
{
    public class DestructableBlock : BlockBase
    {
        //PowerUpStuff
        private GameObject playerBall;
        private BoxCollider boxColliderTrigger;
        private BallMovement ballMovementScript;

        //Combo stuff
        //private int cachedPoints;

        //ScreenShake stuff
        private FlashWhenStruck screenShakeScript;
        private float deathShake = 0.02f; // Magic number because it need to be very low

        //VFX stuff
        public GameObject redExplosionEffect;
        public GameObject redExplosionLight;
        public GameObject yellowExplosionEffect;
        public GameObject yellowExplosionLight;

        //SFX stuff
        private BlockAudioClips blockAudioClips;

        public override void Start()
        {
            //PowerUpStuff
            playerBall = GameObject.FindWithTag("PlayerBall");
            boxColliderTrigger = gameObject.GetComponent<BoxCollider>();
            ballMovementScript = playerBall.GetComponent<BallMovement>();

            //Combo stuff
            //cachedPoints = points;

            //ScreenShake stuff
            screenShakeScript = GetComponent<FlashWhenStruck>();

            Rigidbody body = GetComponent<Rigidbody>();
            body.constraints = RigidbodyConstraints.FreezeAll;

            blockAudioClips = GetComponent<BlockAudioClips>();
        }

        private void FixedUpdate()
        {
            if (ballMovementScript.isPoweredUp)
            {
                boxColliderTrigger.isTrigger = true;
            }
            else
            {
                if (boxColliderTrigger.isTrigger) boxColliderTrigger.isTrigger = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "PlayerBall")
            {
                //Bounce VFX
                Instantiate(yellowExplosionEffect, transform);

                int returnedValue = other.gameObject.GetComponent<Combo>().ApplyComboMultiplier(points);
                PlayerHighScore.pointsSystem.AddScore(returnedValue);
                screenShakeScript.DissolveOnDeath();
                StartCoroutine(deathDelay());
            }
        }

        public override void OnCollisionEnter(Collision other)
        {
            if (!other.rigidbody) return;
            ContactPoint[] contactPoints = other.contacts;
            ContactPoint contactpoint = contactPoints[0];
            Bounce(other.rigidbody, contactpoint);
            TakeDamage(5); //Todo fix sumthing

            //Combo stuff
            if (other.gameObject.tag == "PlayerBall")
            {
                int returnedValue = other.gameObject.GetComponent<Combo>().ApplyComboMultiplier(points);
                //Debug.Log("POINTS ARE NOW = " + returnedValue);
                PlayerHighScore.pointsSystem.AddScore(returnedValue);
            }
        }

        public override void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 1)
            {
                screenShakeScript.DissolveOnDeath();
                StartCoroutine(deathDelay());
            }
        }

        public override void Die()
        {
            LevelPass.goldenBlockNumber.AddPoints();
            gameObject.SetActive(false);
            HoleManager.HoleManagerSystem.ShouldHolesBeGreenOrRed();
        }

        public override void Bounce(Rigidbody body, ContactPoint point)
        {
            var lightEffect = Instantiate(yellowExplosionLight,transform);
            StartCoroutine(VFXStuff(lightEffect));
            blockAudioClips.PlayBounceAudio();
            Vector3 velocity = Vector3.Reflect(body.velocity, point.normal);
            velocity.y = -0.5f; // to not bounce upwards
            body.velocity = velocity.normalized * bouncySpeed;
        }

        private IEnumerator deathDelay()
        { 
            //ScreenShake stuff
            screenShakeScript.ScreenShake(screenShakeScript.shakeLength, screenShakeScript.shakePower + deathShake);
            screenShakeScript.LateUpdate();
            blockAudioClips.PlayDestuctionAudio();
            yield return new WaitForSeconds(0.2f); // 0.2
            Die();
            yield return null;
        }

        private IEnumerator VFXStuff(GameObject lightEffect)
        {
            Instantiate(yellowExplosionEffect, transform);
            yield return new WaitForSeconds(0.1f);
            Destroy(lightEffect);
            yield return null;
        }
    }
}