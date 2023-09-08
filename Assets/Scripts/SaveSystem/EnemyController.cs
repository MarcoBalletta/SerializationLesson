using UnityEngine;

public class EnemyController : MonoBehaviour, ISaveableComponent
{

    public int ID;

    public void Load(GameData data)
    {
        if (data is EnemyData) 
        {
            EnemyData enemyData = (data as EnemyData);
            if(ID != 0) ID = enemyData.ID;
            transform.position = enemyData.position;
            transform.rotation = enemyData.rotation;
            if(enemyData.name != "") transform.name = enemyData.name;
        }
    }

    public void Save(GameData data)
    {
        if (data is EnemyData) 
        { 
            EnemyData enemyData = (data as EnemyData);
            if(ID != 0) enemyData.ID = ID;
            enemyData.position = transform.position;
            enemyData.rotation = transform.rotation;
            enemyData.name = "Enemy - " + ID.ToString();
        }

    }
}
