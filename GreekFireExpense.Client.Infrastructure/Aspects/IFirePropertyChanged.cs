namespace GreekFire.Client.Infrastructure.Aspects
{
    /// <summary>
    /// Taken from Post Sharp PropertyChanged Example
    /// </summary>
    public interface IFirePropertyChanged
    {
        void OnPropertyChanged(string propertyName);
    }
}