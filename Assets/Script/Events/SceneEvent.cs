using System;

public class SceneEvent
{
    public event Action onSceneChange;

    public void SceneChange()
    {
        onSceneChange();
    }

    public event Action onSceneLoad;
    public void SceneLoad()
    {
        onSceneLoad();
    }
}
