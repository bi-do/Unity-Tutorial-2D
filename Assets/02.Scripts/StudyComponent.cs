using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    private GameObject temp_cube;

    [SerializeField]
    private string change_name;

    void Start()
    {
        this.temp_cube = GameObject.Find("Cube");
        this.temp_cube.name = this.change_name;
        this.temp_cube.transform.position = new Vector3(3, 3, 3);
    }
}
