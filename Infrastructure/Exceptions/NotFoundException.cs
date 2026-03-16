namespace Institution.Infrastructure.Exceptions;

public class NotFoundException(string entityName, object key) 

    : Exception($"La entidad '{entityName}' con la llave ({key}) no fue encontrada.") { }