namespace MedicineTag.AppException;

public class DataNotFoundException : Exception
{
    public DataNotFoundException() : base("發生錯誤")
    {

    }

    public DataNotFoundException(string errorMsg) : base(errorMsg)
    {

    }
}

