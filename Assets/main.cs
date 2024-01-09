using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLTFast;
using System.IO;
using System;


public class main : MonoBehaviour
{
    // TODO SharpGLTF
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadGltfBinaryFromMemory", 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    async void LoadGltfBinaryFromMemory()
    {
        var filePath = "/home/rosrunner/Downloads/Duck.gltf";
        byte[] data = File.ReadAllBytes(filePath);
        var gltf = new GltfImport();
        bool success = await gltf.LoadGltfBinary(
            data,
            // The URI of the original data is important for resolving relative URIs within the glTF
            new Uri(filePath)
            );
        if (success)
        {
            success = await gltf.InstantiateMainSceneAsync(transform);
            if (success) 
            {
                var init = new GameObjectInstantiator(gltf, gameObject.transform);
            }
        }
    }
}
