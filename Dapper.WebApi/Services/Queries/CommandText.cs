namespace Dapper.WebApi.Services.Queries
{   
    public class CommandText : ICommandText
    {
        //public string GetProducts => "Select * from Cash";
        public string GetProductById => "Select * from Cash where request_id= @request_id";
        public string GetProductByIdAddress => "Select * from Cash where Client_id = @Client_id and trim(Department_address) = @Department_address";
        public string AddProduct => "Insert into  [tempdb].[dbo].[Cash] (Client_id, Department_address, Amount,Currency) values (@Client_id, @Department_address, @Amount, @Currency); SELECT CAST(SCOPE_IDENTITY() as int)";
    }
}
