using System;
using System.Linq;
using ObservableCollections;
using Project.Script.UIControl.PlayerHUD.Rune;
using R3;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using Teiwas.Script.UIControl.PlayerHUD.RuneSelector.Interface;
using Teiwas.Script.UIControl.Utility;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.UIControl.PlayerHUD.RuneSelector {
    /// <summary>
    /// IRuneSelectorとIRuneSelectorViewの仲介をするクラス
    /// </summary>
    [Serializable]
    public class RuneSelectorPresenter : ARuneListPresenter<IRuneSelector, IRuneSelectorView>, IRuneSelectorPresenter {
        
        [Inject]
        public RuneSelectorPresenter(IRuneSelector model, IRuneSelectorView view) : base(model, view) {}
    }
}