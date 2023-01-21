using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image portraitImg;
    public Animator portraitAnim;
    public Sprite prePortrait;
    public QuestManager questManager;
    public TalkManager talkManager;
    public Animator talkPanel;
    public TypeEffect talk;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    void Start(){
        Debug.Log(questManager.CheckQuest());
    }
public void Action(GameObject scanObj){
        //Get Current Object
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);
    
        //Visible Talk for Action
        talkPanel.SetBool("isShow", isAction);
}
void Talk(int id, bool isNpc){
        int questTalkIndex = 0;
        string talkData = "";

        //Set Talk Data
        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

    //End Talk
    if(talkData == null){
        isAction =false;
        talkIndex = 0;
        Debug.Log(questManager.CheckQuest(id));
        return;
    }

    //Continue Talk
    if(isNpc){
        talk.SetMsg(talkData.Split(':')[0]);
        
        //Show portrait
        portraitImg.sprite = talkManager.GetPortrait(id,  int.Parse(talkData.Split(':')[1]));
        portraitImg.color = new Color(1,1,1,1);

        //Animation portrait
        if (prePortrait != portraitImg.sprite)
            {
                portraitAnim.SetTrigger("doEffect");
                prePortrait = portraitImg.sprite;
            }
        
    }
    else{
        talk.SetMsg(talkData);

        portraitImg.color = new Color(1,1,1,0);

    }

    isAction =true;
    talkIndex++;
}
}
