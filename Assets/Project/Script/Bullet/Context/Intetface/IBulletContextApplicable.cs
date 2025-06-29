namespace Teiwas.Script.Bullet.Context.Intetface {
    
    /// <summary>
    /// IBulletContextElementの適用対象になるオブジェクトに対して与えるインターフェース
    /// </summary>
    public interface IBulletContextApplicable {
        
        /// <summary>
        /// IBulletContextの内容を適用する
        /// </summary>
        /// <param name="context"></param>
        public void Apply(IBulletContext context);
        
    }
}