using System;

namespace Project.Script.Rune.Manage.Interface { 
    /// <summary>
    /// ���炩�̗v���ŊǗ����Ă��郋�[���������������ۂɔ��΂����C�x���g�����N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface IRuneDisposeHandler {
        /// <summary>
        /// ���[���������������ۂɔ��΂����C�x���g
        /// </summary>
        public Action<RuneInstance> RuneDisposeEvent { get; set; }
    }
}