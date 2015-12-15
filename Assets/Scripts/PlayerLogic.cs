using UnityEngine;

/* Poorly named class, was planning on putting some multiplayer logic in here when planning it out
   Now it just holds the players data */
public class PlayerLogic : MonoBehaviour
{
    public float size = 1f;
    public float pickupRatio = .25f;
    public const float COOL_DOWN_LIMIT = 5f;
    public static float damageCoolDownTimer = COOL_DOWN_LIMIT;
}
