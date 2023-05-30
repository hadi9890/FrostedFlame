using System.Collections;
using System.Collections.Generic;
using Batteries;
using UnityEngine;

//script attached to the collectible generator
public class GenerateCollectibleWithPooling : MonoBehaviour
{
    [Tooltip("Object in hierarchy which parents the collectibles")][SerializeField] Transform container;
    [Tooltip("prefab of the collectible object to be generated")][SerializeField] GameObject[] collectibleToInstantiate;
    [Tooltip("list of collectibles available to generate from")][SerializeField] List<GameObject> collectiblePool = new List<GameObject>();

    void Start()
    {
        foreach (Transform child in container)
        {
            child.gameObject.SetActive(false);//initially all collectibles in container are inactive
            collectiblePool.Add(child.gameObject);//add the collectibles to the pool
        }
    }

    //used every time the player enters a certain trigger for the collectibles, a collectible is generated if none are in
    // the pool or pick one from the pool
    public void createCollectible(Vector3 position)
    {
        if (collectiblePool.Count == 0)
        {
            // Debug.Log("empty pool");
            //if the pool is empty, instantiate a new collectible in front of the player
            GameObject newCollectible = Instantiate(collectibleToInstantiate[BatteryUIControl.numberOfBatteries], position, (Quaternion.Euler(-3.441f, -84.04f, 2.047f))) as GameObject;
            //set the parent of this new object to the generator (this)
            newCollectible.transform.SetParent(transform);
            newCollectible.SetActive(true);
            newCollectible.transform.position = position;
        }
        else
        {
            pickCollectible(position);
        }
    }
    //picks a collectible from the pool and activate it
    void pickCollectible(Vector3 position)
    {
        // Debug.Log("activate collectible from pool");
        int index = Random.Range(0, collectiblePool.Count - 1);//pick a random collectible from the pool
        GameObject picked = collectiblePool[index];
        //remove the picked collectible from the pool list
        collectiblePool.Remove(picked);
        // this object, which is the collectible generator becomes the parent of the picked object
        picked.transform.SetParent(transform);
        // picked.transform.position = triggerPosition.position;
        picked.gameObject.SetActive(true);//collectible is "created", it appears and is activated
        picked.transform.position = position;
    }

    //deactivate the collectible
    public IEnumerator hideCollectible(GameObject collectibleToDeactivate)
    {
        //add the game object to the pool list
        // collectiblePool.Add(collectibleToDeactivate);
        //set the parent of this collectible to the container
        collectibleToDeactivate.transform.SetParent(container);
        collectibleToDeactivate.SetActive(false);//deactivate
        yield return new WaitForSeconds(1.0f);
    }
}