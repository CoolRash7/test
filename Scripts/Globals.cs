using System.Collections.Generic;
using UnityEngine;
public static class Globals
{
    //STATES
    public enum GAMESTATE { NONE, WORLD, ZAVOD };
    public enum STATE { NONE, PLAY, LOSE, WIN, PAUSE };
    public enum TIMBERSAWSTATE { NONE, READY, GO };
    public enum TRAKTORSTATE { NONE, GO_MUSOR, GO_BAZA };

    //TYPES
    public enum GATGETTYPE { NOTEBOOK, IPHONE, DUALSHOCK, DRILL, DRYER, GUITAR, HAGGI, CLOSET, SOUNDBOX, SCALES, CLOCK, TV };

    public static STATE state = STATE.NONE;
    public static GAMESTATE gameState = GAMESTATE.ZAVOD;
    public static TIMBERSAWSTATE timbersawState = TIMBERSAWSTATE.NONE;

    //public static Dictionary<GATGETTYPE, gatget> gatgetData = new Dictionary<GATGETTYPE, gatget>();

    public static int gameStartCount = 0;
    public static int seconds = 0;
    public static int level = 1;
    public static Vector3 timbersawStartPoint;
    public static int cut = 20;
    public static Vector3 vectorCursor;
    public static float angleAbar = 0;
    public static bool imFuckingWinner = false;
    public static bool imFuckingLoser = false;
    public static bool destroyAllNotebook = false;

    //new vars
    public static _rpg rpg;
    public static List<int> ID = new List<int>();
    public static Dictionary<int, _musor> musor = new Dictionary<int, _musor>();
    public static _baza[] baza = new _baza[4];
    public static int maxMusorCount = 4;

    public static float speedRunner = 50;
    public static float speedRight = 50;
    public static float speedLeft = 50;

    public static bool enabledSound = true;
    public static bool enabledVibro = true;

    //simple signals
    public static bool goAnimCut = false;
    public static int winTextCount = 0;
    public static bool goConfetti = false;
    public static bool goEzySlice = false;
    public static bool goRestartNotebook = false;
    public static bool goButtonAnimLevelUp = false;
    public static bool goButtonWorldZavod = false;

    //old
    public static bool loseMoment = false;
    public static float loseTimer = 0;
    public static float winTimer = 0;
    public static float tempFlyY = 0;
    public static float getSizeGameObject(GameObject obj)
    {
        MeshFilter filter = obj.GetComponent<MeshFilter>();
        float result = filter.sharedMesh.bounds.size.x + filter.sharedMesh.bounds.size.y + filter.sharedMesh.bounds.size.z;
        float multiply = 1000;


        return result * multiply;
    }

    public static float AbarAngle(Vector2 pos1, Vector2 pos2)
    {
        Vector2 dir = pos1 - pos2;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return angle;
    }

    //my structs and ect shits... 
    public struct gatget
    {

        public float min;
        public float max;
    }
    /*
    public static void setFuckingShittySizeGatgets()
    {
        gatgetData.Clear();
        gatget gatgetNotebook;
        gatget gatgetIphone;
        gatget gatgetDualshock;
        gatget gatgetDrill;
        gatget gatgetDryer;
        gatget gatgetHaggi;
        gatget gatgetGuitar;
        gatget gatgetCloset;
        gatget gatgetSoundbox;
        gatget gatgetScales;
        gatget gatgetClock;
        gatget gatgetTV;

        //size gatget
        gatgetNotebook.max = 35.58f;
        gatgetNotebook.min = percent(gatgetNotebook.max, 30);

        gatgetIphone.max = 29.68f;
        gatgetIphone.min = percent(gatgetIphone.max, 30);

        gatgetDualshock.max = 44.40f;
        gatgetDualshock.min = percent(gatgetDualshock.max, 30);

        gatgetDrill.max = 82.35f;
        gatgetDrill.min = percent(gatgetDrill.max, 30);

        gatgetDryer.max = 56.18f;
        gatgetDryer.min = percent(gatgetDryer.max, 30);

        gatgetHaggi.max = 81.72f;
        gatgetHaggi.min = percent(gatgetHaggi.max, 30);

        gatgetGuitar.max = 77.91f;
        gatgetGuitar.min = percent(gatgetGuitar.max, 30);

        gatgetCloset.max = 74.17f;
        gatgetCloset.min = percent(gatgetCloset.max, 30);

        gatgetSoundbox.max = 110.26f;
        gatgetSoundbox.min = percent(gatgetSoundbox.max, 30);

        gatgetScales.max = 43.06f;
        gatgetScales.min = percent(gatgetScales.max, 30);

        gatgetClock.max = 51.99f;
        gatgetClock.min = percent(gatgetClock.max, 30);

        gatgetTV.max = 72.51f;
        gatgetTV.min = percent(gatgetTV.max, 30);

        gatgetData.Add(GATGETTYPE.NOTEBOOK, gatgetNotebook);
        gatgetData.Add(GATGETTYPE.IPHONE, gatgetIphone);
        gatgetData.Add(GATGETTYPE.DUALSHOCK, gatgetDualshock);
        gatgetData.Add(GATGETTYPE.DRILL, gatgetDrill);
        gatgetData.Add(GATGETTYPE.DRYER, gatgetDryer);
        gatgetData.Add(GATGETTYPE.HAGGI, gatgetHaggi);
        gatgetData.Add(GATGETTYPE.GUITAR, gatgetGuitar);
        gatgetData.Add(GATGETTYPE.CLOSET, gatgetCloset);
        gatgetData.Add(GATGETTYPE.SOUNDBOX, gatgetSoundbox);
        gatgetData.Add(GATGETTYPE.SCALES, gatgetScales);
        gatgetData.Add(GATGETTYPE.CLOCK, gatgetClock);
        gatgetData.Add(GATGETTYPE.TV, gatgetTV);
    }
    */

    public static int getTempLevelCount
    {
        get
        {
            int result;

            switch (Globals.level)
            {
                case 1:
                    result = 1;
                    break;

                case 2:
                    result = 1;
                    break;


                default:
                    result = 2;
                    break;
            }
            return result;
        }
    }

    public static int getTempLevelCut
    {
        get
        {
            int result;
            switch (Globals.level)
            {
                case 1:
                    result = 20;
                    break;

                case 2:
                    result = 20;
                    break;

                default:
                    result = 25;
                    break;
            }
            return result;
        }
    }

    public static void resetDatas()
    {
        goConfetti = false;
        //setFuckingShittySizeGatgets();
        cut = getTempLevelCut;
        state = STATE.PLAY;
        imFuckingLoser = false;
        gameState = GAMESTATE.WORLD;
        loseMoment = false;
        loseTimer = 0;
        winTimer = 0;
    }

    public static float percent(float _100, float needPercent)
    {
        float result = 0;
        float _1percent = _100 / 100;
        result = _1percent * needPercent;
        return result;
    }

    public static void loadGame()
    {
        Globals.rpg.money = PlayerPrefs.GetInt("money");
        //Globals.rpg.musor_count = PlayerPrefs.GetInt("musor_count");

        Globals.rpg.new_object.level = PlayerPrefs.GetInt("lvl_new_object");

        Globals.rpg.world_truck.level = PlayerPrefs.GetInt("lvl_world_truck");
        for (int i = 0; i < Globals.ID.Count; i++)
        {
            Globals._musor tempMusor;
            tempMusor.isAlive = PlayerPrefs.GetInt("musor" + i) == 0 ? true : false;
            tempMusor.pos = Globals.musor[i].pos;
            Globals.musor[i] = tempMusor;
        }
        Debug.Log("GAME LOADED");
    }

    public static void saveGame()
    {
        PlayerPrefs.SetInt("money", (int)Globals.rpg.money);
        //PlayerPrefs.SetInt("musor_count", Globals.rpg.musor_count);

        PlayerPrefs.SetInt("lvl_new_object", Globals.rpg.new_object.level);

        PlayerPrefs.SetInt("lvl_world_truck", Globals.rpg.world_truck.level);


        //9912
        for (int i = 0; i < Globals.ID.Count; i++)
        {
            PlayerPrefs.SetInt("musor" + i, Globals.musor[i].isAlive ? 0 : -1);
        }
        Debug.Log("GAME SAVED");
    }





    /// <summary>
    /// qwenew
    /// /////////////////////////////////////////// NEW EWF:LJWEF:LWEKJF:ELWKFJ:EWLKFJ NEW NEW NEW 
    /// </summary>

    public struct _rpg
    {
        public float money;
        /*public int musor_count;
        public int musor_max
        {
            get
            {
                return 100;
            }
        }
        */
        //zavod
        public _new_object new_object;
        //world
        public _world_truck world_truck;
        public Dictionary<GATGETTYPE, int> gatgetMoney;

        public void init()
        {
            money = 0;

            new_object.level = 1;

            world_truck.level = 1;

            gatgetMoney = new Dictionary<GATGETTYPE, int>();
            gatgetMoney.Add(GATGETTYPE.CLOCK, 1);
            gatgetMoney.Add(GATGETTYPE.HAGGI,3);
            gatgetMoney.Add(GATGETTYPE.IPHONE, 3);
            gatgetMoney.Add(GATGETTYPE.NOTEBOOK, 6);
            gatgetMoney.Add(GATGETTYPE.DUALSHOCK, 6);
            gatgetMoney.Add(GATGETTYPE.SCALES, 9);
            gatgetMoney.Add(GATGETTYPE.DRYER, 9);
            gatgetMoney.Add(GATGETTYPE.DRILL, 12);
            gatgetMoney.Add(GATGETTYPE.TV, 12);
            gatgetMoney.Add(GATGETTYPE.SOUNDBOX, 15);
            gatgetMoney.Add(GATGETTYPE.CLOSET, 17);

        }
    }

    public struct _earning_press
    {
        public int level;

        public int buy
        {
            get
            {
                int result;
                switch (level)
                {
                    case 1:
                        result = 500;
                        break;

                    case 2:
                        result = 1000;
                        break;

                    case 3:
                        result = 1500;
                        break;

                    case 4:
                        result = 2000;
                        break;

                    case 5:
                        result = 2500;
                        break;

                    case 6:
                        result = 3000;
                        break;
                    case 7:
                        result = 3500;
                        break;

                    case 8:
                        result = 4000;
                        break;

                    case 9:
                        result = 4500;
                        break;

                    case 10:
                        result = 5000;
                        break;

                    case 11:
                        result = 5500;
                        break;
                    default:
                        result = 6000;
                        break;
                }
                return result;
            }
        }

        public float multiply_dohod
        {
            get
            {
                float result;
                switch (level)
                {
                    case 1:
                        result = 1;
                        break;

                    case 2:
                        result = 1.2f;
                        break;

                    case 3:
                        result = 1.4f;
                        break;

                    case 4:
                        result = 1.6f;
                        break;

                    case 5:
                        result = 1.8f;
                        break;

                    case 6:
                        result = 2f;
                        break;

                    case 7:
                        result = 2.2f;
                        break;

                    case 8:
                        result = 2.4f;
                        break;

                    case 9:
                        result = 2.6f;
                        break;

                    case 10:
                        result = 2.8f;
                        break;

                    case 11:
                        result = 3f;
                        break;

                    default:
                        result = 3.2f;
                        break;
                }
                return result;
            }
        }
    }

    public struct _speed_cut
    {
        public int level;

        public int buy
        {
            get
            {
                int result;
                switch (level)
                {
                    case 1:
                        result = 10;
                        break;

                    case 2:
                        result = 15;
                        break;

                    case 3:
                        result = 20;
                        break;

                    case 4:
                        result = 25;
                        break;

                    case 5:
                        result = 30;
                        break;

                    case 6:
                        result = 35;
                        break;

                    case 7:
                        result = 40;
                        break;

                    case 8:
                        result = 45;
                        break;

                    case 9:
                        result = 50;
                        break;

                    case 10:
                        result = 55;
                        break;

                    case 11:
                        result = 60;
                        break;

                    default:
                        result = 65;
                        break;
                }
                return result;
            }
        }

        public float multiply_speed
        {
            get
            {
                float result;

                switch (level)
                {
                    case 1:
                        result = 1.2f;
                        break;

                    case 2:
                        result = 1.4f;
                        break;
                    case 3:
                        result = 1.6f;
                        break;

                    case 4:
                        result = 1.8f;

                        break;

                    case 5:
                        result = 2f;
                        break;

                    case 6:
                        result = 2.2f;
                        break;

                    case 7:
                        result = 2.4f;
                        break;

                    case 8:
                        result = 2.6f;
                        break;

                    case 9:
                        result = 2.8f;
                        break;

                    case 10:
                        result = 3f;
                        break;

                    case 11:
                        result = 3.2f;
                        break;

                    default:
                        result = 3.4f;
                        break;
                }
                return result;
            }
        }
    }

    public struct _new_object
    {
        public int level;

        public int buy
        {
            get
            {
                int result;
                switch (level)
                {
                    case 1:
                        result = 200;
                        break;

                    case 2:
                        result = 400;
                        break;

                    case 3:
                        result = 600;
                        break;

                    case 4:
                        result = 800;
                        break;

                    case 5:
                        result = 1000;
                        break;

                    case 6:
                        result = 1200;
                        break;

                    case 7:
                        result = 1400;
                        break;

                    case 8:
                        result = 1600;
                        break;

                    case 9:
                        result = 1800;
                        break;

                    case 10:
                        result = 2000;
                        break;

                    case 11:
                        result = 2200;
                        break;

                    default:
                        result = 2200;
                        break;
                }
                return result;
            }
        }
        public int per_object
        {
            get
            {
                int result = 1;
                
                switch (level)
                {
                    case 1:
                        result = 3;
                        break;

                    case 2:
                        result = 4;
                        break;

                    case 3:
                        result = 5;
                        break;

                    case 4:
                        result = 6;
                        break;

                    case 5:
                        result = 7;
                        break;

                    case 6:
                        result = 8;
                        break;

                    case 7:
                        result = 9;
                        break;

                    case 8:
                        result = 10;
                        break;

                    case 9:
                        result = 11;
                        break;

                    case 10:
                        result = 12;
                        break;

                    default:
                        result = 12;
                        break;
                }

                return result;
            }
        }

        public int dohod
        {
            get
            {
                int result = 1;

                switch (level)
                {
                    case 1:
                        result = 1;
                        break;

                    case 2:
                        result =1;
                        break;

                    case 3:
                        result = 1;
                        break;

                    case 4:
                        result = 2;
                        break;

                    case 5:
                        result = 2;
                        break;

                    case 6:
                        result = 2;
                        break;

                    case 7:
                        result = 3;
                        break;

                    case 8:
                        result = 3;
                        break;

                    case 9:
                        result = 3;
                        break;

                    case 10:
                        result = 3;

                        break;

                    default:
                        result = 3;
                        break;
                }
                return result;
            }
        }
    }

    public struct _world_truck
    {
        public int level;

        public int buy
        {
            get
            {
                int result;
                switch (level)
                {
                    case 1:
                        result = 300;
                        break;

                    case 2:
                        result = 500;
                        break;

                    case 3:
                        result = 700;
                        break;

                    case 4:
                        result = 900;
                        break;

                    case 5:
                        result = 1100;
                        break;

                    case 6:
                        result = 1300;
                        break;

                    case 7:
                        result = 1500;
                        break;

                    case 8:
                        result = 1700;
                        break;

                    case 9:
                        result = 1900;
                        break;

                    case 10:
                        result = 2100;
                        break;
                    default:
                        result = 2100;
                        break;
                }
                return result;
            }
        }
    }

    public struct _world_speed
    {
        public int level;

        public int buy
        {
            get
            {
                int result;
                switch (level)
                {
                    case 1:
                        result = 1000;
                        break;

                    case 2:
                        result = 2000;
                        break;

                    case 3:
                        result = 3000;
                        break;

                    case 4:
                        result = 4000;
                        break;

                    case 5:
                        result = 5000;
                        break;

                    case 6:
                        result = 6000;
                        break;

                    case 7:
                        result = 7000;
                        break;

                    case 8:
                        result = 8000;
                        break;

                    case 9:
                        result = 9000;
                        break;

                    case 10:
                        result = 10000;
                        break;
                    default:
                        result = 11000;
                        break;
                }
                return result;
            }
        }

        public float multiply_speed
        {
            get
            {
                float result;

                switch (level)
                {
                    case 1:
                        result = 1f;
                        break;

                    case 2:
                        result = 1.2f;
                        break;
                    case 3:
                        result = 1.4f;
                        break;

                    case 4:
                        result = 1.6f;
                        break;

                    case 5:
                        result = 1.8f;
                        break;

                    case 6:
                        result = 2f;
                        break;

                    case 7:
                        result = 2.2f;
                        break;

                    case 8:
                        result = 2.4f;
                        break;

                    case 9:
                        result = 2.6f;
                        break;

                    case 10:
                        result = 2.8f;
                        break;

                    case 11:
                        result = 3.0f;
                        break;

                    default:
                        result = 3.4f;
                        break;
                }
                return result;
            }
        }

    }

    //—“–Œ… ¿ —“–Œ… ¿ 
    //—“–Œ… ¿ —“–Œ… ¿ 
    //===========================================================—“–Œ… ¿ —“–Œ… ¿ 
    //=================================================================—“–Œ… ¿ —“–Œ… ¿ 
    //=================================================================—“–Œ… ¿ —“–Œ… ¿ 
    public struct _musor
    {
        public bool isAlive;
        public Vector3 pos;
    }

    public struct _baza
    {
        public Vector3 pos;
    }


}