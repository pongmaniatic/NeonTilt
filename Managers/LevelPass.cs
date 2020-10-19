using UnityEngine;

public class LevelPass : MonoBehaviour
{
    public static LevelPass goldenBlockNumber;
    public int goldenBlocksLeft = 5;
    public int gameState = 1;
    private void Awake(){goldenBlockNumber = this;}
    public void AddPoints(){goldenBlocksLeft -= 1;}

    private void Update()
    {
        if(gameState%2 == 0)
        {
            HoleManager.HoleManagerSystem.ShouldHolesBeGreenOrRed();
        }
    }
}
