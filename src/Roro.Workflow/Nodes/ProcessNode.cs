﻿using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Drawing;

namespace Roro.Workflow
{
    public sealed class ProcessNode : Node
    {
        public ProcessNode()
        {
            this.Ports.Add(new NextPort());
        }

        public override SKPath Render(SKCanvas g, Rectangle r, NodeStyle o)
        {
            var skPath = new SKPath();
            skPath.AddRect(r.ToSKRect());
            using (var p = new SKPaint() { IsAntialias = true })
            {
                p.Color = new Pen(o.BackBrush).Color.ToSKColor();
                g.DrawPath(skPath, p);
                p.IsStroke = true;
                p.Color = o.BorderPen.Color.ToSKColor();
                p.StrokeWidth = o.BorderPen.Width;
                g.DrawPath(skPath, p);
            }
            return skPath;
        }

        public override Size GetSize() => new Size(4, 2);
    }
}
