//-----------------------------------------------------------------------
// <copyright file="TabbedPageItem.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Poomsae
{
    using Xamarin.Forms;

    /// <summary>
    /// Tabbed page item(現在使っていない).
    /// </summary>
    public class TabbedPageItem : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Poomsae.TabbedPageItem"/> class.
        /// </summary>
        /// <param name="title">Title.</param>
        public TabbedPageItem(string title)
        {
            // タブに表示される文字列
            base.Title = title;

            // ラベルを生成
            var label1 = new Label
            {
                FontSize = 40,

                // ビューの中央に配置.
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = title
            };

            // ラベルのみを配置する.
            base.Content = label1;
        }
    }
}
