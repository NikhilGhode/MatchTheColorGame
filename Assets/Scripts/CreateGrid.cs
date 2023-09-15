using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class CreateGrid : MonoBehaviour
{
    // Start is called before the first frame update
    private int rowsize = 0;
    private int columnsize = 0;
    private Vector2 pos = Vector2.zero;
    [SerializeField]
    private GameObject panelobject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
    {
        rowsize = int.Parse(GameManager.instance.row.text);
        columnsize = int.Parse(GameManager.instance.column.text);

        for (int i = 0; i < rowsize; i++)
        {
            for (int j = 0; j < columnsize; j++)
            {
                float x = (j - (columnsize - 1) / 2.0f) * 0.5f;
                float y = ((rowsize - 1) / 2.0f - i) * 0.5f;

                GameObject tile = Instantiate(GameManager.instance.gridplate, new Vector2(x, y), Quaternion.identity);
                GameObject bg = Instantiate(GameManager.instance.background, new Vector2(x, y), Quaternion.identity);
                int range = Random.Range(0, 2);
                GameObject colorobj = GameManager.instance.colors[range];                
                GameObject colorprefab = Instantiate(colorobj, new Vector2(x, y), Quaternion.identity);
                GameManager.instance.totalObjects++;
                //GameManager.instance.totalobjectsprefabs.Add(colorprefab);
                GameManager.instance.totalobjectnum.Add(range);
                tile.GetComponent<ClickSprite>().colorcode = range;
                tile.GetComponent<ClickSprite>().colorobject = colorprefab;
                tile.transform.SetParent(GameManager.instance.parentobject);
                colorprefab.transform.SetParent(GameManager.instance.parentobject);
                bg.transform.SetParent(GameManager.instance.parentobject);
            }
        }
        panelobject.SetActive(false);
    }
}
