using System;
using UnityEngine;

namespace Project.Attribute {
    [AttributeUsage(AttributeTargets.Field)]
    public class SelectableSerializeReferenceAttribute : PropertyAttribute
    {
    }
}