using UnityEngine;

public class RectangleSpawner2D : MonoBehaviour
{
    public Transform objectA; // Birinci objenin transformu
    public Transform objectB; // İkinci objenin transformu
    public GameObject rectanglePrefab; // Dikdörtgen prefab'ı

    void Start()
    {
        SpawnRectangleBetweenObjects();
    }

    void SpawnRectangleBetweenObjects()
    {
        Vector3 midpoint = (objectA.position + objectB.position) / 2;
        float distance = Vector3.Distance(objectA.position, objectB.position);

        GameObject rectangle = Instantiate(rectanglePrefab, midpoint, Quaternion.identity);

        // İki nokta arasındaki açıyı bulma
        Vector3 direction = (objectB.position - objectA.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rectangle.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Dikdörtgenin boyutunu ayarlama
        if (rectangle.GetComponent<SpriteRenderer>() != null)
        {
            SpriteRenderer sr = rectangle.GetComponent<SpriteRenderer>();
            sr.size = new Vector2(distance, sr.size.y);
        }
        else if (rectangle.GetComponent<BoxCollider2D>() != null)
        {
            BoxCollider2D bc = rectangle.GetComponent<BoxCollider2D>();
            bc.size = new Vector2(distance, bc.size.y);
        }
    }

}


