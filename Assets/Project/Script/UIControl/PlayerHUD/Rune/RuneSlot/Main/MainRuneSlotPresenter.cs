using Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Main.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;
using VContainer;

namespace Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Main {
    public class MainRuneSlotPresenter : ARuneListPresenter<IMainRuneSlot,IMainRuneSlotView> , IMainRuneSlotPresenter {
               
        [Inject]
        public MainRuneSlotPresenter(IMainRuneSlot model, IMainRuneSlotView view) : base(model, view) {}
    }
}