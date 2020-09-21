using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckpointsManager : MonoBehaviour
{
    //Singleton Pattern
    public static CheckpointsManager Instance;

    //Checkpoints
    [SerializeField] private GameObject[] checkpoint = null;
    private Animator checkpointAnim;
    private int checkpointNeedsObject = 0;
    
    private int whichCheckPoint = 0;

    //Progression Bar
    [SerializeField] private Slider slider;

    private PlayerMovement playerMovement;
    private float startTouchSpeed = 0;
    private float startForwardSpeed = 0;

    //Counting objects brought by the player
    private int objectCount = 0;
    public int ObjectCount
    {
        get
        {
            return objectCount;
        }

        set
        {
            objectCount = value;
        }
    }

    private bool completeCounting = false;
    private bool isCounting = false;

    //Level Restart Panel
    [SerializeField] private GameObject restartLevelGO;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        playerMovement = PlayerMovement.Instance;
        startTouchSpeed = playerMovement.TouchSpeed;
        startForwardSpeed = playerMovement.ForwardSpeed;
    }
    
    void Update()
    {
        if(PlayerMovement.Instance.ForwardSpeed == 0 && !isCounting)
        {
            isCounting = true;
            //2 seconds for completing the counting
            Invoke("CompleteCounting", 2f);
        }

        //When the counting complete, comparing objectCount and checkpointNeedsObject
        if (completeCounting)
        {
            checkpointNeedsObject = checkpoint[whichCheckPoint].GetComponent<CounterManager>().CheckPointNeedsObject;
            if(objectCount >= checkpointNeedsObject)
            {
                StartCoroutine(CheckpointSuccess());
                completeCounting = false;
            } else
            {
                RestartLevel();
            }
        }
    }

    private void CompleteCounting()
    {
        completeCounting = true;
    }

    private IEnumerator CheckpointSuccess()
    {
        yield return new WaitForSeconds(1f);

        checkpointAnim = checkpoint[whichCheckPoint].GetComponent<Animator>();
        checkpointAnim.SetTrigger("checkOpen");

        yield return new WaitForSeconds(1.1f);
        completeCounting = false;

        yield return new WaitForSeconds(1f);

        playerMovement.TouchSpeed = startTouchSpeed;
        playerMovement.ForwardSpeed = startForwardSpeed;

        isCounting = false;
        objectCount = 0;
        whichCheckPoint++;
        slider.value++;

        StopAllCoroutines();
    }

    private void RestartLevel()
    {
        //Freeze the game
        Time.timeScale = 0;
        restartLevelGO.SetActive(true);
    }
}
