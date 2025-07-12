namespace Teiwas.Script.Character.LockManage.Interface {
    /// <summary>
    /// ターゲットの変更を行うクラスに対して与えるインターフェース
    /// </summary>
    public interface ILockTargetSelector {

        /// <summary>
        /// ターゲット変更が可能かどうか
        /// </summary>
        bool Changeable { get; set; }

        /// <summary>
        /// ターゲットを次のターゲットに変更する
        /// </summary>
        public void NextTarget();
    }
}
