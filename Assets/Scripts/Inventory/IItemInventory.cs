public interface IItemInventory
{
    public abstract bool CanUsedAsATool();
    public abstract bool CanBeStored();
    public abstract void Use();
    public abstract void StoreInInventory();
    public abstract void RemoveFromInventory();
}
