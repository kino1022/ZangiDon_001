using System;

namespace Project.Script.Rune.Interface {
    public interface IRuneDisposeHandler {
        public Action RuneDisposeEvent { get; set; }
    }
}