using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Life : MonoBehaviour
{
    public Enemy enemy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.health == 1)
        {
            RemoveBar(2);
        }
        else if(enemy.health < 1)
        {
            Destroy(this.gameObject);
        }
    }

    void RemoveBar(int barNumber)
    {
        if (this.tag == $"{barNumber}")
        {
            Destroy(this.gameObject);
        }
    }
}
