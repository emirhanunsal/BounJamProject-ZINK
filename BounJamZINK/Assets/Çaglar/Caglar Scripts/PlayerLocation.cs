using UnityEngine;

public class PlayerLocation : MonoBehaviour
{
    public static Vector3 location;

    void Start()
    {

    }

    void Update()
    {
        location = transform.position; // Oyuncunun konumunu s�rekli g�ncelle
    }
}
