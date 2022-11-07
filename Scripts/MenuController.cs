using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{


    public void RestartLevel()
    {

        if (Globals.state == Globals.STATE.WIN)
        {
            Globals.level++;

        } else {
            try
            {
                GAManager.instance.OnRestart();
            } catch (System.Exception e)
            {
                Debug.Log("Cant send GA stats - Restart");
            }
        }
        Globals.resetDatas();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuStart()
    {
        Globals.state = Globals.STATE.PLAY;
    }

    public void MenuSound()
    {
        if (Globals.state != Globals.STATE.PAUSE)
        {
            Globals.state = Globals.STATE.PAUSE;
            Time.timeScale = 0;
        } else
        {
            Globals.state = Globals.STATE.PLAY;
            Time.timeScale = 1;
        }
       
    }

    public void MenuBack()
    {
        Globals.state = Globals.STATE.PLAY;
        Time.timeScale = 1;
    }

    public void changeSound()
    {
        Globals.enabledSound = !Globals.enabledSound;
    }

    public void changeVibro()
    {
        Globals.enabledVibro = !Globals.enabledVibro;
    }
    /*
    public void buyEarningPress()
    {
        if (Globals.gameState == Globals.GAMESTATE.ZAVOD)
        {
            if (Globals.rpg.money >= Globals.rpg.earning_press.buy && Globals.rpg.earning_press.level < 11)
            {
                Globals.rpg.money -= Globals.rpg.earning_press.buy;
                Globals.rpg.earning_press.level++;
            }
        }
        
        if (Globals.gameState == Globals.GAMESTATE.WORLD)
        {
            if (Globals.rpg.money >= Globals.rpg.world_truck.buy && Globals.rpg.world_truck.level < 11)
            {
                Globals.rpg.money -= Globals.rpg.world_truck.buy;
                Globals.rpg.world_truck.level++;
            }
        }

    }
    */
    public void buyNewObject()
    {

        if (Globals.gameState == Globals.GAMESTATE.ZAVOD)
        {
            if (Globals.rpg.money >= Globals.rpg.new_object.buy && Globals.rpg.new_object.level < 10)
            {
                Globals.rpg.money -= Globals.rpg.new_object.buy;
                Globals.rpg.new_object.level++;
            }
        }

        if (Globals.gameState == Globals.GAMESTATE.WORLD)
        {
            if (Globals.rpg.money >= Globals.rpg.world_truck.buy && Globals.rpg.world_truck.level < 50)
            {
                Globals.rpg.money -= Globals.rpg.world_truck.buy;
                Globals.rpg.world_truck.level++;
            }
        }
        Globals.goButtonAnimLevelUp = true;
    }

    public void switchMode()
    {
        Globals.gameState = Globals.gameState == Globals.GAMESTATE.WORLD ? Globals.GAMESTATE.ZAVOD : Globals.GAMESTATE.WORLD;

        Globals.goButtonWorldZavod = true;
    }

    public void resetZavod()
    {
        if (Globals.gameState == Globals.GAMESTATE.ZAVOD && !Globals.imFuckingWinner)
            StartCoroutine(resetZavodd());
    }

    IEnumerator resetZavodd ()
    {
        Globals.destroyAllNotebook = true;
        yield return new WaitForSecondsRealtime(0.1f);
        Globals.destroyAllNotebook = false;
        Globals.goRestartNotebook = true;
    }
}
