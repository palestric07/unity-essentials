
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyprefab;
    [SerializeField]
    private int _enemyCount = 5;
    [SerializeField]
    private Transform _spawntopleft, _spawntopright, _spawnbottomleft, _spawnbottomright;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i=0; i<_enemyCount; i++)
        {
             SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnposition = SelectRandomPosition();
      GameObject enemyObject = Instantiate(_enemyprefab, spawnposition, Quaternion.identity);
      enemy Enemy = enemyObject.GetComponent<enemy>();
      if (Enemy != null)
      {
          Enemy.onEnemyDeath += SpawnEnemy;
      }
    }

    private Vector3 SelectRandomPosition()
    {
        Transform selectedTransform = null;
        int random = Random.Range(0, 4); 
        
        // FIX 1: 'spawnpointtype' ka naam exact waisa hi rakha jaisa niche enum ka hai
        spawnpointtype randomValue = (spawnpointtype)random; 
       
        // FIX 2: switch ke andar 'SpawnType' ki jagah upar banaya hua variable 'randomValue' aayega
        switch(randomValue) 
        {
            case spawnpointtype.Topleft:
                selectedTransform = _spawntopleft;
                break;
            // FIX 3: Pehle yahan 'Topleft' dobara likha tha, use badal kar 'Topright' kiya
            case spawnpointtype.Topright: 
                selectedTransform = _spawntopright;
                break;
            case spawnpointtype.Bottomleft:
                selectedTransform = _spawnbottomleft;
                break;
            case spawnpointtype.Bottomright:
                selectedTransform = _spawnbottomright;
                break;
            default: 
                selectedTransform = _spawntopleft;
                break;
        }
        
        if (selectedTransform != null)
        {
            return selectedTransform.position + (Vector3)Random.insideUnitCircle;
        }
        
        return Vector3.zero; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum spawnpointtype
    {
        Topleft=0,
        Topright=1,
        Bottomleft=2,
        Bottomright=3
    }
}