using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Item : MonoBehaviour
{
    public Image image;
    public Text title;
    private Texture2D tex;
    public void PopulateItem(SearchJSON itemData)
    {
        title.text = itemData.Title;
        StartCoroutine(GetImage(itemData.Poster));
    }

    private IEnumerator GetImage(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        while (!www.isDone)
        {
            Debug.Log("Progress:" + www.downloadProgress);
            yield return null;
        }

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Network error:" + www.error);
        }
        else
        {
            byte[] data = www.downloadHandler.data;

            tex = new Texture2D(2, 2);
            tex.LoadImage(data);
            tex.Apply();

            Sprite spr = Sprite.Create(tex, new Rect(new Vector2(0, 0), new Vector2(tex.width, tex.height)),new Vector2(0.5f,0.5f));
            image.sprite = spr;
        }
    }
}
