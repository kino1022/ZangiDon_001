using Sirenix.OdinInspector;

namespace Project.Script.UIControl.PlayerHUD.Rune.RuneUI {
    public abstract class AListView<T> : SerializedMonoBehaviour {

        public abstract void Set(int index, T value);
        
        public abstract void Remove(int index);
    }
}