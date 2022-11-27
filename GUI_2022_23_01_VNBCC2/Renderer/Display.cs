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

        Size size;

        public void Resize(Size size)
        {
            this.size = size;
        }
        public void SetupModel(IGameModel model)
        {
            this.model = model;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (model != null & size.Width > 50 & size.Height > 50)
            {
                double rectWidth = size.Width / model.GameMatrix.GetLength(1);
                double rectHeight = size.Height / model.GameMatrix.GetLength(0);

                for (int i = 0; i < model.GameMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < model.GameMatrix.GetLength(1); j++)
                    {
                        switch (model.GameMatrix[i, j])
                        {
                            case GameLogic.Items.table:
                                break;
                            case GameLogic.Items.floor:
                                break;
                            case GameLogic.Items.grill:
                                break;
                            case GameLogic.Items.deepfryer:
                                break;
                            case GameLogic.Items.output:
                                break;
                            case GameLogic.Items.start:
                                break;
                            case GameLogic.Items.cuttingboard:
                                break;
                            case GameLogic.Items.trash:
                                break;
                            case GameLogic.Items.plate:
                                break;
                            case GameLogic.Items.bread:
                                break;
                            case GameLogic.Items.meat:
                                break;
                            case GameLogic.Items.cheese:
                                break;
                            case GameLogic.Items.salad:
                                break;
                            case GameLogic.Items.bacon:
                                break;
                            case GameLogic.Items.onion:
                                break;
                            case GameLogic.Items.sauce:
                                break;
                            case GameLogic.Items.tomato:
                                break;
                            case GameLogic.Items.cucumber:
                                break;
                            case GameLogic.Items.oil:
                                break;
                            case GameLogic.Items.potato:
                                break;
                            case GameLogic.Items.glasses:
                                break;
                            case GameLogic.Items.drink:
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}

