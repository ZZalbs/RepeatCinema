public enum BehaviourType
{
    LMove,
    RMove,
    Jump,
}
public interface IBehaviour
{
    public BehaviourType Type { get; }
    public void OnPressed();
    public void OnReleased();
}
