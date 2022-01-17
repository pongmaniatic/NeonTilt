using System.Drawing;
using UnityEngine;

public class ExitFloorCollider : MonoBehaviour
{
    public CameraRotation CameraHolder;
    public int goldenBlockToCollect;
    public int loseTimeAmount;
    public Transform respawnPoint;
    public GameObject ball;
    public AudioClip nextLevelSound;
    public AudioClip teleportSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBall"  )
        {
            if (LevelPass.goldenBlockNumber.goldenBlocksLeft <= 0)
            {
                HighScoreTimer.highScoreSystem.StartBonusScoreAdd();
                CameraHolder.CurrentFloor += 1;
                LevelPass.goldenBlockNumber.goldenBlocksLeft = goldenBlockToCollect;
                SoundManager.PlaySound(nextLevelSound, transform.position, new Vector2(2, 2), false);
                Combo.ComboSystem.comboWindow += 5;
            }
            else
            {
                UltimateGlobalTimer.ultimateGlobalTimer.LoseTime(loseTimeAmount);
                ball.transform.position = respawnPoint.position;
                SoundManager.PlaySound(teleportSound, transform.position, new Vector2(2, 2), false);
            }
        }

    }
}
