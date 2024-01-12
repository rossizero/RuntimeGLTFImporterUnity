# RuntimeGLTFImporterUnity
First goal was to load .catproduct files into unity at runtime, but this seems to be quite hard.
Closest one could get are .stp files by using the assimp library: https://github.com/assimp/assimp.
This library can be installed to unity like so: https://intelligide.github.io/assimp-unity/.
But currently they only support IFC2x3 files, which are based on the same ISO Standard as step files but use File_SCHEMAS Catia doesn't know.

That's why we decided to go for the gltf format.

This repo contains a simple project setup that loads a GLTF File into a Unity Scene at runtime using a filebrowser.
Luckily there are libraries that can do those things ^^
 * GLTFast https://docs.unity3d.com/Packages/com.unity.cloud.gltfast@6.0/manual/index.html (Apache 2.0)
 * Filebrowser https://github.com/gkngkc/UnityStandaloneFileBrowser (MIT)
