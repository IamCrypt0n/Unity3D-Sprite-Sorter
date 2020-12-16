using UnityEngine;

public class Player : MonoBehaviour{

    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject tree;
    [SerializeField] GameObject enemy;
    [SerializeField] float movementSpeed = 1.0f;
    SpriteSorter sorter;

    void Start(){
        //Add Player to sorter
        sorter = FindObjectOfType<SpriteSorter>();
        sorter.registerRenderer(GetComponent<SpriteRenderer>());
    }

    void Update(){

        //Spawn static tree
        if (Input.GetKeyDown(KeyCode.T)){
            Vector3 spawnPos = spawnPoint.transform.position;
            GameObject newObject = Instantiate(tree, spawnPos, Quaternion.identity);
            sorter.sortOnce(newObject.GetComponent<SpriteRenderer>());
        }

        //Spawn chasing scarecrow
        if (Input.GetKeyDown(KeyCode.G))
        {
            Vector3 spawnPos = spawnPoint.transform.position;
            GameObject newObject = Instantiate(enemy, spawnPos, Quaternion.identity);
            sorter.registerRenderer(newObject.GetComponent<SpriteRenderer>());
        }

        //Basic shitty movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(h, v, 0);
        movementVector = movementVector.normalized * movementSpeed * Time.deltaTime;

        gameObject.transform.position += movementVector;
    }
}
