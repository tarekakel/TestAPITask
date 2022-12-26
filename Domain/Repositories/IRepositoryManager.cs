namespace Domain.Repositories
{
    public interface IRepositoryManager
    {

        IUnitOfWork UnitOfWork { get; }
        IPhotoRepository PhotoRepository { get; }
        IPhotoDownloadTypeRepository PhotoDownloadTypeRepository { get; }
    }
}
