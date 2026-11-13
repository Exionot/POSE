namespace cc105_pose_proj.Data
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T? GetById(int id);
        bool Add(T entity);
        bool Update(T entity); 
        bool Delete(int id);
    }
}
