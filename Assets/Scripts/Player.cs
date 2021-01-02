using UnityEngine;

public class Player : MonoBehaviour{

    

    [Tooltip("Players movement speed")]
    [SerializeField] float movementSpeed = 1.0f;

   

    /// <summary>
    /// Add the player (its a moving GameObject) to the sprite sorter
    /// </summary>
    void Start(){
    }

    void Update(){

        

        //Basic clunky movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(h, v, 0);
        movementVector = movementVector.normalized * movementSpeed * Time.deltaTime;

        gameObject.transform.position += movementVector;
    }
}
