
using UnityEngine;
using Bhaptics.SDK2;

public class HapticExplosion : MonoBehaviour
{
    public Transform player;
    public float maxDistance = 10f;

    void Start()
    {
        if (player == null)
        {
            Debug.LogWarning("Player is not assigned!");
            return;
        }

        // Calculate distance to player
        float distance = Vector3.Distance(
            transform.position, player.position
        );

        // Only play haptics within range
        if (distance <= maxDistance)
        {
            // Direction relative to player
            Vector3 direction = transform.position - player.position;

            float angle = Vector3.SignedAngle(
                player.forward,
                direction,
                Vector3.up
            );

            // Convert angle to 0-360 degrees
            angle = (angle + 360f) % 360f;

            // Calculate vertical offset
            float height = direction.y;
            float offsetY = Mathf.Clamp(height / 2f, -0.5f, 0.5f);

            // Calculate intensity based on distance
            float intensity = Mathf.Clamp01(
                1f - distance / maxDistance
            );

            // Play vest haptic feedback
            BhapticsLibrary.PlayParam(
                "impact_vest",
                intensity,
                1f,
                angle,
                offsetY
            );

            Debug.Log("Explosion haptic played! Distance: " + distance);
        }

        // Remove explosion after 1 second
        Destroy(gameObject, 1f);
    }
}
