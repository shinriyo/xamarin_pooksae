namespace LoadingMessageSample.Services
{
    public interface ILoadingMessage
    {
        /// <summary>ローディングを開始する</summary>
        /// <param name="message"></param>
        void Show(string message);

        /// <summary>ローディングを終了する</summary>
        void Hide();

        /// <summary>状態</summary>
        bool IsShow { get; }
    }
}
