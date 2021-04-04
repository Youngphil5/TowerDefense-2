using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Defender;
    public Purse purse;
    private GameObject tempPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawLine(ray.origin, ray.direction, Color.red)
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    Debug.Log(hit.transform.gameObject.tag);
                    
                    if (hit.transform.gameObject.tag == "Enemy")
                    {
                        hit.transform.GetComponent<Enemy>().Damage();
                    }

                    if (hit.transform.gameObject.tag == "DropPoint")
                    {
                        if (purse.coinCount > 0)
                        {
                            purse.removeCoin(2);
                            tempPrefab = Instantiate(Defender, hit.transform.position, hit.transform.rotation );
                            Destroy(tempPrefab, 5);
                        }
                    }
                }
            }
        }
        
    }
}
