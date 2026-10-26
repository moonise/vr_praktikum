using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public RandomTargetSpawn randomTargetSpawn;

    private Renderer objectRenderer;

    void Start() //das macht das Objekt blau
    {
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material.color = Color.blue;
    }

    void OnTriggerEnter(Collider other) //ontriggerenter ist ein event der aufgerufen wird wenn ein collider mit einem anderen collider kollidiert
    {
        objectRenderer.material.color = Color.green; //das macht das Objekt grün
        randomTargetSpawn.spawnTarget(); //spawnTarget erstellt ein neues target
    }

    void OnTriggerExit(Collider other) 
    {
        objectRenderer.material.color = Color.blue;
        Destroy(other.gameObject); //destroy zerstört das Objekt
    }
}
