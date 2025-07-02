using System;
using System.Collections.Generic;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Factory;
using Teiwas.Script.Rune.Interface;
using UnityEngine;
using Observable = R3.Observable;

namespace Teiwas.Script.Rune {
    [Serializable]
    public class RuneInstance : IDisposable , IRune
    {
        [OdinSerialize, LabelText("スプライト")]
        protected Sprite m_runeSprite;
        
        [OdinSerialize, LabelText("メイン効果")]
        protected IMainEffect m_main;
        
        [OdinSerialize, LabelText("サブ効果")]
        protected ISubEffect m_sub;
        
        protected List<ReactiveProperty<bool>> activeObservers = new List<ReactiveProperty<bool>>();
        
        public Sprite RuneSprite => m_runeSprite;

        public IMainEffect Main => m_main;

        public ISubEffect Sub => m_sub;

        protected bool m_isActive;

        public RuneInstance(
            Sprite sprite,
            
            IMainEffect main,
            ISubEffect sub
            ) {
            m_main = main;
            m_sub = sub;
        }

        public void Dispose() {
            this.m_isActive = false;
        }
        
        public bool GetIsActive() => m_isActive;

        protected void ObserveActiveInstance() {
            //MainEffect.IsActiveを監視するオブサーバ
            Observable
                .EveryValueChanged(m_main, x => x.IsActive == false)
                .Subscribe( x => {
                    this.Dispose();
                })
                .Dispose();
            //SubEffectData.IsActiveを監視するオブザーバー
            Observable
                .EveryValueChanged(m_sub,x => x.IsActive == false).
                Subscribe(x => {
                    this.Dispose();
                })
                .Dispose();
            
        }
	}
}