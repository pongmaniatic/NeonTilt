using System;
using Blocks;
using UnityEngine;
using TMPro;

public class Combo : MonoBehaviour
{
    public static Combo ComboSystem;
    private DestructableBlock bouncedBlock;
    private TextMeshProUGUI comboText;
    public GameObject comboGameObject;
    private GameObject playerball;
    private int currentBounce;
    private bool buildingCombo = false;
    private float cachedComboWindow;
    public int ComboTarget  = 2;
    public int ComboDifficulty;
    private int cachedComboTarget;
    private int comboTier = 1;
    private int comboMultiplier;
    public float comboWindow;

    private void Awake()
    {
        //comboGameObject = GameObject.FindGameObjectWithTag("Combo");
        playerball = GameObject.FindWithTag("PlayerBall");
        comboText = comboGameObject.GetComponent<TextMeshProUGUI>();
        bouncedBlock = GetComponent<DestructableBlock>();
        cachedComboWindow = comboWindow;
        cachedComboTarget = ComboTarget;
    }

    private void OnCollisionEnter(Collision other) //Normal-state point collection
    {
       if (other.gameObject.tag == "GoldenBlocks")
       {
           buildingCombo = true;
           comboWindow = cachedComboWindow;
           currentBounce += 1;

           if (currentBounce == ComboTarget)
           {
               ComboTarget += ComboDifficulty;
               comboTier += 1;
           }
       }
    }

    private void OnTriggerEnter(Collider other) // Bulldoze-state point collection
    {
        if (other.gameObject.tag == "GoldenBlocks")
        {
            buildingCombo = true;
            comboWindow = cachedComboWindow;
            currentBounce += 1;
            
            if (currentBounce == ComboTarget)
            {
                ComboTarget += ComboDifficulty;
                comboTier += 1;
            }
        }
    }

    private void Update()
    {
        comboWindow -= Time.deltaTime;
        //Reseting current bounce if combo-window = 0
        if (comboWindow <= 0)
        {
            buildingCombo = false;
            currentBounce = 0;
            ComboTarget = cachedComboTarget;
            comboTier = 1;
        }
        comboMultiplier = comboTier;
        comboText.text = Convert.ToString(comboMultiplier);
    }

    public int ApplyComboMultiplier(int points)
    {
        if (buildingCombo){points *= comboMultiplier;}
        return points;
    }
}
