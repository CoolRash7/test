using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GAManager : MonoBehaviour
{
    public static GAManager instance;
    void Start()
    {
        Globals.loadGame();
        if (Globals.level == 0) Globals.level = 1;
        Globals.state = Globals.STATE.NONE;
        GameAnalytics.Initialize();
        Globals.gameStartCount++;
        OnStartGame();


        Debug.Log("GA - Start game - " + Globals.gameStartCount);
        Globals.saveGame();
    }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLevelComplete()
    {
        if (Globals.state == Globals.STATE.WIN)
        {
            //AppMetrica
            Dictionary<string, object> send = new Dictionary<string, object>();
            send.Add("level", Globals.level);
            send.Add("time_spent", Globals.seconds);
            AppMetrica.Instance.ReportEvent("level_complete", send);

            //GameAnalytics
            Dictionary<string, object> sendData = new Dictionary<string, object>();
            sendData.Add("count", Globals.level);
            sendData.Add("time_spent", Globals.seconds);
            GameAnalytics.NewDesignEvent("level_complete", sendData);


            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "level - " + Globals.level.ToString(), "time spent - " + Globals.seconds.ToString());
            
        } else
        {

            //AppMetrica
            Dictionary<string, object> send = new Dictionary<string, object>();
            send.Add("level", Globals.level);
            send.Add("time_spent", Globals.seconds);
            AppMetrica.Instance.ReportEvent("fail", send);

            //GameAnalytics
            Dictionary<string, object> sendData = new Dictionary<string, object>();
            sendData.Add("count", Globals.level);
            sendData.Add("time_spent", Globals.seconds);
            GameAnalytics.NewDesignEvent("fail", sendData);

            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "level - " + Globals.level.ToString(), "time spent - " + Globals.seconds.ToString());
        }
        Debug.Log("GA - Level: " + Globals.level);

    }

    public void OnStartLevel()
    {
        //AppMetrica
        Dictionary<string, object> send = new Dictionary<string, object>();
        send.Add("level", Globals.level);
        AppMetrica.Instance.ReportEvent("level_start", send);

        //GameAnalytics
        Dictionary<string, object> sendData = new Dictionary<string, object>();
        sendData.Add("level", Globals.level);
        GameAnalytics.NewDesignEvent("level_start", sendData);

        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "level - " +  Globals.level);

        Debug.Log("GA - Start Level - " + Globals.level);
    }

    public void OnStartGame()
    {
        //AppMetrica
        Dictionary<string, object> send = new Dictionary<string, object>();
        send.Add("count", Globals.gameStartCount);
        AppMetrica.Instance.ReportEvent("game_start", send);

        //GameAnalytics
        Dictionary<string, object> sendData = new Dictionary<string, object>();
        sendData.Add("count", Globals.gameStartCount);
        GameAnalytics.NewDesignEvent("game_start", sendData);

        Debug.Log("GA - Start Level - " + Globals.level);
    }

    public void OnRestart()
    {
        //AppMetrica
        Dictionary<string, object> send = new Dictionary<string, object>();
        send.Add("level", Globals.level);
        AppMetrica.Instance.ReportEvent("restart", send);

        //GameAnalytics
        Dictionary<string, object> sendData = new Dictionary<string, object>();
        sendData.Add("level", Globals.level);
        GameAnalytics.NewDesignEvent("restart", sendData);

        Debug.Log("GA - Restart level - " + Globals.level);
    }

    public void OnMainMenu()
    {
        //AppMetrica
        AppMetrica.Instance.ReportEvent("main_menu");

        //GameAnalytics

        GameAnalytics.NewDesignEvent("main_menu");
    }
}
