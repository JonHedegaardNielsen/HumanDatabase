namespace PersonAPI
{
	public interface IRepository<T>
	{
		public T? GetSingle(int id);
		public IEnumerable<T> GetAll();
		public void Delete(int id);
		public void Create(T item);
		public void Update(T item);
	}
}
