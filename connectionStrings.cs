namespace chessAPI;
public sealed class connectionStrings
    {
        /// <summary>
        /// Cadena de conexión a base de datos relacional
        /// </summary>
        public connectionStrings()
        {
            relationalDBConn = "";
            noRelationalDBConn = "";
        }
        public string relationalDBConn { get; set; }
        public string noRelationalDBConn {  get; set; }
    }