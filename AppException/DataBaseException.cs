namespace MedicineTag.AppException;

public class DataBaseException : Exception
{ 
    public DataBaseException(): base("發生錯誤")
    {
    
    }

    public DataBaseException(string errorMsg) : base(errorMsg)
    {

    }
}

