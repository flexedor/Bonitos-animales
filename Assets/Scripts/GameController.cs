using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
   
    [SerializeField]
    private List<GameObject> stages;

    [SerializeField]
    private int _currentStage;

    public int CurrentStage
    {
        get => _currentStage;
        set  {
            if (value>=0&&value<stages.Count)
            {
                _currentStage = value;
            }
            
        }
    }
    private GameObject _currentStageObstical;
    
    
    private void Awake()
    {
        Instance = this;
        CurrentStage = 0;
        LoadLevel(CurrentStage);
    }
    public void PrevLevel()
    {
        Debug.Log("Prev Level");
        LoadLevel(--CurrentStage);    
    } 
    public void NextLevel()
    {
        Debug.Log("Next Level");
        LoadLevel(++CurrentStage);    
    }
    
    private void RestartLevel()
    {
        Debug.Log("Restart Level");
        LoadLevel(CurrentStage);
    }

    private void LoadLevel(int numToLoad)
    {
        Destroy(_currentStageObstical);
        _currentStageObstical = Instantiate(stages[CurrentStage],transform.position, 
            Quaternion.identity, transform);
        
        
    }
    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }else if(Input.GetKeyDown(KeyCode.Z)){
            PrevLevel();
        }else if (Input.GetKeyDown(KeyCode.X))
        {
            NextLevel();
        }

#endif
    }
}
