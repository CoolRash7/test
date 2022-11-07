using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherBrain : MonoBehaviour
{
    
    float loseTime = 0;
    [Header("Level Generator")]
    public GameObject[] obj_slice;

    [Header("Globals Settings")]
    public float speedRunner = 50;
    public float speedRight = 50;
    public float speedLeft = 50;

    [Header("TEST ONLY")]
    public bool imfuckingwinner = false;
    public float timerwin = 0;

    bool dontSpam1 = false;
    bool dontSpam2 = false;
    int countItem = -1;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        Globals.rpg.init();
        StartCoroutine(LoadDelay());
        Globals.seconds = 0;
        StartCoroutine(Seconds());
        Globals.imFuckingWinner = false;
        //Globals.setFuckingShittySizeGatgets();
        //generateLevel();


        try
        {
            GAManager.instance.OnStartLevel();
        } catch (System.Exception e)
        {
            Debug.Log("Cant send stats G3A - start level");
        }

        //on manin menu once
        if (Globals.state == Globals.STATE.NONE)
        {
            try
            {
                GAManager.instance.OnMainMenu();
                Debug.Log("GA - On MAIN MENU");
            } catch (System.Exception e)
            {
                Debug.Log("Cant send stats GA - On MAIN MENU");
            }
           
        }
    }

    private void OnApplicationPause(bool pause)
    {

        if (Globals.seconds > 3)
            Globals.saveGame();
    }

    private void OnApplicationQuit()
    {
        if (Globals.seconds > 3)
            Globals.saveGame();
    }

    private void Awake()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //TESTY ONLY
        imfuckingwinner = Globals.imFuckingWinner;
        timerwin = Globals.winTimer;

        //if (Globals.cut <= 0) Globals.gameState = Globals.GAMESTATE.HANDHELD;
        //Global Game Controller

        switch (Globals.state)
        {
            case Globals.STATE.PLAY:

                //game controls
                switch (Globals.gameState)
                {
                    case Globals.GAMESTATE.ZAVOD:
                        break;

                    case Globals.GAMESTATE.WORLD:
                        Globals.timbersawState = Globals.TIMBERSAWSTATE.NONE;

                        break;
                }

                //game over check
                if ( Globals.cut <= 0)
                {
                    loseTime += Time.deltaTime * 1f;
                    if (loseTime >= 3)
                        Globals.state = Globals.STATE.LOSE;
                }else 
                    loseTime = 0;

                //win check
                if (Globals.imFuckingWinner)
                {
                    Globals.winTimer += Time.deltaTime * 1f;
                    if (Globals.winTimer >= 1  && !dontSpam2)
                    //&& Globals.rpg.musor_count >= Globals.rpg.new_object.per_object
                    {
                        StartCoroutine(NextObject());
                        Globals.imFuckingWinner = false;
                        Globals.winTimer = 0;
                        dontSpam2 = true;
                    }
                }
                else
                {
                    Globals.winTimer = 0;
                    dontSpam2 = false;
                }
                break;

            case Globals.STATE.WIN:
                if (!dontSpam1)
                {
                    try
                    {
                        GAManager.instance.OnLevelComplete();
                    }catch(System.Exception e)
                    {
                        Debug.Log("Cant send GA stats");
                    }
                    Globals.winTextCount = Random.Range(0, 5);

                    dontSpam1 = true;

                }
                break;

            case Globals.STATE.LOSE:
                if (!dontSpam1)
                {
                    try
                    {
                        GAManager.instance.OnLevelComplete();
                    } catch (System.Exception e)
                    {
                        Debug.Log("Cant send GA stats");
                    }
                    dontSpam1 = true;
                }
                break;
        }    
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.R))
            Globals.rpg.money = 222222;
        if (Input.GetKey(KeyCode.F))
            Globals.saveGame();

        if (Globals.goRestartNotebook) 
            StartCoroutine(RestartObject());
        
    }

    private void LateUpdate()
    {
        Globals.imFuckingWinner = true;
        Globals.speedRunner = speedRunner;
        Globals.speedRight = speedRight;
        Globals.speedLeft = speedLeft;
    }

    void generateLevel()
    {
        int count = Globals.getTempLevelCount;

        int[] arr = new int[obj_slice.Length];

        System.Random random = new System.Random();
        int[] rand_obj = new int[obj_slice.Length];

        for (int i = 0; i < arr.Length; i++)
            arr[i] = i != 9 ? i : 2;

        //Fisher-Iates shaffle
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int randomIndex = random.Next(0, i + 1);

            int temp = arr[i];
            arr[i] = arr[randomIndex];
            arr[randomIndex] = temp;
        }

        //рандомы присваиваем в этот наш массивчикк
        for (int i = 0; i < rand_obj.Length; i++)
        {
            rand_obj[i] = arr[i];
            //Debug.Log("rand_obj[" + i + "] = " + rand_obj[i]);
        }

        for (int i = 0; i < count; i++)
            Instantiate(obj_slice[rand_obj[i]], transform.position + new Vector3(0, 0, -(i *4)), Quaternion.Euler(0,  
                rand_obj[i] == 2  ? 90 : 180, 0) );
        
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Globals.loadGame();
        checkLoadDatas();
        StartCoroutine(NextObject());

        /*
        if (Globals.rpg.musor_count >= Globals.rpg.new_object.per_object)
        {
            
        }

        */
    }

    IEnumerator Winner()
    {
        Globals.goConfetti = true;
        yield return new WaitForSeconds(1);
        Globals.state = Globals.STATE.WIN;
    }
   
    void checkLoadDatas()
    {
        if (Globals.rpg.new_object.level == 0)
            Globals.rpg.new_object.level = 1;

        if (Globals.rpg.world_truck.level == 0)
            Globals.rpg.world_truck.level = 1;

    }

    IEnumerator NextObject()
    {
        if (++countItem > Globals.rpg.new_object.level - 1) countItem = 0;
        Instantiate(obj_slice[countItem], transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,
                countItem == 1 || countItem == 2 ? 90 : 180, 0));


        //Globals.rpg.musor_count -= Globals.rpg.new_object.per_object;
        //Globals.rpg.musor_count = Mathf.Clamp(Globals.rpg.musor_count, 0, Globals.rpg.musor_max);
        yield return null;
    }
        
        IEnumerator RestartObject()
    {
        Instantiate(obj_slice[countItem], transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,
               countItem == 1 || countItem == 2 ? 90 : 180, 0));
        Globals.goRestartNotebook = false;
        yield return null;
     
    }

    IEnumerator Seconds()
    {
        yield return new WaitForSeconds(1);
        Globals.seconds++;
        StartCoroutine(Seconds());
    }
}
