
using UnityEngine;
using System.Collections;

public class ExplosionSpawner : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Transform player;

    public float spawnInterval = 3f;
    public float minDistance = 1f;
    public float maxDistance = 3f;

    private IEnumerator Start()
    {
        if (explosionPrefab == null || player == null)
        {
            Debug.LogError("Explosion Prefab or Player is missing!");
            yield break;
        }

        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnExplosion();
        }
    }

    void SpawnExplosion()
    {
        // Random direction around player
        float angle = Random.Range(0f, 360f);
        float distance = Random.Range(minDistance, maxDistance);

        // Calculate explosion position
        Vector3 direction = new Vector3(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            0f,
            Mathf.Sin(angle * Mathf.Deg2Rad)
        );

       float height = Random.Range(0f, 2f);

Vector3 spawnPosition = new Vector3(
    player.position.x + direction.x * distance,
    height,
    player.position.z + direction.z * distance
); //spawn the explosion at a random height above the player

        // Create explosion
        GameObject explosion = Instantiate(
            explosionPrefab,
            spawnPosition,
            Quaternion.identity
        );

        // Assign player to haptic script
        HapticExplosion haptic =
            explosion.GetComponent<HapticExplosion>();

        if (haptic != null)
        {
            haptic.player = player;
        }

        Debug.Log("Explosion spawned!");
    }
}
