## Unity3D Sprite Sorter



Unity3D Sprite Sorter is a small script that sorts active SpriteRenderers in a scene. It distinguishes between dynamic (moving) and static objects, which only allows sorting of the dynamic objects. This saves system resources that can be used for other great features of your game :)


## Usage

  - Add a GameObject with the sortPointTag (can be customized) as a child of the GameObject to be sorted
  - Add a sprite and a fixed y-Offset to the "OrderListBySprite" list. Props and dynamic/moving GameObjects whichs sprite is added to this list will be sorted according     to the associated y-Offset in the list.
  - Add dynamic/moving sceneObjects to sorter by calling registerRenderer() at runtime
  - Sorting SpriteRenderer of static GameObject which has been spawned at runtime is done by calling sortOnce()
 
**DemoScene is included in the current release which can be downloaded @ Releases:** [DemoScene @ Release 0.9.1](https://github.com/IamCrypt0n/Unity3D-Sprite-sorter/releases/tag/0.9.2)

## Still to be done
  - Youtube Demo
