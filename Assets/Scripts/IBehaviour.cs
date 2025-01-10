public interface IBehaviour
{
    public BehaviourType Type { get; }
    public void OnPressed();
    public void OnReleased();
}
