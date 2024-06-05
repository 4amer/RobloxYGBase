using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MobileViewModel : AbstractViewModel
{
    private MobileView _view;
    private MobileModel _model;

    [Inject]
    public void Construct(MobileView view, MobileModel model)
    {
        _view = view;
        _model = model;
    }
}
