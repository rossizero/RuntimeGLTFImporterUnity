using UnityEngine;
using GLTFast;
using System.IO;
using System;
using SFB;


public class main : MonoBehaviour
{
    /* SOURCES
     * Filebrowser https://github.com/gkngkc/UnityStandaloneFileBrowser (MIT)
     * GLTFast https://docs.unity3d.com/Packages/com.unity.cloud.gltfast@6.0/manual/index.html (Apache 2.0)
     */
    void Start()
    {
        Invoke("do_stuff", 1.313f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void do_stuff()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false);
        load_gltf(paths[0]);
    }

    async void load_gltf(string path) {
        var logger = new GLTFast.Logging.ConsoleLogger();

        // if you need some special settings
        var settings = new ImportSettings {
            GenerateMipMaps = true,
            AnisotropicFilterLevel = 3,
            NodeNameMethod = NameImportMethod.OriginalUnique
        };
        path = @"C:/Users/develop/Downloads/Sample.gltf";
        byte[] data = File.ReadAllBytes(path);
        var gltf = new GltfImport(null, null, null, logger);

        // The URI of the original data is important for resolving relative URIs within the glTF
        // Note: Make sure to provide all files that the gltf references to in path
        bool success = await gltf.Load(data, new Uri(path), settings);
        if (success) {
            try {
                // create a new Gameobject and initialize it with gltfast
                GameObject root = new GameObject("GLTF Model");
                await gltf.InstantiateMainSceneAsync(root.transform);
            } catch (Exception e) {
                Debug.LogError(e.ToString());
            }
        } else {
            Debug.LogError("Nope.");
        }
    }
}
