namespace Dapper.WebApi.Services.Queries
{
    public interface ICommandText
    {
       // string GetProducts { get; }
        string GetProductById { get; }
        string GetProductByIdAddress { get; }
        string AddProduct { get; }
    }
}
