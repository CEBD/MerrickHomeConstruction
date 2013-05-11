using System;
using System.Collections.Generic;
using System.Linq;
using ClaySharp;
using Orchard.DisplayManagement;

namespace Util {
    public static class ShapeHelper {
        public static dynamic Find(IShape model, string name) {
            var zones = new Dictionary<string, object>();
            ((IClayBehaviorProvider) model).Behavior.GetMembers(_nullFunc, model, zones);
            foreach (string key in zones.Keys
                .Where(key => !key.StartsWith("_"))) {
                var zone = zones[key] as IShape;
                if (zone == null ||
                    zone.Metadata.Type != "ContentZone") {
                    continue;
                }
                foreach (IShape shape in ((dynamic) zone).Items) {
                    if (shape.Metadata.Type == name) {
                        return shape;
                    }
                }
            }
            return null;
        }

        private static readonly Func<object> _nullFunc = () => null;
    }
}