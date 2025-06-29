using Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Sub.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;
using VContainer;

namespace Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Sub {
    public class SubRuneSlotPresenter : ARuneListPresenter<ISubRuneSlot,ISubRuneSlotView> , ISubRuneSlotPresenter {
       
        [Inject]
        public SubRuneSlotPresenter(ISubRuneSlot model, ISubRuneSlotView view) : base(model, view) {}
    }
}