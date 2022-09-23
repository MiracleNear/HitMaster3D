namespace Core.ObjectPool
{
    public interface IObjectPool<T>
    {
        public T GetFreeElement();

        public void ReturnToPool(T template);
    }
}