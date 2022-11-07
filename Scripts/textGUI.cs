using UnityEngine;
using UnityEngine.UI;

public class textGUI : MonoBehaviour
{
    public enum STATE { textmesh_cut, button_modeswitch_1, button_modeswitch_2, textmesh_test1, textmesh_losemoment, image_losemoment,
        //result shits
        image_result, textmesh_level_2, textmesh_level_passed, button_next, textmesh_next,
        textmesh_temp_level, textmesh_modeswitch, image_bg_black, anim_cut,

        //title shits
        button_title, image_title, textmesh_title, system_confetti,
        textmesh_menusound, button_menusound_back, button_menusound_sound, button_menusound_vibro,
        image_menusound, image_menusound_sound, image_menusound_vibro,

        //new rpg
        textmesh_money, textmesh_ear_press_text, textmesh_ear_press_level, textmesh_ear_press_dollar,
        textmesh_new_object_text, textmesh_new_object_level, textmesh_new_object_dollar, image_musor_progress, textmesh_musor_count,
        textmesh_musor_required, image_musor_required, textmesh_musor_required_title, textmesh_mode_zavod_world, image_musor_required_bg,
        anim_button_levelup, anim_button_zavod
    }

    public STATE state;

    TMPro.TextMeshProUGUI textMesh;
    Image image;
    Button button;
    Animator anim;
    ParticleSystem system;
    void Start()
    {
        if (state == STATE.textmesh_cut || state == STATE.textmesh_test1 || state == STATE.textmesh_losemoment ||
            state == STATE.textmesh_level_2 || state == STATE.textmesh_level_passed || state == STATE.textmesh_next ||
            state == STATE.textmesh_temp_level || state == STATE.textmesh_modeswitch || state == STATE.textmesh_title ||
            state == STATE.textmesh_menusound || state == STATE.textmesh_money || state == STATE.textmesh_ear_press_text || state == STATE.textmesh_ear_press_level || state == STATE.textmesh_ear_press_dollar ||
            state == STATE.textmesh_new_object_text ||state == STATE.textmesh_new_object_level || state == STATE.textmesh_new_object_dollar || state == STATE.textmesh_musor_count ||
            state == STATE.textmesh_musor_required || state == STATE.textmesh_musor_required_title || state == STATE.textmesh_mode_zavod_world)
            textMesh = GetComponent<TMPro.TextMeshProUGUI>();

        if (state == STATE.button_modeswitch_1 || state == STATE.button_modeswitch_2 || state == STATE.button_next ||
            state == STATE.button_title || state == STATE.button_menusound_back || state == STATE.button_menusound_sound ||
            state == STATE.button_menusound_vibro)
        {
            image = GetComponent<Image>();
            button = GetComponent<Button>();
        }

        if (state == STATE.image_losemoment || state == STATE.image_result  || state == STATE.image_bg_black || 
            state == STATE.image_title || state == STATE.image_menusound || state == STATE.image_menusound_sound ||
            state == STATE.image_menusound_vibro || state == STATE.image_musor_progress || state == STATE.image_musor_required || state == STATE.image_musor_required_bg)
        {
            image = GetComponent<Image>();
        }

        if (state == STATE.anim_cut || state == STATE.anim_button_levelup || state == STATE.anim_button_zavod)
        {
            anim = GetComponent<Animator>();
        }
        
        if (state == STATE.system_confetti)
        {
            system = GetComponent<ParticleSystem>();
            system.Stop();
        }

    }

    void Update()
    {

        // ==============================TEXT TEXT

        if (state == STATE.textmesh_cut)
        {
            textMesh.text = Globals.cut + "";
            textMesh.color = Globals.cut > 4 ? Color.white : Color.red;
        }

        if (state == STATE.textmesh_test1)
        {
            textMesh.text = Globals.imFuckingWinner + " WIN?";
        }

        if (state == STATE.textmesh_losemoment)
        {
            textMesh.enabled = Globals.loseMoment;
        }

        if (state == STATE.textmesh_level_2)
        {
            textMesh.enabled = Globals.state == Globals.STATE.WIN;
            textMesh.text = "LEVEL " + Globals.level;
        }

        if (state == STATE.textmesh_level_passed)
        {
            string[] textwin =
            {
                "Perfect!",
                "Nice!",
                "Cool!",
                "Good!",
                "Great!",
                "wef"
            };

            textMesh.enabled = Globals.state == Globals.STATE.LOSE || Globals.state == Globals.STATE.WIN;
            textMesh.text = Globals.state == Globals.STATE.WIN ? textwin[Globals.winTextCount] : "NO MORE MOVES!";

        }

        if (state == STATE.textmesh_next)
        {
            textMesh.enabled = Globals.state == Globals.STATE.LOSE || Globals.state == Globals.STATE.WIN;
            textMesh.text = Globals.state == Globals.STATE.WIN ? "NEXT" : "RESTART";

        }

        if (state == STATE.textmesh_temp_level)
            textMesh.text = "LEVEL " + Globals.level;

        if (state == STATE.textmesh_modeswitch)
        {
            textMesh.text = Globals.gameState == Globals.GAMESTATE.ZAVOD ? "SAW" : "HAND";
        }

        if (state == STATE.textmesh_title)
        {
            textMesh.enabled = Globals.state == Globals.STATE.NONE;
        }

        if (state == STATE.textmesh_menusound)
        {
            textMesh.enabled = Globals.state == Globals.STATE.PAUSE;
        }

        if (state == STATE.textmesh_money)
        {
            textMesh.text = Globals.rpg.money + " $";
        }
        
        if (state == STATE.textmesh_ear_press_text)
        {
            textMesh.text = Globals.gameState == Globals.GAMESTATE.ZAVOD ? "EARNING PRESS" : "TRUCK";
        }

       

        if (state == STATE.textmesh_new_object_text)
        {
            textMesh.text = Globals.gameState == Globals.GAMESTATE.ZAVOD ? "NEW OBJECT" : "SPEED";
        }

        if (state == STATE.textmesh_new_object_level)
        {
            textMesh.text = "lvl. " + (Globals.gameState == Globals.GAMESTATE.ZAVOD ? Globals.rpg.new_object.level+1 : Globals.rpg.world_truck.level+1);
        }

        if (state == STATE.textmesh_new_object_dollar)
        {
            textMesh.text = ( Globals.gameState == Globals.GAMESTATE.ZAVOD ? (Globals.rpg.new_object.level >= 10 ? "MAXED" : Globals.rpg.new_object.buy + " $") :
                (Globals.rpg.world_truck.level >= 50 ? "MAXED" : Globals.rpg.world_truck.buy+ " $"));
        }
        /*
        if (state == STATE.textmesh_musor_count)
        {
            textMesh.text = Globals.rpg.musor_count + " / " + Globals.rpg.musor_max;

        }

        if (state == STATE.textmesh_musor_required)
        {
            textMesh.text = Globals.rpg.musor_count + " / " + Globals.rpg.new_object.per_object;
            textMesh.enabled = Globals.rpg.musor_count < Globals.rpg.new_object.per_object;
        }

        if (state == STATE.textmesh_musor_required_title)
        {
            textMesh.enabled = Globals.rpg.musor_count < Globals.rpg.new_object.per_object;
        }
        */
        if (state == STATE.textmesh_mode_zavod_world)
        {
            textMesh.text = Globals.gameState == Globals.GAMESTATE.WORLD ? "FACTORY" : "LAND";
        }

        // ================================ BUTTON BUTTON
        if (state == STATE.button_modeswitch_1)
        {
            button.enabled = Globals.gameState == Globals.GAMESTATE.ZAVOD;
            image.enabled = Globals.gameState == Globals.GAMESTATE.ZAVOD;
        }

        if (state == STATE.button_modeswitch_2)
        {
            button.enabled = Globals.gameState == Globals.GAMESTATE.ZAVOD;
            image.enabled = Globals.gameState == Globals.GAMESTATE.ZAVOD;
        }

        if (state == STATE.button_next)
        {
            button.enabled = Globals.state == Globals.STATE.LOSE || Globals.state == Globals.STATE.WIN;
            image.enabled = Globals.state == Globals.STATE.LOSE || Globals.state == Globals.STATE.WIN;
        }

        if (state == STATE.button_title)
        {
            button.enabled = Globals.state == Globals.STATE.NONE;
            image.enabled = Globals.state == Globals.STATE.NONE;
        }

        if (state == STATE.button_menusound_back)
        {
            button.enabled = Globals.state == Globals.STATE.PAUSE;
            image.enabled = Globals.state == Globals.STATE.PAUSE;
        }

        if (state == STATE.button_menusound_sound)
        {
            button.enabled = Globals.state == Globals.STATE.PAUSE;
            image.enabled = Globals.state == Globals.STATE.PAUSE;
        }

        if (state == STATE.button_menusound_vibro)
        {
            button.enabled = Globals.state == Globals.STATE.PAUSE;
            image.enabled = Globals.state == Globals.STATE.PAUSE;
        }

        // ================================= IAMGE IMAGE
        if (state == STATE.image_losemoment)
        {
            image.enabled = Globals.loseMoment ? true : false;
            image.fillAmount = Globals.loseTimer;
        }

        if (state == STATE.image_result)
        {
            image.enabled = Globals.state == Globals.STATE.WIN;
        }

        if (state == STATE.image_bg_black)
        {
            image.enabled = Globals.state == Globals.STATE.LOSE || Globals.state == Globals.STATE.WIN;
        }

        if (state == STATE.image_title)
        {
            image.enabled = Globals.state == Globals.STATE.NONE;
        }

        if (state == STATE.image_menusound)
        {
            image.enabled = Globals.state == Globals.STATE.PAUSE;
        }

        if (state == STATE.image_menusound_sound)
        {
            image.enabled = Globals.state == Globals.STATE.PAUSE && Globals.enabledSound;
        }

        if (state == STATE.image_menusound_vibro)
        {
            image.enabled = Globals.state == Globals.STATE.PAUSE && Globals.enabledVibro;
        }
        /*
        if (state == STATE.image_musor_progress)
        {
            image.fillAmount = Mathf.Lerp(image.fillAmount, (float)Globals.rpg.musor_count/(float)Globals.rpg.musor_max,2 * Time.deltaTime) ;
        }

        if (state == STATE.image_musor_required)
        {
            image.fillAmount = Mathf.Lerp(image.fillAmount, (float)Globals.rpg.musor_count / (float)Globals.rpg.new_object.per_object, 2 * Time.deltaTime);
            image.enabled = Globals.rpg.musor_count< Globals.rpg.new_object.per_object;
        }
        
        if (state == STATE.image_musor_required_bg)
        {
            image.enabled = Globals.rpg.musor_count < Globals.rpg.new_object.per_object;
        }
        */
        //Animator 

        if (state == STATE.anim_cut)
        {
            if (Globals.goAnimCut)
            {
                anim.Play("Anim", -1, 0f);
                Globals.goAnimCut = false;
            }

            if (Globals.cut <= 4)
            {
                anim.Play("Danger");
            }
        }

        if (state == STATE.anim_button_levelup)
        {
            if (Globals.goButtonAnimLevelUp)
            {
                anim.Play("Anim", -1, 0f);
                Globals.goButtonAnimLevelUp = false;
            }
        }

        if (state == STATE.anim_button_zavod)
        {
            if (Globals.goButtonWorldZavod)
            {
                anim.Play("Anim", -1, 0f);
                Globals.goButtonWorldZavod = false;
            }

 
        }

        //parrticle system 
        if (state == STATE.system_confetti)
        {
            if (Globals.goConfetti &&  !system.isPlaying)
                system.Play();
        }
    }
}
