namespace Backend.App.Common.Interfaces;

public interface ISessionRepo {
    Task<string> GetPasscodeAsync();
}
