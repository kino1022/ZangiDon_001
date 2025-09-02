using System;
using System.Collections.Generic;
using Teiwas.Script.Bullet.Context.Context.Integrator.Interface;
using Teiwas.Script.Bullet.Context.Intetface;

namespace Teiwas.Script.Bullet.Context.Context.Integrator {
    public class BulletContextIntegrator : IBulletContextIntegrator {
        
        public IBulletContext Integrate(List<IBulletContext> contexts) {
            
            if (contexts is null || contexts.Count is 0) {
                throw new ArgumentNullException();
            }
            
            var elements = new List<IBulletContextElement>();

            foreach (var context in contexts) {
                if (context.Elements is null || context.Elements.Count is 0) {
                    continue;
                }
                
                elements.AddRange(context.Elements);
            }

            if (elements.Count is 0) {
                throw new ArgumentNullException();
            }
            
            return new BulletContext(elements);
        }
    }
}