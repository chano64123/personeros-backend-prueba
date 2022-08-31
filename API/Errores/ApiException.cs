namespace API.Errores {
    public class ApiException : ApiResponse {
        public ApiException(int statusCode, string mensaje = null, string detalle = null) : base(statusCode, mensaje) {
            this.detalle = detalle;
        }
        public string detalle { get; set; }
    }
}
