using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetTile : MonoBehaviour
{
    public GameObject tile_prefab;
    private int col = 10, row = 10;

    public Button[] buttons;

    GameObject[,] tiles;

    public static int turret_index;

    void Awake()
    {
        int count = 0;
        foreach (Button element in buttons)
        {
            int count_temp = count;
            element.onClick.AddListener(() => ChangeIndex(count_temp));
            count++;
        }
    }

    void Start()
    {
        StartCoroutine(this.GenerateRoutine());
    }

    IEnumerator GenerateRoutine()
    {
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                Vector3 pos_temp = new Vector3(j, 0, i);

                GameObject tile_temp = Instantiate(this.tile_prefab, pos_temp, Quaternion.identity);

                tiles[i, j] = tile_temp;

                MeshRenderer mesh_renderer = tile_temp.GetComponent<MeshRenderer>();

                if ((i + j) % 2 == 0)
                {
                    mesh_renderer.material.color = Color.white;
                }
                else
                {
                    mesh_renderer.material.color = Color.black;
                }


                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    void ChangeIndex(int param_index) {
        turret_index = param_index;
    }
}
