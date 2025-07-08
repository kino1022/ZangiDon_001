namespace Teiwas.Script.Camera.Position.Interface {
    /// <summary>
    /// カメラのオフセットを管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ICameraOffSetHolder {
        
        /// <summary>
        /// カメラが追従対象からどの程度離れるか
        /// </summary>
        public float Distance { get; set; }
        
        /// <summary>
        /// カメラが追従対象からどのくらいの高さを取るか
        /// </summary>
        public float Height { get; set; }
    }
}