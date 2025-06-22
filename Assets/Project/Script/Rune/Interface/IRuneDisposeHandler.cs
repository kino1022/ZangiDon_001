using System;

namespace Teiwas.Script.Rune.Interface {
    public interface IRuneDisposeHandler {
        public Action RuneDisposeEvent { get; set; }
    }
}