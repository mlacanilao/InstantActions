namespace InstantActions
{
    public interface IOmegaWidget<T> where T : ELayer
    {
        T Setup(object arg);
    }
}