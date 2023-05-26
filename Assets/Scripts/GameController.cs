using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public enum StageState
    {
        Zoo,
        Resquing 
    }
    public StageState _curretStageState;
    
    [FormerlySerializedAs("Zoo Stages")] [SerializeField]
    private List<GameObject> zooStages;
    [FormerlySerializedAs("Rescuing Stages")] [SerializeField]
    public List<GameObject> resquingStages;
    private int _currentZooStage;
    private int _currentResqungStage;
    
    public int CurrentZooStage
    {
        get => _currentZooStage;
        set  {
            if (value>=0&&value<zooStages.Count)
            {
                _currentZooStage = value;
            }
            
        }
    }
    public int CurrentResquingStage
    {
        get => _currentResqungStage;
        set  {
            if (value>=0&&value<resquingStages.Count)
            {
                _currentResqungStage = value;
            }
            
        }
    }
    private GameObject _currentStageObstical;

    private void Start()
    {
        Instance = this;
    }

    private void Awake()
    {
        UIMenuController.onZooBtn += SwitchToZoo;
        UIMenuController.onResquingBtn += SwitchToResquing;
        LevelButtonScript.onClickLevel += OnChoosingResquingLevel;
        BulletScript.NextResqueLevel += NextLevel;
        BulletScript.AnimalToAdd += addAnimalToproperBiom;
        _curretStageState = StageState.Zoo;
        Instance = this;
        CurrentZooStage = 0;
        CurrentResquingStage = 0;
        LoadLevel(CurrentZooStage,zooStages);
    }

    private void OnDestroy()
    {
        UIMenuController.onZooBtn -= SwitchToZoo;
        UIMenuController.onResquingBtn -= SwitchToResquing;
        LevelButtonScript.onClickLevel -= OnChoosingResquingLevel;
        BulletScript.AnimalToAdd -= addAnimalToproperBiom;
        BulletScript.NextResqueLevel -= NextLevel;
    }

    public void PrevLevel()
    {
        Debug.Log("Prev Level");
        if (_curretStageState==StageState.Zoo)
        {
            --CurrentZooStage;
            LoadLevel(CurrentZooStage,zooStages);    
        }
        else
        {
            --CurrentResquingStage;
            LoadLevel(CurrentResquingStage,resquingStages);    
        }
       
    } 
    // ReSharper disable Unity.PerformanceAnalysis
    public void NextLevel()
    {
        Debug.Log("Next Level");
        if (_curretStageState==StageState.Zoo)
        {
            ++CurrentZooStage;
            LoadLevel(CurrentZooStage,zooStages);    
        }
        else
        {
            ++CurrentResquingStage;
            LoadLevel(CurrentResquingStage,resquingStages);    
        }
    }
    
    private void RestartLevel()
    {
        Debug.Log("Restart Level");
        if (_curretStageState==StageState.Zoo)
        {
            LoadLevel(CurrentZooStage,zooStages);    
        }
        else
        {
            LoadLevel(CurrentResquingStage,resquingStages);    
        }
    }

    private void LoadLevel(int numToLoad,List<GameObject> sceensToLoad)
    {
        Destroy(_currentStageObstical);
        _currentStageObstical = Instantiate(sceensToLoad[numToLoad],transform.position, 
            Quaternion.identity, transform);
        
        
    }
    
    void SwitchToZoo()
    {
        setPlatform(StageState.Zoo);
    }

    void SwitchToResquing()
    {
        setPlatform(StageState.Resquing);
    }
    private void OnChoosingResquingLevel(int levelToLoad)
    {
        CurrentResquingStage = levelToLoad;
        setPlatform(StageState.Resquing);
        LoadLevel(levelToLoad, resquingStages);
    }
    private void setPlatform(StageState state)
    {
        _curretStageState = state;
        if (_curretStageState==StageState.Zoo)
        {
            LoadLevel(CurrentZooStage,zooStages);    
        }
        else
        {
            LoadLevel(CurrentResquingStage,resquingStages);    
        }
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
    private void addAnimalToproperBiom(GameObject animalToAdd)
    {
        foreach(GameObject stage in zooStages)
        {
            ZooStageController zoo= stage.GetComponent<ZooStageController>();
            zoo.addAnimal(animalToAdd);
        }
    }
}
