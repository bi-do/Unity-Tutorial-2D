using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] turrePrefab;

    void OnMouseDown()
    {
        Instantiate(turrePrefab[SetTile.turret_index], this.transform.position, Quaternion.identity);
    }
}
