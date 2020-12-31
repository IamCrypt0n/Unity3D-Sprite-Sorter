using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    [SerializeField] GameObject startPos;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start(){
        Instantiate(player, startPos.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
