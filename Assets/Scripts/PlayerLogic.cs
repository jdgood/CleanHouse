using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {
    public float size = 1f;
    public float pickupRatio = .25f;
    public const float COOL_DOWN_LIMIT = 5f;
    public static float damageCoolDownTimer = COOL_DOWN_LIMIT;
}
