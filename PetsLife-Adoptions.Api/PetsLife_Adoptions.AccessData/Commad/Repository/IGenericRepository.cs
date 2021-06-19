namespace AccessData.Commad.Repository
{
    public interface IGenericRepository
    {
        public void Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(int _id) where T : class;

    }
}
