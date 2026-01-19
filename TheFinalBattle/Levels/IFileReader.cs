namespace TheFinalBattle.Levels
{
    public interface IFileReader<T>
    {
        T Read(string path);
    }
}
