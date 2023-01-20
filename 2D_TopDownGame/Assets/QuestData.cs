using System.Collections;
using System.Collections.Generic;

public class QuestData
{
    public string QuestName;
    public int[] npcId;

    public QuestData(string name, int[] npc){
        QuestName = name;
        npcId = npc;
    }
}
