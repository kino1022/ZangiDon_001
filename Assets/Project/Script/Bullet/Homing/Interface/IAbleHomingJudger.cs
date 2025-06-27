namespace Project.Script.Bullet.Homing.Interface {
    /// <summary>
    /// 誘導が可能かどうかの真偽値を返すクラスに対して約束するインターフェース
    /// </summary>
    public interface IAbleHomingJudger{
        
        public bool IsAbleHoming();
        
    }
}