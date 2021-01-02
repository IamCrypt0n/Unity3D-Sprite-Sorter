using UnityEngine;

public class GameManager : MonoBehaviour{

    [Tooltip("Sprite sorter. This is necessary to register the enemy (scarecrow) and sorting the tree once.")]
    SpriteSorter sorter;

    [Tooltip("GameObject that represents the Spawn Point. Its tranforms position is the spawn position of they enemy and tree")]
    [SerializeField] GameObject spawnPoint;

    [Tooltip("Prefab of a static GameObject to be spawned at runtime. In this demo its a tree")]
    [SerializeField] GameObject treePrefab;

    [Tooltip("Prefab of dynamic/moving GameObject to be spawned at runtime. In this demo its a scarecrow chasing the player")]
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] GameObject startPos;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start(){

        sorter = FindObjectOfType<SpriteSorter>();
        player = Instantiate(player, startPos.transform.position, Quaternion.identity);
        sorter.registerRenderer(player.GetComponent<SpriteRenderer>());

        
    }

    // Update is called once per frame
    void Update(){
        //Spawn static tree if T-Key has been pressed 
        if (Input.GetKeyDown(KeyCode.T)) {
            Vector3 spawnPos = spawnPoint.transform.position;
            GameObject tree = Instantiate(treePrefab, spawnPos, Quaternion.identity);
            sorter.sortOnce(tree.GetComponent<SpriteRenderer>());   //Sort this new static GameObject (tree) once
        }

        //Spawn chasing scarecrow if G-Key has been pressed
        if (Input.GetKeyDown(KeyCode.G)) {
            Vector3 spawnPos = spawnPoint.transform.position;
            GameObject scarecrow = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            sorter.registerRenderer(scarecrow.GetComponent<SpriteRenderer>());  //Registering dynamic/moving GameObject (Scarecrow)
        }
    }
}
