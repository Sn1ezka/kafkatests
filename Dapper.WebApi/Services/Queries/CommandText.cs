namespace Dapper.WebApi.Services.Queries
{   
    public class CommandText : ICommandText
    {
        //public string GetProducts => "Select * from Cash";
        public string GetProductById => "Select * from Cash where requestId= @requestId";
        public string GetProductByIdAddress => "Select * from Cash where ClientId = @ClientId and trim(DepartmentAddress) = @DepartmentAddress";
        public string AddProduct => "Insert into  [tempdb].[dbo].[Cash] (ClientId, DepartmentAddress, Amount,Currency) values (@ClientId, @DepartmentAddress, @Amount, @Currency); SELECT CAST(SCOPE_IDENTITY() as int)";
    }
}
