using UnityEngine;

public class Enemy : MonoBehaviour{
    [Tooltip("Movement speed of enemy. 2 is a pretty good speed to test sprite sorter")]
    [SerializeField] float movementSpeed = 2;

    [Tooltip("GameObject to be chased (Player)")]
    [SerializeField] GameObject player;
    
    /// <summary>
    /// Get players GameObject by its Player-Tag
    /// </summary>
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Move Enemy towards the targeted GameObject (Player)
    void Update() {
        Vector2 pos = transform.position;
        gameObject.transform.position = Vector2.MoveTowards(pos, player.transform.position, Time.deltaTime  * movementSpeed);
    }
}
