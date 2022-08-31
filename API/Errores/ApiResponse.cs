namespace API.Errores {
    public class ApiResponse {
        public ApiResponse(int statusCode, string mensaje = null) {
            this.statusCode = statusCode;
            this.mensaje = mensaje ?? MensajeStatusCode(statusCode);
        }
     
        public int statusCode { get; set; }
        public string mensaje { get; set; }

        private string MensajeStatusCode(int statusCode) {
            return statusCode switch {
                400 => "Un Bad Request se ha realizado.",
                401 => "No estas autorizado.",
                404 => "Recurso no encontrado.",
                500 => "Error interno, comuníquese con el administrador (+52)928482892.",
                _ => null
            };
        }
    }
}
