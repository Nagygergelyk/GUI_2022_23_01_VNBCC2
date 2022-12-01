using GUI_2022_23_01_VNBCC2.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
                        ImageBrush brush = new ImageBrush();
                        switch (model.GameMatrix[i, j].item)
                        {
                            case GameLogic.Items.table:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.floor:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i, j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.grill:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i, j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.deepfryer:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i, j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.output:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i, j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.start:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.cuttingboard:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.trash:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.plate:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.bread:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.meat:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.cheese:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.salad:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.bacon:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.onion:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.sauce:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.tomato:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.cucumber:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.oil:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.potato:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.glasses:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
                                break;
                            case GameLogic.Items.drink:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", $"{model.GameMatrix[i,j].Image}"), UriKind.RelativeOrAbsolute)));
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

