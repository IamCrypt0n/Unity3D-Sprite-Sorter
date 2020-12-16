using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour{
    /// <summary>
    /// List of sprites to be sorted each frame (most commonly moving objects)
    /// </summary>
    [SerializeField] List<Tuple<SpriteRenderer, float>> dynamicRenderers = new List<Tuple<SpriteRenderer, float>>();
    /// <summary>
    /// List of sprites to be sorted at initialisation (most commonly static objects)
    /// </summary>
    [SerializeField] List<SpriteRenderer> initialRenderers = new List<SpriteRenderer>();
    /// <summary>
    /// Accuracy of sorting
    /// </summary>
    [SerializeField] int accuracy = 100;
    /// <summary>
    /// Destroy SortPoint after its offset to parent was calculated?
    /// </summary>
    [SerializeField] bool destroySortPoint = false;
    [SerializeField] String sortPointTag = "SortPoint";
    

    void Start(){
        sortInitialSprites();
    }

    /// <summary>
    /// Register new renderer. This results in sorting this renderer every frame
    /// </summary>
    /// <param name="renderer"></param>
    public void registerRenderer(SpriteRenderer renderer){
        if (renderer){
            GameObject rendererParent = renderer.gameObject;
            float yOffset = getSortYOffset(rendererParent);
            
            dynamicRenderers.Add(new Tuple<SpriteRenderer, float>(renderer, yOffset));
        }
    }

    private float getSortYOffset(GameObject parent){
        foreach (Transform t  in parent.transform){
            if(t.tag.Equals(sortPointTag)){
                float offset = t.localPosition.y * parent.transform.localScale.y;
                if (destroySortPoint) {
                    Destroy(t.gameObject);
                }
                return offset;
            }
        }
        return float.NaN;
    }

    /// <summary>
    /// Set sorting order for given spriteRenderer. Meant to be called by newly instantiated GameObject
    /// </summary>
    /// <param name="renderer">SpriteRenderer to be sorted</param>
    public void sortOnce(SpriteRenderer renderer){
        Transform objectTransform = renderer.gameObject.transform;
        Vector3 sortPosition = Vector3.one;
        foreach (Transform t in objectTransform){
            if (t.tag == "SortPoint") {
                sortPosition = t.position;
                //Set sort oder derived from sorting point position
                renderer.sortingOrder = (int)(sortPosition.y * -accuracy);
                break;
            }
        }
    }

    /// <summary>
    /// Set sorting orders of initial sprites. 
    /// </summary>
    private void sortInitialSprites(){
        foreach (SpriteRenderer renderer in initialRenderers){
            if (renderer){
                //Get position of sortingPoint
                GameObject rendererParent = renderer.gameObject;
                float sortOffset = getSortYOffset(rendererParent);
                renderer.sortingOrder = (int)((rendererParent.transform.position.y + sortOffset) * -accuracy);
            }
        }
    }


    
    /// <summary>
    /// Sorts all dynamic/moving renderers/objects
    /// </summary>
    void sortDynamicSprites(){
        for (int index = 0; index < dynamicRenderers.Count; index++){
            if (dynamicRenderers[index].Item1){ //Item 1 = SpriteRenderer, Item2 = sortPoint offset
                GameObject rendererParent = dynamicRenderers[index].Item1.gameObject;   //Get sortPoint offset from list tuple
                dynamicRenderers[index].Item1.sortingOrder = (int)((rendererParent.transform.position.y + dynamicRenderers[index].Item2) * -accuracy); //Calculate new sortOrder
            }
            else {
                Debug.Log("NULL");
                dynamicRenderers.RemoveAt(index);  //Remove renderer from sorting list
            }
        }
    }
    
    void Update(){
        sortDynamicSprites();
    }
}
