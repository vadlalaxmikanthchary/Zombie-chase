using System.Collections;
using UnityEngine;

public class Monsterspawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;
    [SerializeField]
    private Transform leftPos , RightPos;
    private int randomIndex;
    private int randomSide;
    private GameObject spawnedmonster;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      StartCoroutine(spawnMonsters());   
    }

    IEnumerator spawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0,2);

            spawnedmonster = Instantiate(monsterReference[randomIndex]);

            if(randomSide == 0)
            {
                //leftside 
                spawnedmonster.transform.position = leftPos.position;
                spawnedmonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
            //right side
                spawnedmonster.transform.position = RightPos.position;
                spawnedmonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedmonster.transform.localScale = new Vector3(-1f,1f,1f);
            }
       

    }

    }






}
