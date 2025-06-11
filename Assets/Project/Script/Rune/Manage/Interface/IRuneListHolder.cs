using System.Collections.Generic;

namespace Project.Script.Rune.Manage.Interface {
    /// <summary>
    /// ルーンを複数管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IRuneListHolder {
        public RuneInstance GetRune(int index);
        
        public List<RuneInstance> GetRuneList();
        
        public void SetRune(RuneInstance rune);
        
        public void RemoveRune(RuneInstance rune);
        
        public bool GetIsFullList();
    }
}