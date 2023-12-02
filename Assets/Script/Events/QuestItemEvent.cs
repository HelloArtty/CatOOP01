using System;

public class QuestItemEvent
{
    public event Action<string> OnItemCollected;

    public void ItemCollected(string questID)
    {
        if(OnItemCollected != null)
        {
            OnItemCollected(questID);
        }
    }
}
