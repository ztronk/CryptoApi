namespace CryptoApi.Models
{
    /// <summary>Коды ответа сервиса</summary>
    public enum ServiceCode
    {
        OK = 200,
        NoContent = 204,
        BadRequest = 400,
        InternalServerError = 500
    }
}