namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IPhotoService PhotoService { get; }
        IPhotoDownloadTypeService PhotoDownloadTypeService { get; }

    }
}
