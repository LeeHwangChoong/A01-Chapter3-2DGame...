﻿using System.Collections;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    //아이템이 특정 시간대에 세가지중에 랜덤으로 하나 생성되게 하기    

    public GameObject[] itemPrefabs;
    public GameObject player;    

    private void Start()
    {           
        StartCoroutine(SpawnRandomItem());
    }

    private IEnumerator SpawnRandomItem()
    {
        while (true)
        {
            // 15초에서 40초사이의 랜덤한시간에 아이템 생성
            float spawnInterval = Random.Range(10f, 20f); 
            yield return new WaitForSeconds(spawnInterval);

            // 랜덤한 위치에 랜덤한 아이템을 생성
            float randomX = Random.Range(-2.5f, 2.5f);
            Vector2 spawnPosition = new Vector3(randomX, 4.7f);
            int randomIndex = Random.Range(0, itemPrefabs.Length);
            GameObject newItem = Instantiate(itemPrefabs[randomIndex], spawnPosition, Quaternion.identity, transform);

            ItemManager.Instance.RandomItem(newItem); //아이템 컨트롤러에 저장                        

            ShieldItem shieldItem = newItem.GetComponent<ShieldItem>();
            if (shieldItem != null && player != null)
            {
                shieldItem.shieldObject = player.transform.Find("MainSprite/ShieldImage").gameObject;
            }            
        }
    }
}
