using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridManager : MonoBehaviour
{
    public GameObject template;
    public Transform templateParent;
    private List<GameObject> objects;


    private void Awake()
    {
        objects = new List<GameObject>();
    }
    public void PopulateGrid(SearchJSON[] results)
    {
        foreach (SearchJSON sj in results)
        {
            GameObject go = GameObject.Instantiate(template, templateParent);
            go.name = sj.Title;
            go.SetActive(true);
            objects.Add(go);

            Item item = go.GetComponent<Item>();
            item.PopulateItem(sj);

        }
    }

    public void ClearList()
    {
        foreach (GameObject go in objects)
        {
            Destroy(go);

        }
        objects.Clear();
    }
}
