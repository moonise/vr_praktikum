using UnityEngine;

public class RandomTargetSpawn : MonoBehaviour
{
    public GameObject targetPrefab; //Hangi Prefab'ın oluşturulacağını belirler

    public void spawnTarget() //Target'ın oluşturulacağı yerin koordinatlarını belirler
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-2.5f, 2.5f), //random sayi üretir 
            0f,
            Random.Range(-2.5f, 2.5f)
        );

        Instantiate(targetPrefab, randomPosition, Quaternion.identity, transform); //instantiate erstellt das Objekt an der Stelle randomPosition
    }

    void Start()
    {
        spawnTarget();
    }
}
