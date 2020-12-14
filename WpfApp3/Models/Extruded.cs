﻿using System;
using SharpDX;
using System.Collections.Generic;
using System.Text;

namespace WpfApp3.Models
{
    class Extruded : ModelBase
    {
        IList<Vector2> points { get; set; } = new[] {
            new Vector2(0, 1), new Vector2(-1, 0),
             new Vector2(-1, 0), new Vector2(0, -1),};
        Vector3 axisX { get; set; } = new Vector3(0, -1, 0);
        Vector3 p0 { get; set; } = new Vector3(1, 0, 0);
        Vector3 p1 { get; set; } = new Vector3(2, 0, 0);
        public override void Update()
        {
            //Clear
            Positions.Clear();
            Indices.Clear();
            Normals.Clear();

            if (points.Count % 2 != 0)
            {
                throw new InvalidOperationException("The number of points should be even.");
            }
            var p10 = p1 - p0;
            var axisY = Vector3.Cross(axisX, p10);
            axisY.Normalize();
            axisX.Normalize();
            int index0 = Positions.Count;

            for (int i = 0; i < points.Count; i++)
            {
                var p = points[i];
                var d = (axisX * p.X) + (axisY * p.Y);
                Positions.Add(p0 + d);
                Positions.Add(p1 + d);

                if (Normals != null)
                {
                    d.Normalize();
                    Normals.Add(d);
                    Normals.Add(d);
                }

            }

            int n = points.Count - 1;
            for (int i = 0; i < n; i++)
            {
                int i0 = index0 + (i * 2);
                int i1 = i0 + 1;
                int i2 = i0 + 3;
                int i3 = i0 + 2;

                Indices.Add(i0);
                Indices.Add(i1);
                Indices.Add(i2);

                Indices.Add(i2);
                Indices.Add(i3);
                Indices.Add(i0);
            }
        }
    }
}
