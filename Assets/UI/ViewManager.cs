using UnityEngine;
using YG;

public class ViewManager : MonoBehaviour
{
    private bool _isMobile = false;
    private AbstractView[] _view;

    private void Start()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            _isMobile = true;
        }
    }
}
