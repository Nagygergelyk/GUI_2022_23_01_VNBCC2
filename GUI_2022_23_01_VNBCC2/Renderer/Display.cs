using GUI_2022_23_01_VNBCC2.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_2022_23_01_VNBCC2.Renderer
{
    public class Display : FrameworkElement
    {
        IGameModel model;

        public void SetupModel(IGameModel model)
        {
            this.model = model;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
        }
    }
}
