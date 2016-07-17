namespace Poomsae
{
    using System;
    using Xamarin.Forms;

    /// <summary>
    /// Carousel page item.
    /// </summary>
    public class CarouselPageItem : ContentPage
    {
        public CarouselPageItem(Color color)
        {
            // ページの区切りが分かりやすいように背景色を設定する.
            BackgroundColor = color;
            // ラベルを生成>
            var label1 = new Label
            {
                FontSize = 40,
                //ビューの中央に配置
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = string.Format("RGB({0:0},{1:0},{2:0})", color.R, color.G, color.B)
            };
            Content = label1;//ラベルのみを配置する
        }
    }
}
