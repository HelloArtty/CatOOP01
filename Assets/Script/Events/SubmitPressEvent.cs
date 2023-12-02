using System;

public class SubmitPressEvent
{
    public event Action onSubmitPress;

    public void SubmitPressed()
    {
        onSubmitPress();
    }
}
