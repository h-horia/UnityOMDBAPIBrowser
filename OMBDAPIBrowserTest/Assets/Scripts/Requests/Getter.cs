using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Getter : MonoBehaviour
{
    public GridManager gridManager;
    public void GetResponse (string url)
    {
        StartCoroutine(GetResponseCo(url));
    }

    private IEnumerator GetResponseCo(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        while(!www.isDone)
        {
            Debug.Log("Progress:" + www.downloadProgress);
            yield return null;
        }

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Network error:" + www.error);
        }
        else
        {
            Statics.response = www.downloadHandler.text;
            Debug.Log("Response:" + www.downloadHandler.text);
            ResponseJSON json= JsonUtility.FromJson<ResponseJSON>(Statics.response);
            Statics.responseJSON = json;
            gridManager.ClearList();
            gridManager.PopulateGrid(Statics.responseJSON.Search);

        }

    }
}
