using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadFromAssetBundle : MonoBehaviour
{
    public String prefabName = "CubeRed";
    public String uri = "https://chess.frb.io/AssetBundles/cubered";
//    public String uri2 = "https://github.com/dr-matt-smith/unity-cookbook-2020-ch08-07-load-from-streaming-assets/blob/master/Assets/StreamingAssets/cubered?raw=true";

    void Start()
    {
        StartCoroutine(nameof(DownloadAndCreatePrefab));
    }
    
    IEnumerator DownloadAndCreatePrefab()
    {
        UnityEngine.Networking.UnityWebRequest request 
            = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle(uri, 0);
 
        // cope with security issue for local host
//        request.certificateHandler = new CertHandler();

        yield return request.SendWebRequest();
        
        AssetBundle myLoadedAssetBundle = DownloadHandlerAssetBundle.GetContent(request);

        // create and instantiate prefab - red Cube
        GameObject cubePrefab = myLoadedAssetBundle.LoadAsset<GameObject>(prefabName);
        Instantiate(cubePrefab);
    }
}