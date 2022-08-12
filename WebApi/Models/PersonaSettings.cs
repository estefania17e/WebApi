namespace WebApi.Models;
public class PersonaSettings : IPersonaSettings
{
    public string Server { get;set; }
    public string Database { get; set; }
    public string Collection { get; set; }
}
public interface IPersonaSettings
{
    public string Server { get; set; }
    public string Database { get; set; }
    public string Collection { get; set; }
}
