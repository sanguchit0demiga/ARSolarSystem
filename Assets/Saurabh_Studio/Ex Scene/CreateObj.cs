using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CreateObj : MonoBehaviour
{

    public Image PP;
    public Sprite[] temp;
    public GameObject parent;
    public Color[] colorList;

    void Start()
    {
        for (int i = 0; i < temp.Length; i++)
        {
            var createImage = Instantiate(PP, parent.transform, false);
            createImage.color = colorList[i % colorList.Length];
            createImage.gameObject.name = temp[i].name;

            Image tempNew = createImage;
            tempNew.sprite = temp[i];

            // Crear prefab (solo en editor)
#if UNITY_EDITOR
            string localPath = "Assets/UI button pack 3/Button round color " + (i % colorList.Length + 1) + "/" + createImage.name + ".prefab";
            CreateNew(createImage.gameObject, localPath);
#endif
        }
    }

#if UNITY_EDITOR
    static void CreateNew(GameObject obj, string localPath)
    {
        PrefabUtility.SaveAsPrefabAsset(obj, localPath);
    }
#endif
}
