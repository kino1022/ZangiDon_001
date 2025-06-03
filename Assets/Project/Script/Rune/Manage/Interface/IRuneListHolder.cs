namespace Project.Script.Rune.Manage.Interface {
    /// <summary>
    /// ルーンを複数管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IRuneListHolder {
        
        public int GetListSize();
        
        public RuneInstance GetRune(int index);
        
        public RuneInstance[] GetAllRunes();
        
        public void AddRune(RuneInstance rune);
        
        public void RemoveRune(int index);
        
        public void RemoveRune(RuneInstance rune);
    }
}