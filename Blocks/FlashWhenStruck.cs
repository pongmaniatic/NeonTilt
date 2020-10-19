using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlashWhenStruck : MonoBehaviour
{
    //DissolveObject prefab
    public GameObject disolveDeath;
    
    //Chromatic Effect Setup
    [Range(0f, 10f)] public float chromaticHitEffect = 1;

    //ScreenShake Setup
    private GameObject entityManager;
    private Camera screenshakeCamera;
    private float _shakeTimeRemaining;
    [Range(0f,0.5f)]public float shakePower;
    [Range(0f,2f)]public float shakeLength;
    private bool onlyRunOnce = false;
    
    //Setup for flashing
    private Material _defaultMaterial;
    public Material flashMaterial;
    public float flashTime;
    private MeshRenderer _mesh;

    private void Awake()
    {
        //More screenshake setup
        entityManager = GameObject.Find("EntityManager");

        //More flash-setup
        _mesh = gameObject.GetComponent<MeshRenderer>();
        flashTime = 0.1f;
        _defaultMaterial = _mesh.material;
    }

    public void OnCollisionEnter(Collision other) // REMEMBER TO SET BALL TAG TO PlayerBall!
    {
        if (other.gameObject.tag == "PlayerBall")
        {
            EntityManager.s.chromaticHitEffect.Effect(chromaticHitEffect); 
            FlashColor(); 
           ScreenShake(shakeLength, shakePower);
        }
    }

    private void OnTriggerEnter(Collider other) // This is for when player is in bulldoze-mode
    {
        if (other.gameObject.tag == "PlayerBall")
        {
            EntityManager.s.chromaticHitEffect.Effect(chromaticHitEffect); 
            FlashColor(); 
            ScreenShake(shakeLength, shakePower);
        } 
    }

    public void FlashColor()
    {
        _mesh.material = flashMaterial;
        StartCoroutine(Flasher());
    }

    public void LateUpdate() //Screenshake
    {
        //Find Camera
        if (entityManager.GetComponent<UltimateGameManager>().menuMode == false && onlyRunOnce == false)
        {
            screenshakeCamera = GameObject.FindWithTag("GameCamera").GetComponent<Camera>();
            onlyRunOnce = true;
        }
        while (_shakeTimeRemaining > 0)
        {
            _shakeTimeRemaining -= Time.deltaTime;
            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;
            float zAmount = Random.Range(-1f, 1f) * shakePower;
            screenshakeCamera.transform.position += new Vector3(xAmount,yAmount,zAmount);
            return;
        }
    }
    public void ScreenShake(float length, float power)
    {
        _shakeTimeRemaining = length;
        shakePower = power;
    }
    private IEnumerator Flasher() // Resetting to the original material
    {
        yield return new WaitForSeconds(flashTime);
        _mesh.material = _defaultMaterial;
        yield return null;
        
    }

    public void DissolveOnDeath() // Makes the block melt away on death
    {
        Instantiate(disolveDeath,gameObject.transform.position,gameObject.transform.rotation);
    }
}
