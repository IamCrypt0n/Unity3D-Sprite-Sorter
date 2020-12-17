## Unity3D Sprite Sorter



Unity3D Sprite Sorter is a small script that sorts active SpriteRenderers in a scene. It distinguishes between dynamic (moving) and static objects, which only allows sorting of the dynamic objects. This saves system resources that can be used for other great features of your game :)


## Usage (Proper Description coming soon)

  - Add a GameObject with the sortPointTag (can be customized) as a child of the object to be sorted
  - Add SpriteRenderer of all pre added SceneObjects to the "InitialRenderers" list using the Unity3D Editor
  - Add dynamic/moving sceneObjects to Sorter by calling registerRenderer() at runtime
  - Sorting a static object which has been spawned at runtime is done by calling sortOnce()
 
**DemoScene is included in the current release which can be downloaded @ Releases:** [DemoScene @ Release 0.9.0](https://github.com/IamCrypt0n/Unity3D-Sprite-sorter/releases/tag/0.9.0)

## Still to be done
  - Sort object only when it has moved 
  - Proper sourcecode documentation & comments
  - Youtube Demo
